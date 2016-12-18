using LMDMono2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Models.Collision
{
	public class Solver
	{
		public static Contact IsCollision(Model m1, Model m2)
		{
			Contact contact = new Contact();

			if (m1.GetType() == typeof(Polygon) && m2.GetType() == typeof(Polygon))
				contact = IsCollisionPolygons((Polygon)m1, (Polygon)m2);
			if (m1.GetType() == typeof(Circle) && m2.GetType() == typeof(Circle))
				contact = IsCollisionCircles((Circle)m1, (Circle)m2);
			if (m1.GetType() == typeof(Circle) && m2.GetType() == typeof(Polygon))
				contact = IsCollisionCirclePolygon((Circle)m1, (Polygon)m2);
			if (m2.GetType() == typeof(Circle) && m1.GetType() == typeof(Polygon))
				contact = IsCollisionCirclePolygon((Circle)m2, (Polygon)m1);

			return contact;
		}

		public static Contact IsCollisionCirclePolygon(Circle m1, Polygon m2)
		{
			Contact contact = new Contact();

			return contact;
		}
		public static Contact IsCollisionCircles(Circle m1, Circle m2)
		{
			Contact contact = new Contact();
			float distance = DotMath.Distance(m1.Position, m2.Position);

			if (distance <= m1.Radius + m2.Radius)
			{
				Dot vector = (m1.Position - m2.Position) / 2;
				Dot position = m1.Position + vector;

				contact.IsCollision = true;
				contact.Model1 = m1;
				contact.Model2 = m2;
				contact.Position = position;
			}

			return contact;
		}
		public static Contact IsCollisionPolygons(Polygon m1, Polygon m2)
		{
			Contact contact = new Contact();

			return contact;
		}
	}
}
