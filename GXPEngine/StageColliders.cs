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

		//ColBox boundigBox;

        public StageColliders(string mapPath)
        {
			//leveldata = MapParser.ReadMap(mapPath);
			//SpawnColliders(leveldata, true);
		}

		//void SpawnColliders(Map leveldata, bool showBounds)
		//{
		//	if (leveldata.ObjectGroups == null || leveldata.ObjectGroups.Length == 0) return;

		//	foreach (ObjectGroup group in leveldata.ObjectGroups)
		//	{
		//		Console.WriteLine("Loading object group '" + group.Name + "' with group ID '" + group.id + "'");
		//		if (group.Name == "WallColliders")
		//		{
		//			foreach (TiledObject obj in group.Objects)
		//			{
		//				if (group.Objects == null || group.Objects.Length == 0) return;
		//				boundigBox = new ColBox(Mathf.Round(obj.X), Mathf.Round(obj.Y), Mathf.Round(obj.Width), Mathf.Round(obj.Height));
		//				AddChild(boundigBox);
		//			}
		//		}
		//		if (group.Name == "Items")
		//		{
		//			_itemList = new Pickup[group.Objects.Length];
		//			if (group.Objects == null || group.Objects.Length == 0) return;
		//			int i = 0;
		//			foreach (TiledObject obj in group.Objects)
		//			{
		//				_itemList[i] = new Pickup(Mathf.Round(obj.X), Mathf.Round(obj.Y), obj.GID, i);
		//				AddChild(_itemList[i]);
		//				Console.WriteLine($"{_itemList[i].itemName} has been initilized");
		//				i++;
		//			}
		//		}
		//	}
		//}

		public Pickup[] itemList
		{
			get { return _itemList; }
		}
	}
}
