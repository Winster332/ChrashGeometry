using LMDMono2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.SystemParticle
{
	public class ParticleCircle : BaseParticle
	{
		public float Radius { get; set; }
		public float Width { get; set; }
		public int Alpha { get; set; }
		public int VelocityAlpha { get; set; }
		public float Scale { get; set; }
		public float VelocityScale { get; set; }
		protected override void Loaded()
		{
			VelocityAlpha = 0;
			Scale = 1;
			Alpha = 255;
			Radius = 20;
			Width = 1;
			VelocityScale = 0;
		}
		public override void Update()
		{
			if (Alpha < VelocityAlpha)
				IsDead = true;
			else Alpha -= VelocityAlpha;
			if (Scale < VelocityScale)
				IsDead = true;
			else Scale -= VelocityScale;

			Position += Velocity;
		}	
		public override void Draw()
		{
			var savedTransform = Game.Graphics.Get().Save();
			Game.Graphics.Get().ScaleTransform(Scale, Scale);
			if (TypeDrawing == Models.TypeDrawing.Fills)
				Game.Graphics.Get().FillEllipse(new SolidBrush(Color.FromArgb(Alpha, this.Color)), X-Radius, Y-Radius, Radius*2, Radius*2);
			else if (TypeDrawing == Models.TypeDrawing.Lines)
				Game.Graphics.Get().DrawEllipse(new Pen(Color.FromArgb((int)Width, Color)), X - Radius, Y - Radius, Radius * 2, Radius * 2);
			Game.Graphics.Get().Restore(savedTransform);
		}
		public override void Dispose()
		{

		}
		public static ParticleCircle Create(float x, float y, float rad, float vscale, int valpha, int alpha, Color color, Dot vel, Models.TypeDrawing typeDrawing)
		{
			ParticleCircle p = new ParticleCircle();
			p.X = x;
			p.Y = y;
			p.Radius = rad;
			p.VelocityScale = vscale;
			p.VelocityAlpha = valpha;
			p.Alpha = alpha;
			p.Color = color;
			p.Velocity = vel;
			p.TypeDrawing = typeDrawing;

			return p;
		}
	}
}
