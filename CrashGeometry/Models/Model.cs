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
		private new float X;
		private new float Y;
		public TypeDrawing TypeDrawing { get; set; }
		public System.Drawing.Color Color { get; set; }
		public Dot[] Verteces { get; set; }
		public int SizeLine { get; set; }
		public Model()
		{
			TypeDrawing = TypeDrawing.Fills;
			Color = System.Drawing.Color.White;
			SizeLine = 1;
			IsEnableCamera = true;
		}
		protected abstract override void Loaded();
		public abstract override void Draw();
		public abstract override void Dispose();
	}
}
