﻿using System;
using System.Collections;

namespace GXPEngine
{
	class ShopList : Pivot
	{
        readonly float _width;
        readonly float _height;

        public Vec2 position;

        UIElement listTop;
        UIElement[] listItem;
        UIElement listBottom;

        Sprite[] checkMarks;

        public ShopList(Pickup[] itemList)
        {
            listTop = new UIElement(0, 0, "textures/alphaListTop.png");
            AddChild(listTop);

            listItem = new UIElement[itemList.Length];
            checkMarks = new Sprite[itemList.Length];
            for (int i = 0; i < listItem.Length; i++)
            {
                listItem[i] = new UIElement(0, 0, "textures/alphaListSection.png", itemList[i].itemName);
                listItem[i].y += listTop.height + (listItem[0].height * i);
                AddChild(listItem[i]);
                
                checkMarks[i] = new Sprite("textures/check.png", false);
                checkMarks[i].x += 6; //just put something here that fits
                listItem[i].AddChild(checkMarks[i]);
                checkMarks[i].visible = false;
            }

            listBottom = new UIElement(0, listTop.height + (listItem[0].height * listItem.Length), "textures/alphaListBottom.png");
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

        public void checkItem(int index)
        {
            checkMarks[index].visible = true;
        }
    }
}
