using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.GameEngine
{
	public abstract class BaseScreen : IDisposable
	{
		protected List<Views.View> Views { get; set; }
		protected Game Game { get; set; }
		public BaseScreen()
		{
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
				Views[i].Draw();
		}
		public void SetGame(Game game) => this.Game = game;
		public abstract void Create();
		public virtual void Render()
		{
			DrawView();
		}
		public abstract void Dispose();
	}
}
