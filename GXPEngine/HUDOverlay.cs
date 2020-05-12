using System;

namespace GXPEngine
{
    class HUDOverlay : GameObject
    {
        ShopList list;

        private int _hidden = -1;


        private bool firstFrame = true;
        private Vec2 v;
        private Vec2 ogPos;
        private int timeRemain = 1;

        public HUDOverlay(Player player)
        {
            list = new ShopList(player.inventory.size);
            list.position.y = game.height - list.topHeight;
            AddChild(list);
        }

        void Update()
        {
            //TranslateOverTime(list.position, new Vec2(200, -200), 2000);

            if (Input.mouseX > list.position.x && Input.mouseX < list.position.x + list.width)
                if (Input.mouseY > list.position.y && Input.mouseY < list.position.y + list.height)
                    if (Input.GetMouseButtonUp(0))
                        ShowList();
            
            if (Input.GetKeyDown(Key.LEFT_ALT))
                ShowList();
        }

        void ShowList()
        {
            list.position.y += list.sectionHeight * _hidden;
            _hidden *= -1;
        }

        void TranslateOverTime(Vec2 vec, Vec2 dist, int time)
        {
            if (timeRemain <= 0) return;
            Console.WriteLine(vec);   
            if (firstFrame)
            {
                timeRemain = time;
                v = dist / time;
                ogPos = vec;
                firstFrame = false;
            }

            timeRemain -= Time.deltaTime;
            vec += v * Time.deltaTime;
            Console.WriteLine(vec);
            if (timeRemain <= 0)
                vec = ogPos + dist; //Is this bullshit, idk but it makes up for the .00001 that you get when reverse applying extra milliseconds -Jesse
        }
    }
}
