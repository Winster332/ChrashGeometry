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

			for (int i = 0; i < m1.Verteces.Length; i++)
			{
				Dot point = m1.Verteces[i];

				if (DotMath.IsDotInPolygon(m2.Verteces, point))
				{
					Dot positionContact = GetPositionContact(point, m2);

					contact.IsCollision = true;
					contact.Model1 = m1;
					contact.Model2 = m2;
					contact.Position = positionContact;
				}
			}

			return contact;
		}

		public static Dot GetPositionContact(Dot point, Polygon m2)
		{
			Dot position = new Dot(0, 0);
			Dot centerModel2 = DotMath.PolygonCenter(m2.Verteces);

			for (int i = 0, j = 1; i < m2.Verteces.Length; j=i++)
			{
				Dot A = m2.Verteces[i];
				Dot B = m2.Verteces[j];

				Dot contact = DotMath.StraightsIntersect(A, B, point, centerModel2);
				if (contact != null)
					position = contact;
			}

			return position;
		}
	}
}
