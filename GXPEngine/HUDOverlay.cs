using System;
using System.Collections;

namespace GXPEngine
{
    class HUDOverlay : GameObject
    {
        ShopList list;

        private bool animateList = false;

        private bool firstFrame = true;
        private Vec2 v;
        private Vec2 ogPos;
        private int timeRemain = 1;
        private bool shown = false;

        public HUDOverlay(Player player, Pickup[] itemList)
        {
            list = new ShopList(itemList);
            list.position.y = game.height - list.topHeight;
            AddChild(list);
        }

        void Update()
        {
            AnimHandler();
            InputHandler();
        }

        void InputHandler()
        {
            if (Input.mouseX > list.position.x && Input.mouseX < list.position.x + list.width)
                if (Input.mouseY > list.position.y && Input.mouseY < list.position.y + list.height)
                    if (Input.GetMouseButtonUp(0))
                        animateList = true;

            if (Input.GetKeyDown(Key.LEFT_ALT))
                animateList = true;
        }

        void AnimHandler()
        {
            if (animateList) ToggleList();
        }

        void ToggleList()
        {
            if (shown)
                TranslateOverTime(ref list.position, new Vec2(0, list.sectionHeight), 200);
            else
                TranslateOverTime(ref list.position, new Vec2(0, list.sectionHeight * -1), 200);
        }

        void TranslateOverTime(ref Vec2 vec, Vec2 dist, int time)
        {
            if (firstFrame)
            {
                timeRemain = time;
                v = dist / time;
                ogPos = vec;
                firstFrame = false;
            }

            timeRemain -= Time.deltaTime;
            vec += v * Time.deltaTime;
            if (timeRemain <= 0)
            {
                vec = ogPos + dist; //Is this bullshit, idk but it makes up for the .00001 that you get when reverse applying extra milliseconds -Jesse
                firstFrame = true;
                shown = !shown;
                animateList = false;
            }
        }
    }
}
