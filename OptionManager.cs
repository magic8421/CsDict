/*
 * Created by SharpDevelop.
 * User: miaomiao
 * Date: 2014/11/3
 * Time: 13:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace CsDict
{
	/// <summary>
	/// 配置
	/// </summary>
	public class OptionManager
	{
		public OptionManager()
		{
		}
		
		private string m_dictDir = Application.StartupPath + "\\";
		
		public string DictPath 
		{
			get
			{
				return m_dictDir + "oxfd.txt";
			}
		}
		
		public string IdxPath
		{
			get
			{
				return m_dictDir + "oxfd.idx";
			}
		}
		
		public string MetaphoneIdxPath
		{
			get {
				return m_dictDir + "metaphone.idx";
			}
		}
		
		public string StylePath
		{
			get
			{
				return m_dictDir + "oxfd.css";
			}
		}
		
		public string VoicePath
		{
			get
			{
				return m_dictDir + "WyabdcRealPeopleTTS\\";
			}
		}
		
		static private OptionManager m_sInstance = null;
		
		static public OptionManager Instance()
		{
			if (m_sInstance == null)
			{
				m_sInstance = new OptionManager();
			}
			return m_sInstance;
		}
	}
}
