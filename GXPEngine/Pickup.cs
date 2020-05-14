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
		private bool _isPickedUp = false;

		public Pickup(float x, float y, int gid, int itemIndex) : base(100, 100, true)
		{
			this.x = x;
			this.y = y;

			
			_itemIndex = itemIndex;

			ShapeAlign(CenterMode.Min, CenterMode.Min);

			SetProperties(gid);

			Sprite sprite = new Sprite(_texturePath, true, false);
			this.y -= sprite.height;
			sprite.width = width;
			sprite.height = height;
			AddChild(sprite);

			//Rect(0, 0, width, height);
			//Console.WriteLine($"Spawned pickup at X: {this.x} Y: {this.y}");
		}

		public string GetItemName()
		{
			return _itemName;
		}

		private void SetProperties(int gid) //for some reason first GID starts at 2 ?? so we do - 1 in the variable -Jesse
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

		public void PickItUp()
		{
			_isPickedUp = true;
			visible = false;
		}

		public string itemName
		{
			get { return _itemName; }
		}

		public int itemIndex
		{
			get { return _itemIndex; }
		}

		public bool isPickedUp
		{
			get { return _isPickedUp; }
		}
	}
}
