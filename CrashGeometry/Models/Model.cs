using LMDMono2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Models
{
	public abstract class Model : Views.View
	{
		private new Dot Position;
		private Dot[] Verteces;
		protected new List<Action<Views.View>> Clicks;

		protected abstract override void Loaded();
		public abstract override void Draw();
		public abstract override void Dispose();
	}
}
