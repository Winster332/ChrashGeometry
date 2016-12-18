using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrashGeometry.GameEngine;
using CrashGeometry.Views;
using Color = System.Drawing.Color;

namespace CrashGeometry.Screens
{
	public class MainScreen : BaseScreen
	{
		public override void Create()
		{
			Button button = new Button();
			button.Position = new LMDMono2D.Dot(Game.GetForm().Width / 2, Game.GetForm().Height / 2);
			button.AddListenerClick((view)=>
			{
				Console.WriteLine("Click");
			});
			AddView(button);

			Text text = new Text();
			text.Position = new LMDMono2D.Dot(100, 100);
			AddView(text);

		}
		public override void Render()
		{
			Game.Graphics.Begin(Color.FromArgb(50, 50, 50));
			base.Render();
			Game.Graphics.End();
		}
		public override void Dispose()
		{
		}
	}
}
