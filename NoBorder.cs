/*
 * Created by SharpDevelop.
 * User: miaomiao
 * Date: 2014/11/7
 * Time: 15:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace CsDict
{
	/// <summary>
	/// Move and Resize a window withou border
	/// </summary>
	public class NoBorder : Form
	{
		public NoBorder()
		{
		}
		
		// Grip size
		private const int cGrip = 5;
		
		// Caption bar height;
		private const int cCaption = 40;
		
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x84) {  // Trap WM_NCHITTEST
				Point pos = new Point(0, 0);
				try {
					byte[] data = BitConverter.GetBytes(m.LParam.ToInt32());
					int x = BitConverter.ToInt16(data, 0);
					int y = BitConverter.ToInt16(data, 2);
					pos = new Point(x, y);
					pos = this.PointToClient(pos);
				} catch(System.Exception e)
				{
					var error = e.ToString();
					Console.WriteLine(error);
				}
				/*
				try {
					int x = m.LParam.ToInt32() & 0x0000FFFF;
					int y = (int)((m.LParam.ToInt32() & 0xFFFF0000) >> 16);
					pos = new Point(x, y);
					pos = this.PointToClient(pos);
				} catch(System.Exception e)
				{
					var error = e.ToString();
				}
				*/
				if (pos.X < 0) {
					if (Debugger.IsAttached) {
						Debugger.Break();
					}
				}
				if (pos.X > 0 && pos.X < cGrip && pos.Y > 0 && pos.Y < cGrip) {
					m.Result = (IntPtr)13; //HTTOPLEFT
					return;
				}
				if (pos.X < ClientSize.Width && pos.X > ClientSize.Width - cGrip && pos.Y < cGrip && pos.Y > 0) {
					m.Result = (IntPtr)14; //HTTOPRIGHT
					return;
				}
				if (pos.X >= ClientSize.Width - cGrip &&  pos.Y >= this.ClientSize.Height - cGrip) {
					m.Result = (IntPtr)17; // HTBOTTOMRIGHT
					return;
				}
				if (pos.X > 0 && pos.X < cGrip && pos.Y > this.ClientSize.Height - cGrip && pos.Y < ClientSize.Height) {
					m.Result = (IntPtr)16; // HTBOTTOMLEFT
					return;
				}
				if (pos.X > 0 && pos.X < cGrip) {
					m.Result = (IntPtr)10; // HTLEFT
					return;
				}
				if (pos.X > this.ClientSize.Width - cGrip) {
					m.Result = (IntPtr)11; // HTRIGHT
					return;
				}
				if (pos.Y > 0 && pos.Y < cGrip) {
					m.Result = (IntPtr)12; // HTTOP
					return;
				}
				if (pos.Y > this.ClientSize.Height - cGrip) {
					m.Result = (IntPtr)15; // HTBOTTOM
					return;
				}
				if (pos.Y > 0 && pos.Y < cCaption) {
					m.Result = (IntPtr)2;  // HTCAPTION
					return;
				}
			}
			base.WndProc(ref m);
		}
	}
}
