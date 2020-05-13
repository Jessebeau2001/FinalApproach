using System;
using TiledMapParser;

namespace GXPEngine
{
	class Stage : Pivot
	{
		private string mapPath = "maps/test.tmx";

		Sprite background;
		Player player;
		ColBox[] boundigBox;
		Pickup[] _itemList;
		NPC testNPC;
		HUDOverlay playerHUD;

		public Stage() : base()
		{
			background = new Sprite("textures/mockupLevel_empty.png", false, false);

			Map leveldata = MapParser.ReadMap(mapPath);
			SpawnColliders(leveldata, true);

			playerHUD = new HUDOverlay(player, _itemList);
			player = new Player(100, 100, _itemList.Length, playerHUD);

			AddChild(background);	//seperated the addChildren so we can set what render on top of what -Jesse
			AddChild(player);
			InitializeNPCs();
			foreach (ColBox box in boundigBox) AddChild(box);
			foreach (Pickup item in _itemList) AddChild(item);
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
						boundigBox[i] = new ColBox(Mathf.Round(obj.X), Mathf.Round(obj.Y), Mathf.Round(obj.Width), Mathf.Round(obj.Height));
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
						i++;
					}
				}
			}
		}

		private void InitializeNPCs()
		{
			testNPC = new NPC(900, 400);
			testNPC.SetMovementPattern("LR"); //LR = LeftRight, UD = UpDown, SQ = Square
			AddChild(testNPC);

			testNPC = new NPC(400, 600);
			testNPC.SetMovementPattern("UD");
			AddChild(testNPC);
		}
	}
}