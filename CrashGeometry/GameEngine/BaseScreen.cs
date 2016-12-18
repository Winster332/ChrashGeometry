using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.GameEngine
{
	public abstract class BaseScreen : IDisposable
	{
		protected Game Game { get; set; }
		public void SetGame(Game game) => this.Game = game;
		public abstract void Create();
		public abstract void Render();
		public abstract void Dispose();
	}
}
