using CrashGeometry.Models;
using LMDMono2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.SystemParticle
{
	public class SystemParticleFire : BaseSystemParticle
	{
		private Random rand;
		public SystemParticleFire(GameEngine.Game game) : base(game)
		{
			rand = new Random();
		}

		public override void Add(float x, float y, int count = 1)
		{
			for (int i = 0; i < count; i++)
			{
				float radius = rand.Next(20, 50);
				float velScale = rand.Next(1, 5);
				int velAlpha = rand.Next(5, 10);
				int alpha = rand.Next(100, 150);
				Color color = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
				Dot velocity = GenerateLength(x, y, 0.8f * rand.Next());
				TypeDrawing typeDrawing = TypeDrawing.Fills;

				Particles.Add(ParticleCircle.Create(x, y, radius, velScale, velAlpha, alpha, color, velocity, typeDrawing));
			}
		}

		public Dot GenerateLength(float x, float y, float length)
		{
			Dot d = new Dot();
			d.X = (float)Math.Cos(x) * length;
			d.Y = (float)Math.Sin(y) * length;
			return d;
		}
	}
}
