using LMDMono2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Models.Collision
{
	public class Contact
	{
		public bool IsCollision { get; set; }
		public Dot Position { get; set; }
		public Model Model1 { get; set; }
		public Model Model2 { get; set; }
		public Contact(Dot position, Model m1, Model m2)
		{
			this.Position = position;
			this.Model1 = m1;
			this.Model2 = m2;
			this.IsCollision = true;
		}
		public Contact()
		{
			this.IsCollision = false;
		}
		public override string ToString()
		{
			string info = "";
			info += "IsCollision: " + IsCollision;
			if (Position != null)
				info += "\nPosition: " + Position.ToString();
			else info += "\nPosition: null";
			if (Model1 != null)
				info += "\nModel1: " + Model1.ToString();
			else info += "\nModel1: null";
			if (Model2 != null)
				info += "\nModel2: " + Model2.ToString();
			else info += "\nModel2: null";


			return info;
		}
	}
}
