using LMDMono2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Models
{
	public class Circle : Model
	{
		public float Radius { get; set; }
		public Pen pen;
		protected override void Loaded()
		{
			Radius = 20;
			pen = new Pen(Color, SizeLine);
		}
		public override void Draw()
		{
			if (TypeDrawing == TypeDrawing.Lines)
			{
				pen.Color = Color;
				pen.Width = SizeLine;
				Game.Graphics.Get().DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
			}
			if (TypeDrawing == TypeDrawing.Fills)
				Game.Graphics.Get().FillEllipse(new SolidBrush(Color), X - Radius, Y - Radius, Radius * 2, Radius * 2);

			if (Game.Input.PoolMouse.Downs.Count > 0)
			{
				float distance = DotMath.Distance(Position, new Dot(Game.Input.PoolMouse.GetLastDown().X, Game.Input.PoolMouse.GetLastDown().Y));
				if (distance <= Radius)
					for (int i = 0; i < Clicks.Count; i++)
						Clicks[i](this);
			}
		}
		public override void Dispose()
		{
			pen.Dispose();
		}
		public static Circle Create(GameEngine.Game game, float x, float y, float radius, Color color, TypeDrawing type = TypeDrawing.Fills, int sizeLine = 1)
		{
			Circle c = new Circle();
			c.Initialize(game);
			c.X = x;
			c.Y = y;
			c.Radius = radius;
			c.TypeDrawing = type;
			c.SizeLine = sizeLine;

			return c;
		}
	}
}
