/*
 * Created by SharpDevelop.
 * User: LENOVO
 * Date: 2016/8/9 星期二
 * Time: 18:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

namespace CsDict
{
	/// <summary>
	/// Description of WindowPositionSaver.
	/// </summary>
	public sealed class WindowPositionSaver
	{
		private Form m_form;
		private string m_softwareName;
		private string m_windowName;
		
		public WindowPositionSaver(Form frm, string softwareName, string windowName)
		{
			m_form = frm;
			m_softwareName = softwareName;
			m_windowName = windowName;
		}
		
		public void Save()
		{
			Point pos = m_form.Location;
			Size size = m_form.Size;
			string regData = String.Format("{0}|{1}|{2}|{3}", pos.X, pos.Y, size.Width, size.Height);
			string regPath = "HKEY_CURRENT_USER\\Software\\" + m_softwareName;
			string regName = m_windowName + "_pos";
			Registry.SetValue(regPath, regName, regData);
		}
		
		public void Load()
		{
			string regPath = "HKEY_CURRENT_USER\\Software\\" + m_softwareName;
			string regName = m_windowName + "_pos";
			var regData = Registry.GetValue(regPath, regName, "");
			if (regData == null) {
				return;
			}
			string strPos = (string)regData;
			var posAarry = strPos.Split('|');
			if (posAarry.Length != 4) {
				return;
			}
			int x, y, w, h;
			if (!Int32.TryParse(posAarry[0], out x)){
			    return;
			}
			if (!Int32.TryParse(posAarry[1], out y)){
			    return;
			}
			if (!Int32.TryParse(posAarry[2], out w)){
			    return;
			}
			if (!Int32.TryParse(posAarry[3], out h)){
			    return;
			}
			Point pos = new Point(x, y);
			Size size = new Size(w, h);
			// TODO 这里要检查是否在屏幕外面 还要支持多显示器
			m_form.Size = size;
			m_form.Location = pos;
		}
	}
}
