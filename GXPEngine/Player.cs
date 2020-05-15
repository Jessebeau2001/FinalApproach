using System;
using System.Linq;

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

		Pickup[] itemList;

		AnimationSprite playerSprite = new AnimationSprite("textures/notAnimalCrossing.png", 3, 1, addCollider: false);
		HUDOverlay playerHUD;

		int frame = 0; //For some reason when loading via menu player instantly collides with NPC soo hardcoded this weird bs -Jesse

		public Player(float x, float y, Pickup[] itemList, HUDOverlay playerHUD, Stage stage, bool showBounds = false) : base(100, 20)
		{
			this.itemList = itemList;

			_position.x = x;
			_position.y = y;
			x = _position.x;
			y = _position.y;

			playerSprite.SetOrigin(0, playerSprite.height);
			scaleFactor = (width * 1f) / (playerSprite.width * 1f);
			playerSprite.scale = scaleFactor;  //calculating and setting a scaling so that the player width will always be 100 pixels
			playerSprite.y += height;
			AddChild(playerSprite);
			ShapeAlign(CenterMode.Min, CenterMode.Min);
			NoFill();
			Stroke(245, 66, 66);
			if (showBounds)
				Rect(0, 0, width - 1, height - 1);

			this.playerHUD = playerHUD;
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
			frame++;
		}

		void OnCollision(GameObject other)
		{
			Console.WriteLine("Collided with GameObject: " + other.name);
			if (frame < 10) return; //THIS IF FUCKING BSBSBSBSBSBSBSB
			if (other is Pickup) {
				//inventory.PickUp((other as Pickup).GetItemName());
				playerHUD.shopList.checkItem((other as Pickup).itemIndex);
				(other as Pickup).PickItUp();
				return;
			}

			if (other is NPC)
			{
				(parent as Stage).LoseGame();
			}

			if (other is EasyDraw && other.name == "WinBox")
			{
				if (itemList.All(_itemList => _itemList.isPickedUp))
					(parent as Stage).WinGame();
			}

			var ColInfo = collider.GetCollisionInfo(other.collider);
			_position += ColInfo.normal * ColInfo.penetrationDepth;
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