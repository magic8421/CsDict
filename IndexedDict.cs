/*
 * Created by SharpDevelop.
 * User: miaomiao
 * Date: 2014/7/23
 * Time: 15:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using DoubleMetaphone;

namespace CsDict
{
	class CompareWord : IComparer {
		public int Compare(object x, object y)
		{
			var lhs = (Record) x;
			var rhs = (Record) y;
			return String.Compare(lhs.strWord, rhs.strWord, StringComparison.OrdinalIgnoreCase);
		}
	}
	class CompareMetaphone : IComparer {
		public int Compare(object x, object y)
		{
			var lhs = (Record) x;
			var rhs = (Record) y;
			return String.Compare(lhs.strMetaphone, rhs.strMetaphone, StringComparison.OrdinalIgnoreCase);
		}
	}
	class Record {
		public string strWord;
		public Int32 nOffset;
		public string strMetaphone;
	}
	
	public static class IndexGenerate
	{
		public static void CreateIndex(BackgroundWorker worker)
		{
			string fileName = OptionManager.Instance().DictPath;
			string idxFileName = OptionManager.Instance().IdxPath;
			
			var arrayRecord = new ArrayList();
			
			
			
			int offset = 0;
			int lastPos = offset;
			int tmpByte;

			var tmpStream = new MemoryStream();
			
			const float totalCount = 50439; // 怎样程序获得呢?
			int lastPercent = 0;
			int percent = 0;

//			try {
				var f = new FileStream(fileName, FileMode.Open);
				tmpByte = f.ReadByte();
				while (tmpByte > 0) {
					if (tmpByte == '\t') {
						var rec = new Record();
						rec.nOffset = lastPos;
						rec.strWord = System.Text.Encoding.UTF8.GetString(tmpStream.ToArray());
						rec.strMetaphone = GetMetaphone(rec.strWord);
						arrayRecord.Add (rec);
						//Debug.WriteLine(rec.strWord + ";" + rec.strMetaphone);
						percent = (int)((float)arrayRecord.Count / totalCount * 90.0f);
						if (percent != lastPercent) {
							lastPercent = percent;
							worker.ReportProgress(percent, "已处理: " + arrayRecord.Count + " " + rec.strWord + "-->" + rec.strMetaphone);
						}
					}
					else if (tmpByte == '\n') {
						lastPos = offset + 1;
						tmpStream.SetLength(0);
					}
					else {
						tmpStream.WriteByte((byte)tmpByte);
					}
					offset ++;
					tmpByte = f.ReadByte();
				} 
				f.Close();
//			}
//			catch ( Exception e ) {
//				MessageBox.Show(e.StackTrace);
//				worker.ReportProgress(50, "错误: " + e.Message);
//			}
			
			
			worker.ReportProgress(90, "排序...");
			arrayRecord.Sort(new CompareWord());
			worker.ReportProgress(92, "排序完成");
			
			worker.ReportProgress(94, "写入索引文件...");
			WriteIdxFile(arrayRecord, idxFileName);
			worker.ReportProgress(96, "写入完成");
			
			worker.ReportProgress(98, "排序相似性...");
			arrayRecord.Sort(new CompareMetaphone());
			worker.ReportProgress(100, "写入相似性文件...");
			WriteIdxFile(arrayRecord, OptionManager.Instance().MetaphoneIdxPath);
		}
		
		public static void WriteIdxFile(ArrayList list, string fileName)
		{
			var f = new FileStream(fileName, FileMode.Create);
			var writer = new BinaryWriter(f);
			
			for(int i = 0; i < list.Count; i ++) {
				var rec = (Record) list[i];
				writer.Write(rec.nOffset);
			}
			writer.Close();
			f.Close();
		}
		
		public static string GetMetaphone(string word)
		{
			int pos = word.IndexOf(" ,", StringComparison.Ordinal);
			if (pos > -1) {
				word = word.Substring(0, pos);
			}
			if (word.Length < 3) { //黑科技
				return null;
			}
			if (word.IndexOfAny(new char[]{ ' ', '-', '\'' }) > -1) {
				return null;
			}
			return word.GenerateDoubleMetaphone();
		}
	}
	
	/// <summary>
	/// Using a index file to quickly search a word form a large txt data file;
	/// </summary>
	public class IndexedDict
	{
		public IndexedDict()
		{
			m_dictFile = new FileStream (OptionManager.Instance().DictPath, FileMode.Open, FileAccess.Read);
			m_idxFile = new FileStream(OptionManager.Instance().IdxPath, FileMode.Open, FileAccess.Read);
			m_metaphoneFile = new FileStream(OptionManager.Instance().MetaphoneIdxPath, FileMode.Open, FileAccess.Read);
		}
		
		~IndexedDict()
		{
			m_dictFile.Close();
			m_idxFile.Close();
			m_metaphoneFile.Close();
		}
		
		private readonly FileStream m_idxFile;
		private readonly FileStream m_dictFile;
		private readonly FileStream m_metaphoneFile;
		
		public bool lookupWord(string search, out string meaning, out int pos) {
			int upper = (int) (m_idxFile.Length / 4) - 1; // 和数组一样 最后一个元素下标是总数减一
			int lower = 0;
			//pos = 0;
			int ret;
			string tmp;
			do {
				pos = (upper + lower) / 2;
				tmp = GetWordByIndex(pos);
				ret = String.Compare(search, tmp, StringComparison.OrdinalIgnoreCase);
				
				if (ret == 0) {
					break;
				} else if (ret < 0) {
					upper = pos - 1;
					pos = (upper + lower) / 2;
				} else {
					lower = pos + 1;
					pos = (upper + lower) / 2;
				}
			} while (upper >= lower);
			
//			if (ret == 0) {
//				meaning = getMeaning(pos);
//			} else {
//				meaning = null;
//			}
			meaning = GetMeaningByIndex(pos);
			return ret == 0;
		}
		
		public ArrayList GetMetaphoneList(string word)
		{
			int upper = (int) (m_metaphoneFile.Length / 4) - 1; // 和数组一样 最后一个元素下标是总数减一
			int lower = 0;
			int pos = 0;
			int ret;
			string tmp;
			var list = new ArrayList();
			
			string search = IndexGenerate.GetMetaphone(word);
			if (search == null) {
				return list;
			}
			
			do { // TODO 可以提取到一个函数中
				pos = (upper + lower) / 2;
				tmp = IndexGenerate.GetMetaphone(GetWordByMetaIndex(pos)); //TODO 这里错了 不能用普通的查找表来找MP
				ret = String.Compare(search, tmp, StringComparison.OrdinalIgnoreCase);
				
				if (ret == 0) {
					break;
				} else if (ret < 0) {
					upper = pos - 1;
					pos = (upper + lower) / 2;
				} else {
					lower = pos + 1;
					pos = (upper + lower) / 2;
				}
			} while (upper >= lower);
			
 			if (ret == 0) {
				// 向前找第一个
 				for (int i = 1; i < 100; i++) {
					string meta = IndexGenerate.GetMetaphone(GetWordByMetaIndex(pos - i));
					if (meta != search) {
						pos = pos - i + 1;
						break;
					}
 				}
				// 按顺序插入输出
				for (int i = 0; i < 100; i++) {
					string out_word = GetWordByMetaIndex(pos + i);
					string meta = IndexGenerate.GetMetaphone(out_word);
					
					if (meta != search) {
						break;
					}
					list.Add(out_word);
				}
 			}
			list.Sort();
			return list;
		}
		
		private string GetWordByMetaIndex(int index) {
			return GetWordRaw(m_metaphoneFile, index);
		}
		
		public string GetWordByIndex(int index) {
			return GetWordRaw(m_idxFile, index);
		}
		
		private string GetWordRaw(FileStream idxFile, int index) {
			idxFile.Seek(index * 4, SeekOrigin.Begin);
			var binReader = new BinaryReader(idxFile);
			int offset = binReader.ReadInt32();
			m_dictFile.Seek(offset, SeekOrigin.Begin);
			var buf = new byte[128]; //大于最大单词长度
			
			int i;
			bool bFound = false;
			for (i = 0; i < buf.Length; i ++) {
				buf[i] = (byte) m_dictFile.ReadByte();
				if (buf[i] == '\t') {
					buf[i] = 0;
					bFound = true;
					break;
				}
			}
			if(!bFound) {
				throw new Exception("too long word > 128");
			}
			return System.Text.Encoding.UTF8.GetString(buf, 0, i);
		}
		
		public string GetMeaningByIndex(int index) {
			m_idxFile.Seek(index * 4, SeekOrigin.Begin);
			var binReader = new BinaryReader(m_idxFile);
			int offset = binReader.ReadInt32();
			m_dictFile.Seek(offset, SeekOrigin.Begin);
			
			int tmpByte = 0;
			while (tmpByte != '\t') {
				tmpByte = m_dictFile.ReadByte();
			}
			
			var tmpStream = new MemoryStream();
			tmpByte = m_dictFile.ReadByte();
			while (tmpByte != '\r') {
				tmpStream.WriteByte((byte)tmpByte);
				tmpByte = m_dictFile.ReadByte();
			}
			return System.Text.Encoding.UTF8.GetString(tmpStream.ToArray());
		}
		
		// return the total count of words in the dictionary
		public int Count {
			get {
				return (int) (m_idxFile.Length / 4);
			}
		}
	}
}
