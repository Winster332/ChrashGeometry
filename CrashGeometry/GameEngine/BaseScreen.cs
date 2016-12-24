using CrashGeometry.Models.Collision;
using CrashGeometry.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.GameEngine
{
	public abstract class BaseScreen : IDisposable
	{
		protected Intent Intent { get; set; }
		protected List<Views.View> Views { get; set; }
		protected Game Game { get; set; }
		public Solver Solver { get; set; }
		public BaseScreen()
		{
			Solver = new Solver();
			Views = new List<CrashGeometry.Views.View>();
		}
		public void AddView(Views.View view)
		{
			view.Initialize(Game);
			this.Views.Add(view);
		}
		private void DrawView()
		{
			for (int i = 0; i < Views.Count; i++)
			{
				Views[i].Draw();

				if (IsModel(Views[i]))
					CheckSolver((Models.Model)Views[i]);
			}
		}
		private void CheckSolver(Models.Model model1)
		{
			for (int i = 0; i < Views.Count; i++)
			{
				if (IsModel(Views[i]))
				{
					Models.Model model2 = (Models.Model)Views[i];

					if (model1 != model2)
					{
						Solver.IsCollision(model1, model2);
					}
				}
            }
        }
		private bool IsModel(Views.View view)
		{
			if (view.GetType() == typeof(Models.Model))
				return true;
			else return false;
        }
		public void SetGame(Game game)
		{
			this.Game = game;
		}
		public abstract void Create();
		public virtual void Render()
		{
			DrawView();
		}
		public virtual void Dispose()
		{
			Views.Clear();
		}
	}
}
