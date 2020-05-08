using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Pickup : EasyDraw
	{
		private int gid;
		private string itemName;
		private string texturePath;

		//public Pickup(float x, float y, int gid) : base("textures/grapes.png", false, true)
		public Pickup(float x, float y, int gid) : base(100, 100, true)
		{
			this.x = x;
			this.y = y;

			Rect(x, y, width, height);
			SetProperties(gid);

			Sprite sprite = new Sprite(texturePath, true, false);
			AddChild(sprite);
		}

		public string GetItemName()
		{
			return itemName;
		}

		private void SetProperties(int gid)
		{
			this.gid = gid;
			switch (gid)
			{
				default:
					texturePath = "textures/unknown.png";
					itemName = "Unkown";
					break;
				case 1:
					texturePath = "textures/cereal.png";
					itemName = "Cereal";
					break;
				case 2:
					texturePath = "textures/grapes.png";
					itemName = "Grapes";
					break;
			}
		}
	}
}
