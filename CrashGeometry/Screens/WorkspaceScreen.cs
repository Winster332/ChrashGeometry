using CrashGeometry.GameEngine;
using CrashGeometry.Models;
using CrashGeometry.Views;
using LMDMono2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Screens
{
	public class WorkspaceScreen : BaseScreen
	{
		Dot[] ds = new Dot[] { new Dot(40, 40), new Dot(120, 40), new Dot(80, 80), new Dot(70, 70), new Dot(50, 90), new Dot(30, 20), };
		public override void Create()
		{
			Intent = new IntentWhiteBlack(Game);
			Intent.Create(this, null, 15, 255).Start(StateIntent.RunningShow, false);

			InitializeComponents();
		}
		private void InitializeComponents()
		{
			AddView(Button.Create("Назад", 55, 20, 100, 30, Color.FromArgb(60, 140, 210), 
				Color.FromArgb(255, 255, 255), new Font("Arial", 12)).AddListenerClick(view =>
			{
				Intent.Create(this, new MainScreen(), 10, 0).Start(StateIntent.RunningHide, true);
			}));
		}
		public override void Render()
		{
			Game.Graphics.Begin(Color.FromArgb(50, 50, 50));
			Update();
			base.Render();
			Intent.Draw();
			Game.Graphics.End();
		}
		private void Update()
		{
			Dot M = Game.Input.PoolMouse.GetLastMove();
			System.Drawing.Graphics gr = Game.Graphics.Get();

			Dot[] ds2;
			ds2 = DotMath.RotateFrom(ds, DotMath.PolygonCenter(ds), (float)System.Environment.TickCount / 5000f);
			ds2 = DotMath.Translate(ds2, new Dot(100f, 80f));
			ds2 = DotMath.ScaleFrom(ds2, DotMath.PolygonCenter(ds2), 2f);
			if (DotMath.IsDotInPolygon(ds2, M))
			{
				gr.FillPolygon(new SolidBrush(Color.White), Dot.ToPoints(ds2));
			}
			gr.DrawPolygon(new Pen(Color.White, 1), Dot.ToPoints(ds2));

			Pen p = new Pen(Color.White, 1);
			Dot X = DotMath.DotClosestPolygon(ds2, M);

			Dot NV = X - M;
			NV = NV.GetUnitVector();
			NV.P += (float)System.Math.PI / 2f;
			NV.L *= 20f;

			Dot OX = new Dot(20f, 0f);

			gr.DrawLine(new Pen(Color.White, 1), X, M);
			gr.DrawLine(new Pen(Color.White, 1), M - NV, M + NV);
			gr.DrawLine(new Pen(Color.White, 1), M - OX, M + OX);
			float sangle = DotMath.StraightsAngle(new Dot(), NV, new Dot(), OX);
			gr.DrawArc(new Pen(Color.White, 1), new RectangleF(M.X - 20f, M.Y - 20f, 40f, 40f), 0f, (float)(System.Math.PI - (sangle * (360f / (System.Math.PI * 2f)))));
			if (X != null)
			{
				gr.FillEllipse(new SolidBrush(Color.Black), X.X - 3, X.Y - 3, 6, 6);
				gr.DrawEllipse(new Pen(Color.White, 1), X.X - 3, X.Y - 3, 6, 6);
			}
			gr.DrawString("Angle: " + (sangle * (360f / (System.Math.PI * 2f))).ToString(), new Font("Arial", 10), new SolidBrush(Color.White), new Point(0, 260));
			gr.DrawString("Distance: " + DotMath.Distance(X, M).ToString(), new Font("Arial", 10), new SolidBrush(Color.White), new Point(0, 280));

			gr.DrawString("LMDMono2D.DotMath V1.1 Release", new Font("Arial", 10), new SolidBrush(Color.White), new Point(180, 280));
			
		}
		public override void Dispose()
		{
			base.Dispose();
		}
	}
}
