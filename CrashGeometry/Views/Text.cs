using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace CrashGeometry.Views
{
	public class Text : View
	{
		public string Value { get; set; }
		public Color Color { get; set; }
		public System.Drawing.Font Font { get; set; }
		public System.Drawing.StringFormat StringFormat { get; set; }
		public Text()
		{
			Value = "View";
			X = 0;
			Y = 0;
			Color = Color.White;
			Font = new System.Drawing.Font("Arial", 11);
			StringFormat = new System.Drawing.StringFormat();
			StringFormat.Alignment = System.Drawing.StringAlignment.Center;
			StringFormat.LineAlignment = System.Drawing.StringAlignment.Center;
		}
		public override void Draw()
		{
			Game.Graphics.Get().DrawString(Value, Font, new System.Drawing.SolidBrush(Color), X, Y, StringFormat);
		}
		public override void Dispose()
		{
			Font.Dispose();
		}
	}
}
