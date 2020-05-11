using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class HUDOverlay : GameObject
    {
        HUDElement testElement;
        HUDElement[] listItem;

        public HUDOverlay(Player player)
        {
            testElement = new HUDElement(200, 200, "textures/alphaList.png", "Im a weird placeholder list");
            //AddChild(testElement);

            createList(400, 800, player.playerInv.invSize);
        }

        void createList(float x, float y, int size)
        {
            listItem = new HUDElement[size];

            HUDElement listTop = new HUDElement(x, y, "textures/alphaListTop.png");
            AddChild(listTop);

            for (int i = 0; i < listItem.Length; i++)
            {
                listItem[i] = new HUDElement(x, y + listTop.height, "textures/alphaListSection.png", "Im just here for now");
                listItem[i].y += listItem[0].height * i;

                AddChild(listItem[i]);
            }

            HUDElement listBottom = new HUDElement(x, listItem[listItem.Length - 1].y + listItem[0].height, "textures/alphaListBottom.png");
            AddChild(listBottom);

            float height = (listBottom.y + listBottom.height) - y;
        }
    }
}
