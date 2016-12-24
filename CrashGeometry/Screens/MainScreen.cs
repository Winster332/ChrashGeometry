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
			Intent = new IntentWhiteBlack(Game);
			Intent.Create(this, null, 15, 255).Start(StateIntent.RunningShow, false);

			AddView(Button.Create("Начать", Game.GetForm().Width / 2, Game.GetForm().Height / 2-35, 100, 30, Color.FromArgb(60, 140, 210), Color.FromArgb(255, 255, 255), new System.Drawing.Font("Arial", 12)).AddListenerClick(view =>
			{
				Intent.Create(this, new WorkspaceScreen(), 10, 0).Start(StateIntent.RunningHide, true);
			}));
			AddView(Button.Create("Выход", Game.GetForm().Width / 2, Game.GetForm().Height / 2, 100, 30, Color.FromArgb(60, 140, 210), Color.FromArgb(255, 255, 255), new System.Drawing.Font("Arial", 12)).AddListenerClick(view =>
			{
				System.Windows.Forms.Application.Exit();
			}));

			AddView(Text.Create("Crash Geometry", Game.GetForm().Width / 2, Game.GetForm().Height / 2 - 125, new System.Drawing.Font("Arial", 20), Color.White));

			//Text text = new Text();
			//text.Position = new LMDMono2D.Dot(100, 100);
			//AddView(text);

			//Polygon poly = Polygon.Create(Game, new LMDMono2D.Dot[]
			//	{
			//		new LMDMono2D.Dot(100, 100),
			//		new LMDMono2D.Dot(200, 100),
			//		new LMDMono2D.Dot(200, 200),
			//		new LMDMono2D.Dot(100, 200)
			//	}, TypeDrawing.Fills, Color.White);
			//poly.AddListenerClick(view => 
			//{
			//	Console.WriteLine("Click on polygon");
			//});
			//AddView(poly);

			//AddView(Circle.Create(Game, 400, 100, 30, Color.White).AddListenerClick(view =>
			//{
			//	Console.WriteLine("Click on circle");
			//}));
		}
		public override void Render()
		{
			Game.Graphics.Begin(Color.FromArgb(50, 50, 50));
			base.Render();
			Intent.Draw();
			Game.Graphics.End();
		}
		public override void Dispose()
		{
			base.Dispose();
		}
	}
}
