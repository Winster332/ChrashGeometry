using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;
using CrashGeometry.GameEngine;
using LMDMono2D;

namespace CrashGeometry.Views
{
	public abstract class View : IDisposable
	{
		protected Game Game { get; set; }
		protected List<Action<View>> Clicks;
		public void AddListenerClick(Action<View> eventClick)
		{
			this.Clicks.Add(eventClick);
		}
		public float X
		{
			get
			{
				return Position.X;
			}
			set
			{
				Position.X = value;
			}
		}
		public float Y
		{
			get
			{
				return Position.Y;
			}
			set
			{
				Position.Y = value;
			}
		}
		public Dot Position { get; set; }
		public View()
		{
			Position = new Dot(0, 0);
			Clicks = new List<Action<View>>();
		}
		public void Initialize(Game game)
		{
			this.Game = game;
		}
		public abstract void Draw();
		public abstract void Dispose();
	}
}
