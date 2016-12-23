using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Screens
{
	public abstract class Intent : IDisposable
	{
		public StateIntent State { get; set; }
		public float Velocity { get; set; }
		public float StartValue { get; set; }
		protected GameEngine.Game game { get; set; }
		public Intent(GameEngine.Game game)
		{
			State = StateIntent.Initialized;
			this.game = game;
			Velocity = 0.0f;
		}
		public Intent Create(float velocity, float startValue)
		{
			this.Velocity = velocity;
			this.StartValue = startValue;
			return this;
		}
		public abstract void Draw();
		public void Start(StateIntent state)
		{
			State = state;
		}

		public abstract void Dispose();
	}
}
