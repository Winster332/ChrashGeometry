using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.GameEngine
{
	public class PoolKeyboard
	{
		public List<System.Windows.Forms.Keys> Downs { get; set; }
		public List<System.Windows.Forms.Keys> Ups { get; set; }
		private int poolMax;
		public PoolKeyboard()
		{
			Downs = new List<System.Windows.Forms.Keys>();
			Ups = new List<System.Windows.Forms.Keys>();
			SetPool(5);
		}
		public int GetMaxPool()
		{
			return poolMax;
		}
		public void SetPool(int max)
		{
			poolMax = max;
		}
		public void AddDown(System.Windows.Forms.Keys key)
		{
			if (Downs.Count > GetMaxPool())
				Downs.RemoveAt(0);
			this.Downs.Add(key);
		}
		public void AddUp(System.Windows.Forms.Keys key)
		{
			if (Ups.Count > GetMaxPool())
				Ups.RemoveAt(0);
			this.Ups.Add(key);
		}
		public void Clear()
		{
			Downs.Clear();
			Ups.Clear();
		}
		public bool GetDown(System.Windows.Forms.Keys key)
		{
			for (int i = 0; i < Downs.Count; i++)
				if (key == Downs[i])
					return true;
			return false;
		}
		public bool GetUp(System.Windows.Forms.Keys key)
		{
			for (int i = 0; i < Ups.Count; i++)
				if (key == Ups[i])
					return true;
			return false;
		}
	}
}
