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
		public bool IsEnableCamera { get; set; }
		protected Game Game { get; set; }
		protected List<Action<View>> Clicks;
		public View AddListenerClick(Action<View> eventClick)
		{
			this.Clicks.Add(eventClick);
			return this;
		}
		public void RemoveListenerClick(int index)
		{
			this.Clicks.RemoveAt(index);
		}
		public float X
		{
			get
			{
				return Position.X;
			}
			set
			{
				if (IsEnableCamera)
					Position.X = value + Game.Graphics.Camera.X;
				else Position.X = value;
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
				if (IsEnableCamera)
					Position.Y = value + Game.Graphics.Camera.Y;
				else Position.Y = value;
			}
		}
		public Dot Position { get; set; }
		public View()
		{
			IsEnableCamera = false;
			Position = new Dot(0, 0);
			Clicks = new List<Action<View>>();
		}
		public void Initialize(Game game)
		{
			this.Game = game;
			Loaded();
		}
		protected abstract void Loaded();
		public abstract void Draw();
		public abstract void Dispose();
	}
}
