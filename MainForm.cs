/*
 * Created by SharpDevelop.
 * User: miaomiao
 * Date: 2014/7/23
 * Time: 14:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace CsDict
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : NoBorder
	{
		private IndexedDict m_dict = new IndexedDict();
		// private FormGenIdx m_formGenIdx = new FormGenIdx();
		private string m_css;
		private SoundPlayer m_sp = new SoundPlayer();
		//private History m_history = new History();
		private int m_position;
		
		private WindowPositionSaver m_posSaver;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			comboBoxInput.IntegralHeight = false;
			comboBoxInput.MaxDropDownItems = 10;
			
			using (var sr = new StreamReader(OptionManager.Instance().StylePath)) {
                m_css = sr.ReadToEnd();
            }
			m_posSaver = new WindowPositionSaver(this, "CsDict", "main");
		}
		
		void UpdateDescription(string meaning)
		{
				var html = new StringBuilder();
				html.Append("<!DOCTYPE html><html><head><meta charset=\"utf8\">");
				html.Append("<title>oxfd</title><style type=\"text/css\">");
				html.Append(m_css);
				html.Append("</style></head><body>");
				if (meaning != null) 
					html.Append(meaning);
				else
					html.Append("单词未找到.");
				html.Append("</body></html>");
				webBrowser1.DocumentText = html.ToString();
				m_scrollY = 0;			
		}
		
		private const int m_maxHistory = 200;
		
		void ButtonSearchClick(object sender, EventArgs e)
		{
			string word = comboBoxInput.Text;
			string meaning;
			if (word == "")
				return;
			// History
			m_dict.lookupWord(word, out meaning, out m_position);

			var items = comboBoxInput.Items;
			if (items.Count == 0) {
				items.Insert(0, word);
			} else {
				items.Remove(word);
				items.Insert(0, word);
				if (items.Count > m_maxHistory) {
					items.RemoveAt(m_maxHistory - 1);
				}
			}
			
			UpdateDescription(meaning);
			//PlayVoice(word);
			comboBoxInput.Focus();
		}
		
		void PlayVoice()
		{
			string word = m_dict.GetWordByIndex(m_position);
			
			// 遇到词组 取第一个单词
			int pos = word.IndexOf(' ');
			if (pos > 0) {
				word = word.Substring(0, word.IndexOf(' '));
			}

			string path = OptionManager.Instance().VoicePath + word[0] + "\\" + word + ".wav";
			m_sp.Stop();
			try {
				m_sp.SoundLocation = path;
				m_sp.Play();
			}
			catch (FileNotFoundException) {
				// do nothing
			}
		}
		
		protected override bool ProcessKeyPreview(ref Message m)
		{
			if (m.Msg == 0x0100) { //WM_KEYDOWN
				Keys key = (Keys)m.WParam;
				switch(key) {
					case Keys.Escape:
						comboBoxInput.Focus();
						return true;
				}
			}
			return false;
		}
		
		void OnComboKeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
			
			switch (e.KeyCode) {
//				case Keys.Escape:
//					comboBoxInput.Text = "";
//					break;
				case Keys.Enter:
					this.ButtonSearchClick(null, null);
					break;
				case Keys.Down:
					ScrollDown(e);
					break;
				case Keys.Up:
					ScrollUp(e);
					break;
				case Keys.PageDown:
					NextWord();
					break;
				case Keys.PageUp:
					PrevWord();
					break;
				case Keys.End:
					PlayVoice();
					break;
				case Keys.Home:
					RandomWord();
					break;
				case Keys.Delete:
					comboBoxInput.DroppedDown = true;
					break;
				default:
					e.Handled = false;
					break;
			}
		}
		
		private int m_scrollY = 0;
		
		void ScrollDown(KeyEventArgs e)
		{
			int scrollAmount = webBrowser1.Size.Height / 2;
			if (comboBoxInput.DroppedDown == false) {
				var doc = webBrowser1.Document;
				if (doc != null) {
					var win = doc.Window;
					if (win != null) {
						m_scrollY += scrollAmount;
						win.ScrollTo(0, m_scrollY);
					}
				}
			} else {
				e.Handled = false;
			}
		}
		
		void ScrollUp(KeyEventArgs e)
		{
			int scrollAmount = webBrowser1.Size.Height / 2;
			if (comboBoxInput.DroppedDown == false) {
				var doc = webBrowser1.Document;
				if (doc != null) {
					var win = doc.Window;
					if (win != null) {
						m_scrollY -= scrollAmount;
						if (m_scrollY < 0)
							m_scrollY = 0;
						win.ScrollTo(0, m_scrollY);
					}
				}
			} else {
				e.Handled = false;	
			}
		}
		
		void PrevWord() {
			m_position--;
			if (m_position < 0)
				m_position = 0;
			var meaning = m_dict.GetMeaningByIndex(m_position);
			UpdateDescription(meaning);
		}
		
		void NextWord() {
			m_position++;
			string meaning = m_dict.GetMeaningByIndex(m_position);
			UpdateDescription(meaning);
		}
		
		private Random m_rnd = new Random();
		
		void RandomWord()
		{
			m_position =  m_rnd.Next(m_dict.Count);
			UpdateDescription(m_dict.GetMeaningByIndex(m_position));
		}
		
		public void DoSearch(string word) {
			comboBoxInput.Text = word;
			ButtonSearchClick(null, null);
			//PlayVoice();
		}
		
		void OnWebKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			switch (e.KeyCode) {
				case Keys.Escape:
					comboBoxInput.Focus();
					break;
			}
		}
		
		void ButtonMenuClick(object sender, EventArgs e)
		{
			var rect = buttonMenu.Bounds;
			contextMenuStrip1.Show(this, rect.Left, rect.Bottom);
		}
		void GenIdxMenuItemClick(object sender, EventArgs e)
		{
			new FormGenIdx().Show(this);
		}
		void ClearMenuItemClick(object sender, EventArgs e)
		{
			comboBoxInput.Items.Clear();
		}
		void OnFormActivated(object sender, EventArgs e)
		{
			comboBoxInput.Focus();
		}
		
		// 窗口状态管理
		void ButtonCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void ButtonMinClick(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}
		
		
		void SearchMenuItemClick(object sender, EventArgs e)
		{
			var form = new FormSearch(this, m_dict);
			form.Show();
		}
		void RandomMenuItemClick(object sender, EventArgs e)
		{
			RandomWord();
		}
		void PrevMenuItemClick(object sender, EventArgs e)
		{
			PrevWord();
		}
		void NextMenuItemClick(object sender, EventArgs e)
		{
			NextWord();
		}
		void ButtonVoiceClick(object sender, EventArgs e)
		{
			PlayVoice();
		}
		void MainFormMove(object sender, EventArgs e)
		{	
		}
		void MainFormResizeEnd(object sender, EventArgs e)
		{
			m_posSaver.Save();
		}
		void MainFormShown(object sender, EventArgs e)
		{
			m_posSaver.Load();
		}
	}
}
