﻿using CrashGeometry.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Screens
{
	public abstract class Intent : IDisposable
	{
		protected BaseScreen screen1;
		protected BaseScreen screen2;
		public StateIntent State { get; set; }
		public float Velocity { get; set; }
		public float CurrentValue { get; set; }
		public float StartValue { get; set; }
		protected GameEngine.Game game { get; set; }
		public Intent(GameEngine.Game game)
		{
			State = StateIntent.Initialized;
			this.game = game;
			Velocity = 0.0f;
		}
		public Intent Create(BaseScreen s1, BaseScreen s2, float velocity, float startValue)
		{
			this.screen1 = s1;
			this.screen2 = s2;
			this.Velocity = velocity;
			this.StartValue = startValue;
			return this;
		}
		public void UseIntent()
		{
			game.SetScreen(screen2);
		}
		public abstract void Draw();
		public void Start(StateIntent state)
		{
			State = state;
		}

		public abstract void Dispose();
	}
}
