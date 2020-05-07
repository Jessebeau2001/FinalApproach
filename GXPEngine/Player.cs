using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Player : Pivot
	{
		public Vec2 position {
			get {
				return _position;
			}
		}

		public Vec2 force;
		public Vec2 velocity;

		Vec2 _position;
		float _speed = 22;
		float _controlTimer = 20;
		float _controlTimerDefault = 80;

		public Player(float x, float y) : base()
		{
			Sprite playerSprite = new Sprite("textures/alphaPlayer.png", false);
			playerSprite.SetOrigin(playerSprite.width / 2, playerSprite.height / 2);
			AddChild(playerSprite);

			playerSprite.scale = 1;
		}

		void Update()
		{
			if (_controlTimer < 0)
			{
				Control();
			}
			velocity += force;
			velocity *= Time.deltaTime / 10;
			_position += velocity;

			x = _position.x;
			y = _position.y;

			force *= 0f;
			velocity *= 0.80f;

			_controlTimer--;
		}

		void Control()
		{
			if (Input.GetKey(Key.W))
			{
				force.y -= 1;
				_controlTimer = _controlTimerDefault;
			}

			else if (Input.GetKey(Key.S))
			{
				force.y += 1;
				_controlTimer = _controlTimerDefault;
			}

			else if (Input.GetKey(Key.A))
			{
				force.x -= 1;
				_controlTimer = _controlTimerDefault;
			}

			else if (Input.GetKey(Key.D))
			{
				force.x += 1;
				_controlTimer = _controlTimerDefault;
			}

			force.Normalize();
			force *= _speed;
			Console.WriteLine(Time.deltaTime);
		}
	}
}
