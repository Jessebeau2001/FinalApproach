using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Pickup : EasyDraw
	{
		private int gid;
		private string _itemName;
		private string _texturePath;
		private int _itemIndex;

		//public Pickup(float x, float y, int gid) : base("textures/grapes.png", false, true)
		public Pickup(float x, float y, int gid, int itemIndex) : base(100, 100, true)
		{
			this.x = x;
			this.y = y;
			_itemIndex = itemIndex;

			Rect(x, y, width, height);
			SetProperties(gid);

			Sprite sprite = new Sprite(_texturePath, true, false);
			AddChild(sprite);
			//scale = .2f;
		}

		public string GetItemName()
		{
			return _itemName;
		}

		private void SetProperties(int gid) //for some reason first GID starts at 2 ?? so we do - 1 in the variable
		{
			this.gid = gid - 1;
			Console.WriteLine("Loading Item with ID: " + this.gid);
			switch (this.gid)
			{
				default:
					_texturePath = "textures/unknown.png";
					_itemName = "Unkown";
					break;
				case 1:
					_texturePath = "textures/cereal.png";
					_itemName = "Cereal";
					break;
				case 2:
					_texturePath = "textures/milk.png";
					_itemName = "Milk";
					break;
				case 3:
					_texturePath = "textures/pizza.png";
					_itemName = "Pizza";
					break;
				case 4:
					_texturePath = "textures/water.png";
					_itemName = "Water";
					break;
			}
		}

		public string itemName
		{
			get { return _itemName; }
		}

		public int itemIndex
		{
			get { return _itemIndex; }
		}
	}
}
