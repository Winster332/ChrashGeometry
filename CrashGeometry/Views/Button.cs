using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace CrashGeometry.Views
{
	public class Button : View
	{
		public float Width { get; set; }
		public float Height { get; set; }
		public string Text { get; set; }
		public System.Drawing.Font Font { get; set; }
		public Color ColorDown { get; set; }
		public Color ColorMove { get; set; }
		public Color Background { get; set; }
		public Color Foreground { get; set; }
		public System.Drawing.StringFormat StringFormat;
		public Button()
		{
			X = 0;
			Y = 0;
			Width = 80;
			Height = 25;
			Text = "Button";
			Font = new System.Drawing.Font("Arial", 11);
			Background = Color.FromArgb(60, 140, 210);
			Foreground = Color.FromArgb(255, 255, 255);
			ColorDown = Color.FromArgb(40, 120, 190);
			ColorMove = Color.FromArgb(80, 160, 220);
			StringFormat = new System.Drawing.StringFormat();
			StringFormat.Alignment = System.Drawing.StringAlignment.Center;
			StringFormat.LineAlignment = System.Drawing.StringAlignment.Center;
		}
		public override void Draw()
		{
			if (Game.Input.PoolMouse.Moves.Count > 0)
			{
				var mouseX = Game.Input.PoolMouse.GetLastMove().X;
				var mouseY = Game.Input.PoolMouse.GetLastMove().Y;

				if (mouseX >= X - Width / 2 && mouseX <= X + Width / 2 &&
					mouseY >= Y - Height / 2 && mouseY <= Y + Height / 2)
					Game.Graphics.Get().FillRectangle(new System.Drawing.SolidBrush(ColorMove), X - Width / 2, Y - Height / 2, Width, Height);
				else Game.Graphics.Get().FillRectangle(new System.Drawing.SolidBrush(Background), X - Width / 2, Y - Height / 2, Width, Height);
			}
			if (Game.Input.PoolMouse.Downs.Count > 0)
			{
				var mouseX = Game.Input.PoolMouse.GetLastDown().X;
				var mouseY = Game.Input.PoolMouse.GetLastDown().Y;

				if (mouseX >= X - Width / 2 && mouseX <= X + Width / 2 &&
					mouseY >= Y - Height / 2 && mouseY <= Y + Height / 2)
				{
					Game.Graphics.Get().FillRectangle(new System.Drawing.SolidBrush(ColorDown), X - Width / 2, Y - Height / 2, Width, Height);
					for (int i = 0; i < Clicks.Count; i++)
						Clicks[i](this);
				}
				else Game.Graphics.Get().FillRectangle(new System.Drawing.SolidBrush(Background), X - Width / 2, Y - Height / 2, Width, Height);
			}
			if (Game.Input.PoolMouse.Ups.Count > 0)
			{
			}

			Game.Graphics.Get().DrawString(Text, Font, new System.Drawing.SolidBrush(Foreground), X, Y, StringFormat);
		}
		public override void Dispose()
		{
			Font.Dispose();
		}
		public static Button Create(string text, float x, float y, float width, float height, Color background, Color foreground, System.Drawing.Font font)
		{
			Button button = new Button();
			button.X = x;
			button.Y = y;
			button.Width = width;
			button.Height = height;
			button.Background = background;
			button.Foreground = foreground;
			button.Font = font;

			return button;
		}
	}
}
