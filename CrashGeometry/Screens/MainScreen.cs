using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrashGeometry.GameEngine;
using Color = System.Drawing.Color;

namespace CrashGeometry.Screens
{
	public class MainScreen : BaseScreen
	{
		public override void Create()
		{
		}
		public override void Render()
		{
			base.Render();

			Game.Graphics.Begin(Color.FromArgb(50, 50, 50));

			Game.Graphics.End();
		}
		public override void Dispose()
		{
		}
	}
}
