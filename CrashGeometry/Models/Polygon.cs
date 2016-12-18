using LMDMono2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Models
{
	public class Polygon : Model
	{
		private System.Drawing.Pen pen;
		protected override void Loaded()
		{
			pen = new System.Drawing.Pen(Color, SizeLine);
		}
		public override void Draw()
		{
			if (TypeDrawing == TypeDrawing.Fills)
			{
				using (var solidColor = new System.Drawing.SolidBrush(Color))
					Game.Graphics.Get().FillPolygon(solidColor, Dot.ToPointFs(Verteces));
			}
			if (TypeDrawing == TypeDrawing.Lines)
			{
				pen.Color = Color;
				pen.Width = SizeLine;
				Game.Graphics.Get().DrawPolygon(pen, Dot.ToPointFs(Verteces));
			}
			if (Game.Input.PoolMouse.Downs.Count > 0)
			{
				bool isDown = DotMath.IsDotInPolygon(Verteces, new Dot(Game.Input.PoolMouse.GetLastDown().X, Game.Input.PoolMouse.GetLastDown().Y));
				if (isDown)
					for (int i = 0; i < Clicks.Count; i++)
						Clicks[i](this);
			}
		}	
		public override void Dispose()
		{
			pen.Dispose();
		}
		public static Polygon Create(Dot[] points, TypeDrawing typeDrawing, System.Drawing.Color color, int sizeLine = 1)
		{
			Polygon poly = new Polygon();
			poly.Verteces = points;
			poly.TypeDrawing = typeDrawing;
			poly.Color = color;
			poly.SizeLine = sizeLine;

			return poly;
		}
	}
}
