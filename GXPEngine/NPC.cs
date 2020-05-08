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

        float _speed = 3;
        float _moveTime;
        float _moveTimeMax = 200;

        public NPC(float x, float y) : base(97, 28)
        {
            Sprite NPCSprite = new Sprite("textures/silhoutte.png", false, false);
            NPCSprite.y -= NPCSprite.height - height;
            AddChild(NPCSprite);

            this.x = x;
            this.y = y;
            _moveTime = _moveTimeMax;
        }

        public void Update()
        {
            determineMovementPattern();
        

            if(_moveTime <= 0)
            {
                _moveTime = _moveTimeMax;
            }
            _moveTime--;
        }


        public string GetMovementPattern()
        {
            return _movePattern;
        }

        public void SetMovementPattern(string newMPNumber)
        {
            _movePattern = newMPNumber;
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
            int c = 0;
            if(c == 0)
            {
                c = 1;
            }

            if(_moveTime < _moveTimeMax/2)
            {
                c = -c;
            }

            switch (c)
            {
                case 1:
                    Move(_speed, 0);
                    break;
                case -1:
                    Move(-_speed, 0);
                    break;
            }
        }

        private void movementPatternUpDown()
        {
            int c = 0;
            if (c == 0)
            {
                c = 1;
            }

            if (_moveTime < _moveTimeMax / 2)
            {
                c = -c;
            }

            switch (c)
            {
                case 1:
                    Move(0, _speed);
                    break;
                case -1:
                    Move(0, -_speed);
                    break;
            }
        }private void movementPatternSquare()
        {
            if(_moveTime <= _moveTimeMax && _moveTime + 1 >= (_moveTimeMax/4) * 3)
                    Move(_speed, 0); //right

            else if(_moveTime <= (_moveTimeMax/4) * 3 && _moveTime + 1 >= _moveTimeMax/2)
                    Move(0, -_speed); //up

            else if(_moveTime <= _moveTimeMax/2 && _moveTime + 1 >= _moveTimeMax/4)
                    Move(-_speed, 0); //left

            else if(_moveTime <= _moveTimeMax/4 && _moveTime >= 0)
                    Move(0, _speed); //down

            
        }
    }
}
