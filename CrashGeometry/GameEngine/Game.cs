using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.GameEngine
{
	public class Game
	{
		public Graphics Graphics { get; set; }
		public Input Input { get; set; }
		private System.Windows.Forms.Form form;
		private BaseScreen activeScreen;
		public Game(System.Windows.Forms.Form form)
		{
			this.form = form;

			Graphics = new Graphics();
			Graphics.Initialize(form);

			Input = new Input(this);
		}
		public void SetScreen(BaseScreen screen)
		{
			if (activeScreen != null)
				activeScreen.Dispose();
			screen.SetGame(this);
			screen.Create();
			this.activeScreen = screen;
		}
		public BaseScreen GetScreen()
		{
			return activeScreen;
		}
		public System.Windows.Forms.Form GetForm()
		{
			return form;
		}
		public void Update()
		{
			activeScreen.Render();
			Input.Update();
		}
	}
}
