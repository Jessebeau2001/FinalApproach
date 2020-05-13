using GXPEngine.Core;
using GXPEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace GXPEngine
{
    class NPC : EasyDraw
    {
        string _movePattern;

        float _speed = 1;

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

        string animState = "v";

        private bool _bounce = false;
        private string _direction = "";

        AnimationSprite NPCSprite = new AnimationSprite("textures/notAnimalCrossing.png", 3, 1, addCollider: false); //Needs NPC spritesheet before using, currently uses Player spritesheet

        public NPC(float x, float y) : base(97, 28)
        {
            Sprite NPCSprite = new Sprite("textures/silhoutte.png", false, false);
            NPCSprite.y -= NPCSprite.height - height;
            AddChild(NPCSprite);

            _position.x = x;
            _position.y = y;
        }

        public void Update()
        {
            determineMovementPattern();

            movementController();
            //if(_moveTime <= 0)
            //{
            //    _moveTime = _moveTimeMax;
            //}
            //_moveTime -= Time.deltaTime / 10;

            x = _position.x;
            y = _position.y;

            _force *= 0f;
            _velocity *= 0.9f;

            setDirection();
        }

        public void OnCollision(Pivot other)
        {
            if(other is StageColliders)
            {
                _bounce = true;
            }
        }

        private void setDirection()
        {
            if (_velocity.x < 0 && _velocity.y == 0)
            {
                _direction = "left";
            }
            if (_velocity.x > 0 && _velocity.y == 0)
            {
                _direction = "right";
            }
        }

        public string GetMovementPattern()
        {
            return _movePattern;
        }

        public void SetMovementPattern(string newMP)
        {
            _movePattern = newMP;
        }

        private void determineMovementPattern()
        {
            switch (GetMovementPattern())
            {
                case "LR":
                    movementPatternLeftRight();
                    break;
                case "UD":
                    movementPatternUpDown();
                    break;
                case "SQ":
                    movementPatternSquare();
                    break;
            }
        }

        private void movementPatternLeftRight()
        {
            //int c = 0;
            //if(c == 0)
            //{
            //    c = 1;
            //}

            //if(_moveTime < _moveTimeMax/2)
            //{
            //    c = -c;
            //}

            //switch (c)
            //{
            //    case 1:
            //        MoveUntilCollision(_speed, 0);

            //        break;
            //    case -1:
            //        MoveUntilCollision(-_speed, 0);
            //        break;
            //}

            _force.x += _speed;

            if (_bounce)
            {
                if (_direction == "left")
                {
                    SetState("<");
                }
                if (_direction == "right")
                {
                    SetState(">");
                }
            }
        }

        private void movementPatternUpDown()
        {
            //int c = 0;
            //if (c == 0)
            //{
            //    c = 1;
            //}

            //if (_moveTime < _moveTimeMax / 2)
            //{
            //    c = -c;
            //}

            //switch (c)
            //{
            //    case 1:
            //        Move(0, _speed);
            //        break;
            //    case -1:
            //        Move(0, -_speed);
            //        break;
            //}

            if (!_bounce)
            {
                _force.y -= 1;
                SetState("^");
            }

            if (_bounce)
            {
                _force.y += 1;
                SetState("v");
            }
        }
        private void movementPatternSquare()
        {
            //if(_moveTime <= _moveTimeMax && _moveTime + 1 >= (_moveTimeMax/4) * 3)
            //        Move(_speed, 0); //right

            //else if(_moveTime <= (_moveTimeMax/4) * 3 && _moveTime + 1 >= _moveTimeMax/2)
            //        Move(0, -_speed); //up

            //else if(_moveTime <= _moveTimeMax/2 && _moveTime + 1 >= _moveTimeMax/4)
            //        Move(-_speed, 0); //left

            //else if(_moveTime <= _moveTimeMax/4 && _moveTime >= 0)
            //        Move(0, _speed); //down
        }

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
    }
}
