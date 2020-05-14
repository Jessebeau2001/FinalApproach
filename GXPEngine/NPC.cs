using System;
using System.Collections;
using System.Collections.Generic;
using TiledMapParser;

namespace GXPEngine
{
    class NPC : EasyDraw
    {
        float speed;

        public Vec2 position
        {
            get { return _position; }
        }

        private Vec2 _position;
        private Vec2 _force;

        List<Vec2> destination = new List<Vec2>();
        int patternIndex = 1;

        public NPC(float x, float y, string[] polyPoints, float speed = 1f) : base(97, 28)
        {
            _position.x = Mathf.Round(x);
            _position.y = Mathf.Round(y);
            this.speed = speed;

            Sprite NPCSprite = new Sprite("textures/silhoutte.png", false, false);
            NPCSprite.y -= NPCSprite.height - height;
            AddChild(NPCSprite);

            InitializePattern(polyPoints);
            foreach (Vec2 pos in destination)
                Console.WriteLine(pos);
        }

        public void Update()
        {
            _position += _force;
            _force *= 0;

            x = _position.x;
            y = _position.y;

            UpdatePattern();
        }

        Vec2 StringToVec(string points)
        {
            string[] xy = points.Split(new char[] {','});
            for (int i = 0; i < xy.Length; i++)
                xy[i] = xy[i].Replace(".", ",");
            return new Vec2(Mathf.Round(float.Parse(xy[0])), Mathf.Round(float.Parse(xy[1])));
        }

        void InitializePattern(string[] polyPoints)
        {
            foreach (string polyPoint in polyPoints)
            {
                destination.Add(_position + StringToVec(polyPoint));
                Console.WriteLine($"Added destination {_position + StringToVec(polyPoint)}");
            }
        }

        void UpdatePattern()
        {
            if (patternIndex > destination.Count  - 1) patternIndex = 0;
            Console.WriteLine($"Heading towards {destination[patternIndex]}, Curently at {_position}");
            Console.WriteLine($"But should be OK if in between {destination[patternIndex] - new Vec2(20, 20)} and {destination[patternIndex] + new Vec2(20, 20)}");

            _force.x = destination[patternIndex].x - _position.x;
            _force.y = destination[patternIndex].y - _position.y;

            _force.Normalize();
            _force *= speed;

            if (_position > destination[patternIndex] - new Vec2(speed, speed))
                if (_position < destination[patternIndex] + new Vec2(speed, speed))
                    patternIndex++; 
        }

        void AnimHandler()
        {
           
        }

        public List<Vec2> GetMovePattern()
        {
            return destination;
        }
    }
}
