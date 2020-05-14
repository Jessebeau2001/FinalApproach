using System;
using System.Collections.Generic;

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

        AnimationSprite animSprite;
        int startFrame;
        int lastStartFrame;
        int timer = 0;
        int animSpeed = 200;
        public NPC(float x, float y, string[] polyPoints, string spriteName = null, float speed = 1f) : base(50, 185)
        {
            _position.x = Mathf.Round(x) - (width / 2);
            _position.y = Mathf.Round(y) - (height / 2);
            this.speed = speed;

            if (spriteName == null) spriteName = "npc_0.png"; //Sets a default sprite if none was put in -Jesse

            SetOrigin(0, height / 2);

            //ShapeAlign(CenterMode.Min, CenterMode.Min);
            //Rect(0, 0, width, height);

            animSprite = new AnimationSprite("textures/spriteSheets/" + spriteName, 4, 4, -1, true, false); //starts frame is frame 0 -Jesse
            float scaleFactor = (height * 1f) / (animSprite.height * 1f);
            animSprite.scale = scaleFactor;
            animSprite.y -= animSprite.height / 2;
            animSprite.x -= width / 2;
            AddChild(animSprite);

            InitializePattern(polyPoints);
        }

        public void Update()
        {
            _position += _force;
            _force *= 0;

            x = _position.x;
            y = _position.y;

            UpdatePattern();
            SetAnimState();
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                PlayAnim();
                timer += animSpeed;
            }
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
                Console.WriteLine($"Added destination {_position + StringToVec(polyPoint)}"); //keep this for game initialization -Jesse
            }
        }

        void UpdatePattern()
        {
            if (patternIndex > destination.Count  - 1) patternIndex = 0;
            //Console.WriteLine($"Heading towards {destination[patternIndex]}, Curently at {_position}");
            //Console.WriteLine($"But should be OK if in between {destination[patternIndex] - new Vec2(20, 20)} and {destination[patternIndex] + new Vec2(20, 20)}");

            _force.x = destination[patternIndex].x - _position.x;
            _force.y = destination[patternIndex].y - _position.y;

            _force.Normalize();
            _force *= speed;

            if (_position > destination[patternIndex] - new Vec2(speed, speed))
                if (_position < destination[patternIndex] + new Vec2(speed, speed))
                    patternIndex++; 
        }

        void SetAnimState()
        {
            if (Mathf.Abs(_force.x) > Mathf.Abs(_force.y))
            {
                switch (Mathf.Sign(_force.x))
                {
                    case 1:
                        startFrame = 8;
                        break;
                    case -1:
                        startFrame = 12;
                        break;
                }
            } else {
                switch (Mathf.Sign(_force.y))
                {
                    case 1:
                        startFrame = 4;
                        break;
                    case -1:
                        startFrame = 0;
                        break;
                }
            }

            if (startFrame != lastStartFrame) animSprite.SetFrame(startFrame);
            lastStartFrame = startFrame;
            //Console.WriteLine($"Vec2: {_force} SignX: ({Mathf.Sign(_force.x)}), SignY: ({Mathf.Sign(_force.y)})");
        }

        void PlayAnim()
        {
            animSprite.NextFrame();
            //Console.WriteLine($"Startframe: {startFrame} Currentframe: {animSprite.currentFrame}");
            //Console.WriteLine($"if currentFrame {animSprite.currentFrame} > {startFrame + 3}");
            if (animSprite.currentFrame > startFrame + 3)
                animSprite.SetFrame(startFrame);

            if (animSprite.currentFrame == 0 && startFrame == 12) //special case for frame '16' which doesnt exist and becomes 0 -Jesse
                animSprite.SetFrame(startFrame);
        }

        public List<Vec2> GetMovePattern()
        {
            return destination;
        }
    }
}
