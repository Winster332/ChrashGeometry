using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashGeometry.Models.Collision
{
	public interface ListenerCollision
	{
		void Collision(Contact contact);
	}
}
