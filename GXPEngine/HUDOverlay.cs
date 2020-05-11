using System;

namespace GXPEngine
{
    class HUDOverlay : GameObject
    {
        HUDElement testElement;
        ShopList list;

        public HUDOverlay(Player player)
        {
            testElement = new HUDElement(200, 200, "textures/alphaList.png", "Im a weird placeholder list");
            //AddChild(testElement);

            list = new ShopList(0, 0, player.inventory.size);
            AddChild(list);
        }

        void Update()
        {
            if (Input.GetKey(Key.DOWN))
                list.y += Time.deltaTime;
            if (Input.GetKey(Key.UP))
                list.y -= Time.deltaTime;
            if (Input.GetKey(Key.RIGHT))
                list.x += Time.deltaTime;
            if (Input.GetKey(Key.LEFT))
                list.x -= Time.deltaTime;

            if (Input.mouseX > list.x && Input.mouseX < list.x + list.width)
                if (Input.mouseY > list.y && Input.mouseY < list.y + list.height)
                    if (Input.GetMouseButton(0))
                    {
                        list.x = Input.mouseX - 200;
                        list.y = Input.mouseY - 200;
                    }


        }
    }
}
