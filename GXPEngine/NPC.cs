using GXPEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace GXPEngine
{
    class NPC : Sprite
    {
        int _mpNumber;

        float _speed = 5;
        float _moveTime;
        float _moveTimeMax = 100;

        public NPC(float x, float y) : base("textures/silhoutte.png")
        {
            this.x = x;
            this.y = y;
            _moveTime = _moveTimeMax;
        }

        public void Update()
        {
            if(GetMovementPattern() == 1)
            {
                movementPatternLeftRight();
            }
            else if(GetMovementPattern() == 2)
            {
                movementPatternUpDown();
            }

            if(_moveTime <= 0)
            {
                _moveTime = _moveTimeMax;
            }
            _moveTime--;
        }


        public int GetMovementPattern()
        {
            return _mpNumber;
        }

        public void SetMovementPattern(int newMPNumber)
        {
            _mpNumber = newMPNumber;
        }

        private void movementPatternLeftRight()
        {
            int c = 0;
            if(c == 0)
            {
                c = 1;
            }

            if(_moveTime <= _moveTimeMax/2)
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

            if (_moveTime <= _moveTimeMax / 2)
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
        }
    }
}
