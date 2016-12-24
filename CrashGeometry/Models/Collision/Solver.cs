using LMDMono2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Models.Collision
{
	public class Solver : IDisposable
	{
		private List<ListenerCollision> collisions;
		public Solver()
		{
			collisions = new List<ListenerCollision>();
		}
		public void AddListenerCollision(ListenerCollision listenerCollisions)
		{
			collisions.Add(listenerCollisions);
		}
		public void RemoveListenerCollision(ListenerCollision listenerCollisions)
		{
			collisions.Remove(listenerCollisions);
		}
		public void RemoveListenerCollision(int index)
		{
			collisions.RemoveAt(index);
		}
		public Contact IsCollision(Model m1, Model m2)
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

		public Contact IsCollisionCirclePolygon(Circle m1, Polygon m2)
		{
			Contact contact = new Contact();

			for (int i = 0, j = 1; i < m1.Verteces.Length; j = i++)
			{
				Dot point = m1.Verteces[i];

				if (DotMath.IsDotInPolygon(m2.Verteces, point))
				{
					contact.IsCollision = true;
					contact.Model1 = m1;
					contact.Model2 = m2;
					contact.Position = m1.Position;

					GenerateListenerCollision(contact);
				}
			}

			return contact;
		}
		public Contact IsCollisionCircles(Circle m1, Circle m2)
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

				GenerateListenerCollision(contact);
			}

			return contact;
		}
		public Contact IsCollisionPolygons(Polygon m1, Polygon m2)
		{
			Contact contact = new Contact();

			for (int i = 0, j = 1; i < m1.Verteces.Length; j=i++)
			{
				Dot point1 = m1.Verteces[i];
				Dot point2 = m1.Verteces[j];

				if (DotMath.IsDotInPolygon(m2.Verteces, point1))
				{
					Dot positionContact = GetPositionContact(point1, point2, m2);

					contact.IsCollision = true;
					contact.Model1 = m1;
					contact.Model2 = m2;
					contact.Position = positionContact;

					GenerateListenerCollision(contact);
				}
			}

			return contact;
		}

		public static Dot GetPositionContact(Dot point1, Dot point2, Polygon m2)
		{
			Dot position = new Dot(0, 0);
			Dot centerModel2 = DotMath.PolygonCenter(m2.Verteces);

			for (int i = 0, j = 1; i < m2.Verteces.Length; j=i++)
			{
				Dot A = m2.Verteces[i];
				Dot B = m2.Verteces[j];

				Dot contact = DotMath.StraightsIntersect(A, B, point1, point2);
				//Console.WriteLine("line1: A[" + A.ToString() + "] B[" + B.ToString() + "]");
				//Console.WriteLine("line2: A[" + point1.ToString() + "] B[" + point2 + "]");

				if (contact != null)
				{
					position = contact;
				}
			}

			return position;
		}

		private void GenerateListenerCollision(Contact contact)
		{
			collisions.ForEach(c =>
			{
				c.Collision(contact);
			});
		}

		public void Dispose()
		{
			collisions.Clear();
		}
	}
}
