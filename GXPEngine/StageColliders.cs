using System;
using System.Collections;
using TiledMapParser;

namespace GXPEngine
{
    class StageColliders : GameObject
    {
		Map leveldata;
        EasyDraw col;

		Pickup[] _itemList;

        public StageColliders(string mapPath)
        {
			leveldata = MapParser.ReadMap(mapPath);
			SpawnColliders(leveldata, true);
		}

		void CreateBoundingBox(int x, int y, int width, int height, bool addCollider, bool showBounds)
		{
			col = new EasyDraw(width, height, addCollider);
			col.NoFill();
			col.Stroke(245, 66, 66);
			if (showBounds)
				col.StrokeWeight(1);
			col.ShapeAlign(CenterMode.Min, CenterMode.Min);
			col.Rect(0, 0, col.width - 1, col.height - 1);
			col.x = x;
			col.y = y;
			AddChild(col);
		}

		void SpawnColliders(Map leveldata, bool showBounds)
		{
			if (leveldata.ObjectGroups == null || leveldata.ObjectGroups.Length == 0) return;

			foreach (ObjectGroup group in leveldata.ObjectGroups)
			{
				Console.WriteLine("Loading object group '" + group.Name + "' with group ID '" + group.id + "'");
				if (group.Name == "WallColliders")
				{
					foreach (TiledObject obj in group.Objects)
					{
						if (group.Objects == null || group.Objects.Length == 0) return;
						Console.WriteLine($"{ obj }");
						CreateBoundingBox(Mathf.Round(obj.X), Mathf.Round(obj.Y), Mathf.Round(obj.Width), Mathf.Round(obj.Height), true, showBounds);
					}
				}
				if (group.Name == "Items")
				{
					_itemList = new Pickup[group.Objects.Length];
					if (group.Objects == null || group.Objects.Length == 0) return;
					int i = 0;
					foreach (TiledObject obj in group.Objects)
					{
						_itemList[i] = new Pickup(Mathf.Round(obj.X), Mathf.Round(obj.Y), obj.GID);
						AddChild(_itemList[i]);
						i++;
					}

					foreach (Pickup item in _itemList)
						Console.WriteLine(item);
				}
			}
		}

		public Pickup[] itemList
		{
			get { return _itemList; }
		}
	}
}
