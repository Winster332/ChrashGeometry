using CrashGeometry.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.SystemParticle
{
	public abstract class BaseSystemParticle
	{
		public List<BaseParticle> Particles { get; set; }
		protected Game game { get; set; }
		protected BaseSystemParticle(Game game)
		{
			this.game = game;
		}
		public abstract void Add(float x, float y, int count = 1);
		public void Draw()
		{
			for (int i = 0; i < Particles.Count; i++)
			{
				var particle = Particles[i];
				if (particle.IsDead)
				{
					Particles.RemoveAt(i);
					continue;
				}

				particle.Update();
				particle.Draw();
			}
		}
	}
}
