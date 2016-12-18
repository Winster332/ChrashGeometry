using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.GameEngine
{
	public class Input
	{
		private Game game;
		public PoolKeyboard PoolKeyboard { get; set; }
		public PoolMouse PoolMouse { get; set; }
		public Input(Game game)
		{
			this.game = game;

			this.PoolKeyboard = new PoolKeyboard();
			this.PoolMouse = new PoolMouse();

			this.game.Graphics.GetPicture().MouseDown += Input_MouseDown;
			this.game.Graphics.GetPicture().MouseUp += Input_MouseUp;
			this.game.Graphics.GetPicture().MouseMove += Input_MouseMove;
			this.game.GetForm().KeyDown += Input_KeyDown;
			this.game.GetForm().KeyUp += Input_KeyUp;
		}
		public void Update()
		{
			PoolKeyboard.Clear();
		}
		private void Input_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			PoolKeyboard.AddUp(e.KeyCode);
		}
		private void Input_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			PoolKeyboard.AddDown(e.KeyCode);
		}
		private void Input_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.PoolMouse.AddMove(e.X, e.Y);
		}
		private void Input_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.PoolMouse.AddUp(e.X, e.Y);
		}
		private void Input_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.PoolMouse.AddDown(e.X, e.Y);
		}
	}
}
