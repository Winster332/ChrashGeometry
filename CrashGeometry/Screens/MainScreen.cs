using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrashGeometry.GameEngine;
using CrashGeometry.Views;
using Color = System.Drawing.Color;
using CrashGeometry.Models;

namespace CrashGeometry.Screens
{
	public class MainScreen : BaseScreen
	{
		public override void Create()
		{
			Button button = new Button();
			button.Position = new LMDMono2D.Dot(Game.GetForm().Width / 2, Game.GetForm().Height / 2);
			button.AddListenerClick(view =>
			{
				Console.WriteLine("Click on button");
			});
			AddView(button);

			Text text = new Text();
			text.Position = new LMDMono2D.Dot(100, 100);
			AddView(text);

			Polygon poly = Polygon.Create(new LMDMono2D.Dot[]
				{
					new LMDMono2D.Dot(100, 100),
					new LMDMono2D.Dot(200, 100),
					new LMDMono2D.Dot(200, 200),
					new LMDMono2D.Dot(100, 200)
				}, TypeDrawing.Fills, Color.White);
			poly.AddListenerClick(view => 
			{
				Console.WriteLine("Click on polygon");
			});
			AddView(poly);

			AddView(Circle.Create(400, 100, 30, Color.White).AddListenerClick(view =>
			{
				Console.WriteLine("Click on circle");
			}));
		}
		public override void Render()
		{
			Game.Graphics.Begin(Color.FromArgb(50, 50, 50));
			base.Render();
			Game.Graphics.End();
		}
		public override void Dispose()
		{
			base.Dispose();
		}
	}
}
