using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.GameEngine
{
	public class PoolMouse
	{
		public List<System.Drawing.PointF> Downs { get; set; }
		public List<System.Drawing.PointF> Ups { get; set; }
		public List<System.Drawing.PointF> Moves { get; set; }
		private int maxPool;
		public PoolMouse()
		{
			Downs = new List<System.Drawing.PointF>();
			Ups = new List<System.Drawing.PointF>();
			Moves = new List<System.Drawing.PointF>();

			SetMaxPool(5);
			//AddDown(0, 0);
			//AddMove(0, 0);
			//AddUp(0, 0);
		}
		public void ClearMouse()
		{
			Downs.Clear();
			Ups.Clear();
			Moves.Clear();
		}
		public void SetMaxPool(int max)
		{
			this.maxPool = max;
		}
		public int GetMaxPool()
		{
			return maxPool;
		}
		public void AddDown(float x, float y)
		{
			if (Downs.Count > GetMaxPool())
				Downs.RemoveAt(0);
			Downs.Add(new System.Drawing.PointF(x, y));
		}
		public void AddUp(float x, float y)
		{
			if (Ups.Count > GetMaxPool())
				Ups.RemoveAt(0);
			Ups.Add(new System.Drawing.PointF(x, y));
		}
		public void AddMove(float x, float y)
		{
			if (Moves.Count > GetMaxPool())
				Moves.RemoveAt(0);
			Moves.Add(new System.Drawing.PointF(x, y));
		}
		public System.Drawing.PointF GetLastDown()
		{
			return Downs[Downs.Count - 1];
		}
		public System.Drawing.PointF GetLastUp()
		{
			return Ups[Ups.Count - 1];
		}
		public System.Drawing.PointF GetLastMove()
		{
			return Moves[Moves.Count - 1];
		}
	}
}
