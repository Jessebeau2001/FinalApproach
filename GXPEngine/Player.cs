using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Player : Sprite
	{
		public Vec2 position {
			get {
				return _position;
			}
		}

		public Vec2 force;
		public Vec2 velocity;

		Vec2 _position;
		float _speed = 1;

		CollisionManager colMan = new CollisionManager();

		public Player(float x, float y) : base("textures/alphaPlayer.png", false, true)
		{
			EasyDraw col = new EasyDraw(width, height, false);
			col.ShapeAlign(CenterMode.Min, CenterMode.Min);
			col.NoFill();
			col.Stroke(245, 66, 66);
			col.Rect(0, 0, col.width - 1, col.height - 1);
			AddChild(col);
		}

		void Update()
		{
			Control();
			velocity += force;
			velocity *= Time.deltaTime / 10;
			_position += velocity;

			x = _position.x;
			y = _position.y;

			force *= 0f;
			velocity *= 0.9f;
		}

		void OnCollision(GameObject other)
		{
			if (other is Pickup) {
				other.LateDestroy();
				return;
			}

			var ColInfo = collider.GetCollisionInfo(other.collider);
			_position += ColInfo.normal * ColInfo.penetrationDepth;

			Console.WriteLine("Collided with GameObject: " + other.name);
		}

		void Control()
		{
			if (Input.GetKey(Key.W))
				force.y -= 1;

			if (Input.GetKey(Key.S))
				force.y += 1;

			if (Input.GetKey(Key.A))
				force.x -= 1;

			if (Input.GetKey(Key.D))
				force.x += 1;

			force.Normalize();
			force *= _speed;
		}
	}
}
