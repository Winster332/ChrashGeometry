using LMDMono2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.SystemParticle
{
	public class ParticlePolygon : BaseParticle
	{
		public Dot[] Dots;
		public float Width { get; set; }
		public int Alpha { get; set; }
		public int VelocityAlpha { get; set; }
		public float Scale { get; set; }
		public float VelocityScale { get; set; }
		public override void Dispose()
		{
		}

		public override void Draw()
		{
			var savedTransform = Game.Graphics.Get().Save();
			Game.Graphics.Get().TranslateTransform(X, Y);
			Game.Graphics.Get().ScaleTransform(Scale, Scale);
			if (TypeDrawing == Models.TypeDrawing.Fills)
				Game.Graphics.Get().FillPolygon(new SolidBrush(Color.FromArgb(Alpha, this.Color)), Dot.ToPointFs(Dots));
			else if (TypeDrawing == Models.TypeDrawing.Lines)
				Game.Graphics.Get().DrawPolygon(new Pen(Color.FromArgb((int)Width, Color)), Dot.ToPointFs(Dots));
			Game.Graphics.Get().Restore(savedTransform);
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

		protected override void Loaded()
		{
			VelocityAlpha = 0;
			Scale = 1;
			Alpha = 255;
			Width = 1;
			VelocityScale = 0;
		}

		public static ParticlePolygon Create(Dot[] dots, float x, float y, float vscale, int valpha, int alpha, Color color, Dot vel, Models.TypeDrawing typeDrawing)
		{
			ParticlePolygon p = new ParticlePolygon();
			p.X = x;
			p.Y = y;
			p.VelocityScale = vscale;
			p.VelocityAlpha = valpha;
			p.Alpha = alpha;
			p.Color = color;
			p.Velocity = vel;
			p.TypeDrawing = typeDrawing;
			p.Dots = dots;

			return p;
		}
	}
}
