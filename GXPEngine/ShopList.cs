using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class ShopList : Pivot
	{
        private float _height;

        HUDElement[] listItem;

        public ShopList(float x, float y, int listSize)
		{
            this.x = x;
            this.y = y;

            listItem = new HUDElement[listSize];

            HUDElement listTop = new HUDElement(0, 0, "textures/alphaListTop.png");
            AddChild(listTop);

            for (int i = 0; i < listItem.Length; i++)
            {
                listItem[i] = new HUDElement(0, 0, "textures/alphaListSection.png", "Im just here for now");
                listItem[i].y += listTop.height + (listItem[0].height * i);

                AddChild(listItem[i]);
            }

            HUDElement listBottom = new HUDElement(0, listTop.height + (listItem[0].height * listItem.Length), "textures/alphaListBottom.png");
            AddChild(listBottom);

            _height = listTop.height + (listItem[0].height * listItem.Length) + listBottom.height;
        }

        public float height
        {
            get { return _height; }
        }
    }
}
