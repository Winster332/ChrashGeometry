using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrashGeometry.Models;
using CrashGeometry.Models.Collision;
using LMDMono2D;
using System.Drawing;

namespace TestCrashGeometry
{
	[TestClass]
	public class TestSolver :  IDisposable
	{
		private CrashGeometry.GameEngine.Game game;
		private CrashGeometry.MainForm form;
        private bool IsSetup = false;
		public void Setup()
		{
			if (!IsSetup)
			{
				IsSetup = true;
				form = new CrashGeometry.MainForm();
				form.MainForm_Load(null, null);
				game = new CrashGeometry.GameEngine.Game(form);
			}
		}
		public void SimulationGameLife(int step)
		{
			Setup();

			for (int i = 0; i < step; i++)
				form.Timer_Tick(null, null);
		}
		[TestMethod]
		public void TestCollisionCircles()
		{
			Setup();

			Circle circle1 = Circle.Create(game, 100, 100, 50, Color.White);
			Circle circle2 = Circle.Create(game, 120, 100, 50, Color.White);

			form.game.GetScreen().AddView(circle1);
			form.game.GetScreen().AddView(circle2);

			SimulationGameLife(5);

			Contact contact = new Solver().IsCollisionCircles(circle1, circle2);
			Console.WriteLine(contact.ToString());

			Assert.IsTrue(contact.IsCollision);
		}
		[TestMethod]
		public void TestCollisionPolygons()
		{
			Setup();

			RectangleF rect1 = new RectangleF(0, 0, 100, 100);
			RectangleF rect2 = new RectangleF(50, 50, 100, 100);

			Polygon polygon1 = Polygon.Create(game, new Dot[]
			{
				new Dot(rect1.X-rect1.Width/2, rect1.Y-rect1.Height/2),
				new Dot(rect1.X+rect1.Width/2, rect1.Y-rect1.Height/2),
				new Dot(rect1.X+rect1.Width/2, rect1.Y+rect1.Width/2),
				new Dot(rect1.X-rect1.Width/2, rect1.Y+rect1.Width/2)
			}, TypeDrawing.Fills, Color.White);

			Polygon polygon2 = Polygon.Create(game, new Dot[] 
			{
				new Dot(rect2.X-rect2.Width/2, rect2.Y-rect2.Height/2),
				new Dot(rect2.X+rect2.Width/2, rect2.Y-rect2.Height/2),
				new Dot(rect2.X+rect2.Width/2, rect2.Y+rect2.Width/2),
				new Dot(rect2.X-rect2.Width/2, rect2.Y+rect2.Width/2)
			}, TypeDrawing.Fills, Color.White);

			form.game.GetScreen().AddView(polygon1);
			form.game.GetScreen().AddView(polygon2);

			SimulationGameLife(5);

			Contact contact = new Solver().IsCollisionPolygons(polygon1, polygon2);
			Console.WriteLine(contact.ToString());

			Assert.IsTrue(contact.IsCollision);
		}
		[TestMethod]
		public void TestCollisionPolygonCircle()
		{
			Setup();

			RectangleF rect = new RectangleF(0, 0, 100, 100);

			Polygon polygon = Polygon.Create(game, new Dot[]
			{
				new Dot(rect.X-rect.Width/2, rect.Y-rect.Height/2),
				new Dot(rect.X+rect.Width/2, rect.Y-rect.Height/2),
				new Dot(rect.X+rect.Width/2, rect.Y+rect.Width/2),
				new Dot(rect.X-rect.Width/2, rect.Y+rect.Width/2)
			}, TypeDrawing.Fills, Color.White);

			Circle circle = Circle.Create(game, 120, 100, 50, Color.White);

			form.game.GetScreen().AddView(circle);
			form.game.GetScreen().AddView(polygon);

			SimulationGameLife(5);

			Contact contact = new Solver().IsCollisionCircles(circle, circle);
			Console.WriteLine(contact.ToString());

			Assert.IsTrue(contact.IsCollision);
		}

		public void Dispose()
		{
			form.Dispose();
		}
	}
}
