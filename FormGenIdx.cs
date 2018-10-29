/*
 * Created by SharpDevelop.
 * User: miaomiao
 * Date: 2014/7/24
 * Time: 12:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CsDict
{
	/// <summary>
	/// Description of FormGenIdx.
	/// </summary>
	public partial class FormGenIdx : Form
	{
		
		
		public FormGenIdx()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ButtonStartClick(object sender, EventArgs e)
		{
			buttonStart.Enabled = false;
			backgroundWorker1.RunWorkerAsync();
		}
		void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			IndexGenerate.CreateIndex(backgroundWorker1);
		}
		void OnComplete(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			listBoxLog.Items.Add("操作完成!");
			ScrollToBottom(listBoxLog);
			buttonStart.Enabled = true;
		}
		void OnProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
			listBoxLog.Items.Add((string)e.UserState);
			ScrollToBottom(listBoxLog);
		}
		static public void ScrollToBottom(ListBox listBox) 
		{
			int visibleItems = listBox.ClientSize.Height / listBox.ItemHeight;
			listBox.TopIndex = Math.Max(listBox.Items.Count - visibleItems + 1, 0);
		}
	}
}
