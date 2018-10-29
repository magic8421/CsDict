/*
 * Created by SharpDevelop.
 * User: miaomiao
 * Date: 2014/11/12
 * Time: 12:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CsDict
{
	partial class FormSearch
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox textBoxInput;
		private System.Windows.Forms.Button buttonSearch;
		private System.Windows.Forms.ListView listViewResult;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxInput = new System.Windows.Forms.TextBox();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.listViewResult = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// textBoxInput
			// 
			this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInput.Location = new System.Drawing.Point(12, 12);
			this.textBoxInput.Name = "textBoxInput";
			this.textBoxInput.Size = new System.Drawing.Size(257, 21);
			this.textBoxInput.TabIndex = 0;
			this.textBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxInputKeyDown);
			// 
			// buttonSearch
			// 
			this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSearch.Location = new System.Drawing.Point(275, 12);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size(51, 20);
			this.buttonSearch.TabIndex = 1;
			this.buttonSearch.Text = "Search";
			this.buttonSearch.UseVisualStyleBackColor = true;
			this.buttonSearch.Click += new System.EventHandler(this.ButtonSearchClick);
			// 
			// listViewResult
			// 
			this.listViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewResult.Location = new System.Drawing.Point(12, 39);
			this.listViewResult.Name = "listViewResult";
			this.listViewResult.Size = new System.Drawing.Size(314, 206);
			this.listViewResult.TabIndex = 2;
			this.listViewResult.UseCompatibleStateImageBehavior = false;
			this.listViewResult.View = System.Windows.Forms.View.List;
			this.listViewResult.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewResultItemSelectionChanged);
			// 
			// FormSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 257);
			this.Controls.Add(this.listViewResult);
			this.Controls.Add(this.buttonSearch);
			this.Controls.Add(this.textBoxInput);
			this.Name = "FormSearch";
			this.Text = "Fuzzy Search";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
