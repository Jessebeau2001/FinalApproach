using System;
using System.Collections;
using System.Collections.Generic;

namespace GXPEngine
{
    class NPC : EasyDraw
    {
        float _speed = 1f;

        public Vec2 position
        {
            get { return _position; }
        }

        private Vec2 _position;

        List<Vec2> destination = new List<Vec2>();
        int patternIndex = 0;

        public NPC(float x, float y) : base(97, 28)
        {
            _position.x = x;
            _position.y = y;

            Sprite NPCSprite = new Sprite("textures/silhoutte.png", false, false);
            NPCSprite.y -= NPCSprite.height - height;
            AddChild(NPCSprite);

            SetPattern(1);
        }

        public void Update()
        {
            x = _position.x;
            y = _position.y;

            UpdatePattern();
        }

        void SetPattern(int pattern)
		{
            switch (pattern)
            {
                default:
                    destination.Add(_position + new Vec2(200, 0));
                    destination.Add(destination[destination.Count - 1] + new Vec2(0, 50));
                    destination.Add(destination[destination.Count - 1] + new Vec2(-200, 0));
                    destination.Add(destination[destination.Count - 1] + new Vec2(0, -50));
                    break;
                case 1:
                    destination.Add(_position + new Vec2(200, 40));
                    destination.Add(destination[destination.Count - 1] + new Vec2(0, 50));
                    destination.Add(destination[destination.Count - 1] + new Vec2(-200, -90));
                    break;
            }
		}

        void UpdatePattern()
        {
            if (patternIndex > destination.Count  - 1) patternIndex = 0;
            //Console.WriteLine($"Current pattern index: {patternIndex}");
            //Console.WriteLine($"Position: {_position}, destination: {destination[patternIndex]}");

            _position.x -= _speed * Mathf.Sign(_position.x - destination[patternIndex].x);
            _position.y -= _speed * Mathf.Sign(_position.y - destination[patternIndex].y);

            if (_position == destination[patternIndex]) patternIndex++;
        }

        public List<Vec2> GetMovePattern()
        {
            return destination;
        }
    }
}
