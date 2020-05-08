using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Player : EasyDraw
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

		Inventory playerInv = new Inventory(5);

		public Player(float x, float y) : base(97, 20)
		{
			Sprite playerSprite = new Sprite("textures/alphaPlayer.png", false, false);
			playerSprite.y -= playerSprite.height - height;
			AddChild(playerSprite);
			
			ShapeAlign(CenterMode.Min, CenterMode.Min);
			NoFill();
			Stroke(245, 66, 66);
			Rect(0, 0, width - 1, height - 1);

			AddChild(playerInv);
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
				playerInv.PickUp("grapes");
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

			if (Input.GetKeyDown(Key.SPACE))
				playerInv.PrintContents();

			force.Normalize();
			force *= _speed;
		}
	}
}
