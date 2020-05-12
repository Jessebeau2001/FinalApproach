using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class ShopList : Pivot
	{
        readonly float _width;
        readonly float _height;

        public Vec2 position;

        HUDElement listTop;
        HUDElement[] listItem;
        HUDElement listBottom;

        public ShopList(float x, float y, int listSize)
		{
            position.x = x;
            position.y = y;

            listItem = new HUDElement[listSize];

            listTop = new HUDElement(0, 0, "textures/alphaListTop.png");
            AddChild(listTop);

            for (int i = 0; i < listItem.Length; i++)
            {
                listItem[i] = new HUDElement(0, 0, "textures/alphaListSection.png", "Im just here for now");
                listItem[i].y += listTop.height + (listItem[0].height * i);

                AddChild(listItem[i]);
            }

            listBottom = new HUDElement(0, listTop.height + (listItem[0].height * listItem.Length), "textures/alphaListBottom.png");
            AddChild(listBottom);

            _width = listTop.width;
            _height = listTop.height + (listItem[0].height * listItem.Length) + listBottom.height;
        }

        void Update()
        {
            x = position.x;
            y = position.y;
        }
        public float width
        {
            get { return _width; }
        }
        public float height
        {
            get { return _height; }
        }

        public float topHeight
        {
            get { return listTop.height; }
        }

        public float sectionHeight
        {
            get { return listItem[0].height * listItem.Length; }
        }
    }
}
