using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Screens
{
	public class IntentWhiteBlack : Intent
	{
		private Color Color { get; set; }
		public IntentWhiteBlack(GameEngine.Game game) : base(game)
		{
			this.Color = Color.Black;
			CurrentValue = 0;
		}
		public override void Draw()
		{
			if (State == StateIntent.RunningShow)
				if (CurrentValue > Velocity)
					Update(-Velocity);
				else
				{
					State = StateIntent.Finished;
					UseIntent();
				}
			else if (State == StateIntent.RunningHide)
				if (CurrentValue < 255 - Velocity)
					Update(Velocity);
				else
				{
					State = StateIntent.Finished;
					UseIntent();
				}

			game.Graphics.Get().FillRectangle(new SolidBrush(Color.FromArgb((int)CurrentValue, Color)), 0, 0, game.GetForm().Width, game.GetForm().Height);
		}
		private void Update(float vel)
		{
			CurrentValue += vel;
		}

		public override void Dispose()
		{
			State = StateIntent.Finished;
		}
	}
}
