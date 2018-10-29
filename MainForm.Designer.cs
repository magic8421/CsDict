/*
 * Created by SharpDevelop.
 * User: miaomiao
 * Date: 2014/7/23
 * Time: 14:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CsDict
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.comboBoxInput = new System.Windows.Forms.ComboBox();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.RandomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.PrevMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ClearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GenIdxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonMenu = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonMin = new System.Windows.Forms.Button();
			this.buttonVoice = new System.Windows.Forms.Button();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBoxInput
			// 
			this.comboBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxInput.CausesValidation = false;
			this.comboBoxInput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxInput.Location = new System.Drawing.Point(35, 4);
			this.comboBoxInput.MaxDropDownItems = 5;
			this.comboBoxInput.Name = "comboBoxInput";
			this.comboBoxInput.Size = new System.Drawing.Size(238, 29);
			this.comboBoxInput.TabIndex = 0;
			this.comboBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnComboKeyDown);
			// 
			// webBrowser1
			// 
			this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.webBrowser1.Location = new System.Drawing.Point(6, 38);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(418, 225);
			this.webBrowser1.TabIndex = 4;
			this.webBrowser1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OnWebKeyDown);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.RandomMenuItem,
			this.PrevMenuItem,
			this.NextMenuItem,
			this.ClearMenuItem,
			this.SearchMenuItem,
			this.GenIdxMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(195, 136);
			// 
			// RandomMenuItem
			// 
			this.RandomMenuItem.Name = "RandomMenuItem";
			this.RandomMenuItem.Size = new System.Drawing.Size(194, 22);
			this.RandomMenuItem.Text = "随机单词(Home)";
			this.RandomMenuItem.Click += new System.EventHandler(this.RandomMenuItemClick);
			// 
			// PrevMenuItem
			// 
			this.PrevMenuItem.Name = "PrevMenuItem";
			this.PrevMenuItem.Size = new System.Drawing.Size(194, 22);
			this.PrevMenuItem.Text = "前一单词(PageUp)";
			this.PrevMenuItem.Click += new System.EventHandler(this.PrevMenuItemClick);
			// 
			// NextMenuItem
			// 
			this.NextMenuItem.Name = "NextMenuItem";
			this.NextMenuItem.Size = new System.Drawing.Size(194, 22);
			this.NextMenuItem.Text = "下一单词(PageDown)";
			this.NextMenuItem.Click += new System.EventHandler(this.NextMenuItemClick);
			// 
			// ClearMenuItem
			// 
			this.ClearMenuItem.Name = "ClearMenuItem";
			this.ClearMenuItem.Size = new System.Drawing.Size(194, 22);
			this.ClearMenuItem.Text = "清空历史";
			this.ClearMenuItem.Click += new System.EventHandler(this.ClearMenuItemClick);
			// 
			// SearchMenuItem
			// 
			this.SearchMenuItem.Name = "SearchMenuItem";
			this.SearchMenuItem.Size = new System.Drawing.Size(194, 22);
			this.SearchMenuItem.Text = "高级查找";
			this.SearchMenuItem.Click += new System.EventHandler(this.SearchMenuItemClick);
			// 
			// GenIdxMenuItem
			// 
			this.GenIdxMenuItem.Name = "GenIdxMenuItem";
			this.GenIdxMenuItem.Size = new System.Drawing.Size(194, 22);
			this.GenIdxMenuItem.Text = "生成索引";
			this.GenIdxMenuItem.Visible = false;
			this.GenIdxMenuItem.Click += new System.EventHandler(this.GenIdxMenuItemClick);
			// 
			// buttonMenu
			// 
			this.buttonMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMenu.BackColor = System.Drawing.Color.Yellow;
			this.buttonMenu.Location = new System.Drawing.Point(324, 4);
			this.buttonMenu.Name = "buttonMenu";
			this.buttonMenu.Size = new System.Drawing.Size(44, 29);
			this.buttonMenu.TabIndex = 1;
			this.buttonMenu.Text = "菜单";
			this.buttonMenu.UseVisualStyleBackColor = false;
			this.buttonMenu.Click += new System.EventHandler(this.ButtonMenuClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.BackColor = System.Drawing.Color.OrangeRed;
			this.buttonClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.buttonClose.ForeColor = System.Drawing.Color.White;
			this.buttonClose.Location = new System.Drawing.Point(400, 4);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(26, 29);
			this.buttonClose.TabIndex = 3;
			this.buttonClose.Text = "X";
			this.buttonClose.UseVisualStyleBackColor = false;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// buttonMin
			// 
			this.buttonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMin.BackColor = System.Drawing.Color.Chartreuse;
			this.buttonMin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.buttonMin.Location = new System.Drawing.Point(371, 4);
			this.buttonMin.Name = "buttonMin";
			this.buttonMin.Size = new System.Drawing.Size(26, 29);
			this.buttonMin.TabIndex = 2;
			this.buttonMin.Text = "_";
			this.buttonMin.UseVisualStyleBackColor = false;
			this.buttonMin.Click += new System.EventHandler(this.ButtonMinClick);
			// 
			// buttonVoice
			// 
			this.buttonVoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonVoice.BackColor = System.Drawing.Color.MintCream;
			this.buttonVoice.Location = new System.Drawing.Point(277, 4);
			this.buttonVoice.Name = "buttonVoice";
			this.buttonVoice.Size = new System.Drawing.Size(44, 29);
			this.buttonVoice.TabIndex = 5;
			this.buttonVoice.Text = "发音";
			this.buttonVoice.UseVisualStyleBackColor = false;
			this.buttonVoice.Click += new System.EventHandler(this.ButtonVoiceClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.ClientSize = new System.Drawing.Size(430, 269);
			this.Controls.Add(this.buttonVoice);
			this.Controls.Add(this.buttonMin);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonMenu);
			this.Controls.Add(this.comboBoxInput);
			this.Controls.Add(this.webBrowser1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "CsDict";
			this.Activated += new System.EventHandler(this.OnFormActivated);
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.ResizeEnd += new System.EventHandler(this.MainFormResizeEnd);
			this.Move += new System.EventHandler(this.MainFormMove);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.ToolStripMenuItem ClearMenuItem;
		private System.Windows.Forms.ToolStripMenuItem GenIdxMenuItem;
		private System.Windows.Forms.Button buttonMenu;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.ComboBox comboBoxInput;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonMin;
		private System.Windows.Forms.ToolStripMenuItem SearchMenuItem;
		private System.Windows.Forms.ToolStripMenuItem RandomMenuItem;
		private System.Windows.Forms.ToolStripMenuItem PrevMenuItem;
		private System.Windows.Forms.ToolStripMenuItem NextMenuItem;
		private System.Windows.Forms.Button buttonVoice;
	}
}
