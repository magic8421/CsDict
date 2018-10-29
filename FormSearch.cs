/*
 * Created by SharpDevelop.
 * User: miaomiao
 * Date: 2014/11/12
 * Time: 12:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CsDict
{
	/// <summary>
	/// Description of FormSearch.
	/// </summary>
	public partial class FormSearch : Form
	{
		private readonly MainForm m_parent;
		private readonly IndexedDict m_dict;
		
		public FormSearch(MainForm parent, IndexedDict dict)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			m_parent = parent;
			m_dict = dict;
		}
		void ButtonSearchClick(object sender, EventArgs e)
		{
			var list = m_dict.GetMetaphoneList(textBoxInput.Text);
			listViewResult.Items.Clear();
			foreach (var item in list) {
				// var tmp = (string)item + "-->" + IndexGenerate.GetMetaphone((string)item);
				listViewResult.Items.Add((string)item);
			}
		}
		void ListViewResultItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			m_parent.DoSearch(e.Item.Text);
		}
		void TextBoxInputKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				ButtonSearchClick(null, null);
				e.Handled = true;
				return;
			}
		}
	}
}
