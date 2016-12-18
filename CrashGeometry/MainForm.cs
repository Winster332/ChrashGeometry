using CrashGeometry.GameEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrashGeometry
{
	public partial class MainForm : Form
	{
		public Timer timer { get; set; }
		public Game game { get; set; }
		public MainForm()
		{
			InitializeComponent();



			timer = new Timer();
			timer.Interval = 30;
			timer.Tick += Timer_Tick;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (game.Input.PoolKeyboard.Downs.Count > 0)
				Console.WriteLine("" + game.Input.PoolKeyboard.GetDown(Keys.A));
			game.Update();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			game = new Game(this);
			timer.Start();


		}
	}
}
