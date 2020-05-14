using System;
using System.Collections;
using System.Collections.Generic;

namespace GXPEngine
{
    class NPC : EasyDraw
    {
        float _speed = 0.4f;

        public Vec2 position
        {
            get
            {
                return _position;
            }
        }

        private Vec2 _force;
        private Vec2 _velocity;
        private Vec2 _position;

        List<string> movePattern = new List<string>();

		string animState = "v";

        private int d = 1;

        AnimationSprite NPCSprite = new AnimationSprite("textures/notAnimalCrossing.png", 3, 1, addCollider: false); //Needs NPC spritesheet before using, currently uses Player spritesheet

        public NPC(float x, float y) : base(97, 28)
        {
            Sprite NPCSprite = new Sprite("textures/silhoutte.png", false, false);
            NPCSprite.y -= NPCSprite.height - height;
            AddChild(NPCSprite);

            _position.x = x;
            _position.y = y;

            //movePattern = new string[5];

			foreach (string text in movePattern)
				Console.WriteLine($"The string is '{text}'");
        }

        public void Update()
        {
            if (movePattern != null)
            {
                movementController();
            }
            x = _position.x;
            y = _position.y;

            _force *= 0f;
            _velocity *= 0.9f;

            if (x < 0 || x > game.width || y < 0 || y > game.height)
            {
                d = -d;
                _velocity *= -1;
            }
        }

        void InitializeMovePattern()
		{
			movePattern.Add(">");
			movePattern.Add("v");
			movePattern.Add("<");
			movePattern.Add("^");
		}

		public void OnCollision(GameObject other)
        {
            if (other is EasyDraw && other.name == "colBox")
            {
                var ColInfo = collider.GetCollisionInfo(other.collider);
                _position += ColInfo.normal * ColInfo.penetrationDepth;

                d = -d;
                _velocity *= -1;
            }
        }


        private void CheckPattern()
        {
            switch (movePattern[0])
			{
				case ">":
					x++;
					break;
				case "<":
					x--;
					break;
				case "v":
					y++;
					break;
				case "^":
					y--;
					break;

			}
		}


            //for (int i = 0; i == movePattern.Length; i++)
            //{
            //    for (int o = 0; o >= 60; o += o / Time.deltaTime)
            //    {
            //        string direction = movePattern[i];
            //
            //        switch (direction)
            //        {
            //            case "U":
            //                _force.y -= 1;
            //                break;
            //            case "D":
            //                _force.y += 1;
            //                break;
            //            case "L":
            //                _force.x -= 1;
            //                break;
            //            case "R":
            //                _force.x += 1;
            //                break;
            //        }
            //    }
            //}
            //}


        private void movementController()
        {
            _force.Normalize();
            _force *= _speed;

            //AnimationHandeler();

            _velocity += _force;
            _velocity *= Time.deltaTime / 10;
            //Console.WriteLine("Velocity = " + velocity);
            _position += _velocity;
        }

        public void SetState(string state)
        {
            animState = state;
        }

        private void AnimationHandeler()
        {
            switch (animState)
            {
                case "v":
                    NPCSprite.SetFrame(0);
                    break;
                case "<":
                    NPCSprite.SetFrame(2);
                    NPCSprite.Mirror(false, false);
                    break;
                case ">":
                    NPCSprite.SetFrame(2);
                    NPCSprite.Mirror(true, false);
                    break;
                case "^":
                    NPCSprite.SetFrame(1);
                    break;
            }
        }

        public List<string> GetMovePattern()
        {
            return movePattern;
        }
    }
}
