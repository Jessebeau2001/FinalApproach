using System;

namespace GXPEngine.Core
{
	public struct Vector2
	{
		public float x;
		public float y;
		
		public Vector2 (float x, float y)
		{
			this.x = x;
			this.y = y;
		}
		
		override public string ToString() {
			return "[Vector2 " + x + ", " + y + "]";
		}

		public static Vector2 operator* (Vector2 left, float multiplier)
		{
			return new Vector2(left.x * multiplier, left.y * multiplier);
		}
	}
}

