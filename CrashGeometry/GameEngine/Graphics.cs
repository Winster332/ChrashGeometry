using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.GameEngine
{
	public class Graphics
	{
		private System.Windows.Forms.PictureBox pBox;
		private System.Drawing.Image image;
		private System.Drawing.Graphics graphics;

		public void Initialize(System.Windows.Forms.Form form)
		{
			this.pBox = new System.Windows.Forms.PictureBox();
			this.pBox.Size = form.Size;
			this.pBox.Location = new System.Drawing.Point(0, 0);

			this.image = new System.Drawing.Bitmap(pBox.Width, pBox.Height);
			this.graphics = System.Drawing.Graphics.FromImage(image);
			this.graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			form.Controls.Add(pBox);
		}
		public void Begin(System.Drawing.Color color)
		{
			graphics.Clear(color);
		}
		public void End()
		{
			pBox.Image = image;
		}
		public void Get()
		{
		}
		public System.Windows.Forms.PictureBox GetPicture()
		{
			return pBox;
		}
	}
}
