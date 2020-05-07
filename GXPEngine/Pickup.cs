using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Pickup : Sprite
	{
		public Pickup(float x, float y, string texturePath) : base(texturePath, false, true)
		{
			this.x = x;
			this.y = y;
		}

		void PickUp()
		{
			LateDestroy();
		}
	}
}
