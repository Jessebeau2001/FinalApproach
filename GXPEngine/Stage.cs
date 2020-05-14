using System;
using System.Collections;
using TiledMapParser;

namespace GXPEngine
{
	class Stage : Pivot
	{
		private string mapPath = "maps/map1.tmx";
		//private string mapPath = "maps/test.tmx";


		Sprite background;
		Player player;
		ColBox[] boundigBox;
		Pickup[] _itemList;
		ArrayList enemies = new ArrayList();
		HUDOverlay playerHUD;

		public Stage() : base()
		{
			Map leveldata = MapParser.ReadMap(mapPath);
			background = new Sprite("textures/" + leveldata.ImageLayers[0].Image.FileName, false, false);
			SpawnColliders(leveldata, true);

			playerHUD = new HUDOverlay(player, _itemList);
			player = new Player(930, 930, _itemList, playerHUD);

			AddChild(background);   //seperated the addChildren so we can set what render on top of what -Jesse
			foreach (Pickup item in _itemList) AddChild(item);
			foreach (ColBox box in boundigBox) AddChild(box);
			foreach (NPC enemy in enemies) AddChild(enemy);
			AddChild(player);
			AddChild(playerHUD);
		}

		public void Update()
		{
			if (Input.GetKeyDown(Key.SPACE))
				playerHUD.shopList.checkItem(0);
		}

		void SpawnColliders(Map leveldata, bool showBounds)
		{
			if (leveldata.ObjectGroups == null || leveldata.ObjectGroups.Length == 0) return;

			foreach (ObjectGroup group in leveldata.ObjectGroups)
			{
				Console.WriteLine("Loading object group '" + group.Name + "' with group ID '" + group.id + "'");
				if (group.Name == "WallColliders")
				{
					int i = 0;
					boundigBox = new ColBox[group.Objects.Length];
					if (group.Objects == null || group.Objects.Length == 0) return;
					foreach (TiledObject obj in group.Objects)
					{
						Console.WriteLine($"Creating Bounding box {TextThing(obj.Name)} | X: {Mathf.Round(obj.X)}, Y: {Mathf.Round(obj.Y)} with sizeX: {Mathf.Round(obj.Width)} and sizeY: {Mathf.Round(obj.Height)}");
						boundigBox[i] = new ColBox(Mathf.Round(obj.X), Mathf.Round(obj.Y), Mathf.Round(obj.Width), Mathf.Round(obj.Height), showBounds: true ,name: obj.Name);
						i++;
					}
				}

				if (group.Name == "Items")
				{
					_itemList = new Pickup[group.Objects.Length];
					if (group.Objects == null || group.Objects.Length == 0) return;
					int i = 0;
					foreach (TiledObject obj in group.Objects)
					{
						_itemList[i] = new Pickup(Mathf.Round(obj.X), Mathf.Round(obj.Y), obj.GID, i);
						Console.WriteLine($"{obj.X}, {obj.Y}");
						i++;
					}
				}

				if (group.Name == "NPCs")
				{
					if (group.Objects == null || group.Objects.Length == 0) return;
					foreach (TiledObject obj in group.Objects)
					{
						string[] polyPoints = obj.polygon.points.Split(new char[] {' '});
						enemies.Add(new NPC(obj.X, obj.Y, polyPoints, 2)); 
					}

				}
			}
		}

		private string TextThing(string text)
		{
			if (text == null) return "";
			string newString;
			if (text.Length < 8)
				newString = text + "\t \t";
			else if (text.Length < 16)
				newString = text + "\t";
			else
				newString = text + "\t";
			return newString;
			//int count = (int)Math.Round(24f / text.Length);
		}
	}
}