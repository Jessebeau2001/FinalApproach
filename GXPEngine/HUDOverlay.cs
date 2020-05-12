using System;

namespace GXPEngine
{
    class HUDOverlay : GameObject
    {
        HUDElement testElement;
        ShopList list;

        private int _hidden = -1;

        public HUDOverlay(Player player)
        {
            testElement = new HUDElement(200, 200, "textures/alphaList.png", "Im a weird placeholder list");
            //AddChild(testElement);

            list = new ShopList(0, game.height, player.inventory.size);
            list.position.y -= list.topHeight;
            AddChild(list);
        }

        void Update()
        {
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
    }
}
