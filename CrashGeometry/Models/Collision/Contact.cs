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
		public Dot Position { get; set; }
		public Model Model1 { get; set; }
		public Model Model2 { get; set; }
		public Contact(Dot position, Model m1, Model m2)
		{
			this.Position = position;
			this.Model1 = m1;
			this.Model2 = m2;
		}
	}
}
