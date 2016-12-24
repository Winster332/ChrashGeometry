using CrashGeometry.GameEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Screens
{
	public class WorkspaceScreen : BaseScreen
	{
		public override void Create()
		{
			Console.WriteLine("!!!");
			Intent = new IntentWhiteBlack(Game);
			Intent.Create(this, null, 5, 255).Start(StateIntent.RunningShow, false);
		}
		public override void Render()
		{
			Game.Graphics.Begin(Color.FromArgb(50, 50, 50));
			base.Render();
			Intent.Draw();
			Game.Graphics.End();
		}
		public override void Dispose()
		{
			base.Dispose();
		}
	}
}
