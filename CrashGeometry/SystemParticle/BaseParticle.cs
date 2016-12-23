using CrashGeometry.Models;
using LMDMono2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.SystemParticle
{
	public abstract class BaseParticle : Model
	{
		public bool IsDead { get; internal set; }
		public Dot Velocity { get; set; }

		protected BaseParticle()
		{
			Velocity = new Dot(0, 0);
		}

		public abstract void Update();
	}
}
