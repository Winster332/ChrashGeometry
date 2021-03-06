﻿using CrashGeometry.GameEngine;
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
		public void MainForm_Load(object sender, EventArgs e)
		{
			game = new Game(this);
			game.SetScreen(new Screens.MainScreen());
			timer.Start();
		}
		public void Timer_Tick(object sender, EventArgs e)
		{
			game.Update();
		}
	}
}
