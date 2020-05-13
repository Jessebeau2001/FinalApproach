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
		private Vec2 _position;

		Vec2 prevPos;

		float _speed = 1;
		float scaleFactor;

		string animState = "v";

		int timer = 1000;

		bool squish = false;

		public Inventory inventory;

		AnimationSprite playerSprite = new AnimationSprite("textures/notAnimalCrossing.png", 3, 1, addCollider: false);

		public Player(float x, float y, int invSize) : base(100, 20)
		{
			inventory = new Inventory(invSize);
			AddChild(inventory);
			playerSprite.SetOrigin(0, playerSprite.height);
			scaleFactor = (width * 1f) / (playerSprite.width * 1f);
			playerSprite.scale = scaleFactor;  //calculating and setting a scaling so that the player width will always be 100 pixels
			playerSprite.y += height;
			AddChild(playerSprite);
			
			ShapeAlign(CenterMode.Min, CenterMode.Min);
			NoFill();
			Stroke(245, 66, 66);
			Rect(0, 0, width - 1, height - 1);
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

			timer -= Time.deltaTime;
			if (timer <= 0 )
			{
				timer += 1000;
				if (squish)
					playerSprite.scaleY *= .98f;
				else
					playerSprite.scaleY = scaleFactor;

				squish = !squish;
			}


			if (x < 0 || x > game.width || y < 0 || y > game.height)
				_position = prevPos;

			prevPos = _position;
		}

		void OnCollision(GameObject other)
		{
			if (other is Pickup) {
				inventory.PickUp((other as Pickup).GetItemName());
				other.LateDestroy();
				return;
			}

			if (other is NPC)
			{
				LateDestroy();
			}

			var ColInfo = collider.GetCollisionInfo(other.collider);
			_position += ColInfo.normal * ColInfo.penetrationDepth;

			Console.WriteLine("Collided with GameObject: " + other.name);
		}

		private void Control()
		{
			if (Input.GetKey(Key.W)) {
				force.y -= 1;
				SetState("^");
			}
				
			if (Input.GetKey(Key.S)) { 
				force.y += 1;
				SetState("v");
			}

			if (Input.GetKey(Key.A)) {
				force.x -= 1;
				SetState("<");
			}

			if (Input.GetKey(Key.D)) {
				force.x += 1;
				SetState(">");
			}

			if (Input.GetKeyDown(Key.SPACE))
				Console.WriteLine(inventory);
				//inventory.PrintContents();

			force.Normalize();
			force *= _speed;

			AnimationHandeler();
		}

		public void SetState(string state)
		{
			animState = state;
		}

		private void AnimationHandeler()
		{
			switch (animState) {
				case "v":
					playerSprite.SetFrame(0);
					break;
				case "<":
					playerSprite.SetFrame(2);
					playerSprite.Mirror(false, false);
					break;
				case ">":
					playerSprite.SetFrame(2);
					playerSprite.Mirror(true, false);
					break;
				case "^":
					playerSprite.SetFrame(1);
					break;
			}
		}
	}
}
