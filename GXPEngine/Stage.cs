﻿using System;
using System.Collections;
using TiledMapParser;
using System.Linq;

namespace GXPEngine
{
	class Stage : Pivot
	{
		private string mapPath = "maps/map1v2.tmx";
		//private string mapPath = "maps/test.tmx";

		Sprite background;
		Player player;
		ColBox[] boundigBox;
		Pickup[] _itemList;
		ArrayList enemies = new ArrayList();
		HUDOverlay playerHUD;
		Sprite winMark = new Sprite("textures/exlMoji.png", false, false);

		public Stage() : base()
		{
			Map leveldata = MapParser.ReadMap(mapPath);
			background = new Sprite("textures/" + leveldata.ImageLayers[0].Image.FileName, false, false);
			SpawnColliders(leveldata, true);

			playerHUD = new HUDOverlay(player, _itemList);
			player = new Player(930, 930, _itemList, playerHUD, this);

			AddChild(background);   //seperated the addChildren so we can set what renders on top of what -Jesse
			foreach (Pickup item in _itemList) AddChild(item);
			foreach (ColBox box in boundigBox) AddChild(box);
			foreach (NPC enemy in enemies) AddChild(enemy);
			AddChild(player);
			AddChild(playerHUD);
			AddChild(winMark);
		}

		public void Update()
		{
			if (Input.GetKeyDown(Key.SPACE))
				playerHUD.shopList.checkItem(0);

			if (_itemList.All(_itemList => _itemList.isPickedUp))
				winMark.visible = true;
		}

		void SpawnColliders(Map leveldata, bool showBounds)
		{
			if (leveldata.ObjectGroups == null || leveldata.ObjectGroups.Length == 0) return;

			foreach (ObjectGroup group in leveldata.ObjectGroups)
			{
				Console.WriteLine("--------------------------------------------------------------------------");
				Console.WriteLine("Loading object group '" + group.Name + "' with group ID '" + group.id + "'");
				if (group.Name == "WallColliders")
				{
					int i = 0;
					boundigBox = new ColBox[group.Objects.Length];
					if (group.Objects == null || group.Objects.Length == 0) return;
					foreach (TiledObject obj in group.Objects)
					{
						Console.WriteLine($"Creating Bounding box {TextThing(obj.Name)} | X: {Mathf.Round(obj.X)}, Y: {Mathf.Round(obj.Y)} with sizeX: {Mathf.Round(obj.Width)} and sizeY: {Mathf.Round(obj.Height)}");
						boundigBox[i] = new ColBox(Mathf.Round(obj.X), Mathf.Round(obj.Y), Mathf.Round(obj.Width), Mathf.Round(obj.Height), name: obj.Name);
						i++;

						if (obj.Name == "WinBox")
						{
							winMark.scale = .5f;
							winMark.x = obj.X + (obj.Width / 2) - (winMark.width / 2);
							winMark.y = obj.Y + (obj.Height / 2) - (winMark.height / 2);
							winMark.visible = false;
						}
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

				if (group.Name == "NPCs")
				{
					if (group.Objects == null || group.Objects.Length == 0) return;
					foreach (TiledObject obj in group.Objects)
					{
						Console.WriteLine($"Loading in NPC {enemies.Count}...");
						if (obj.polygon == null) throw new Exception("Object with ID: " + obj.ID + " was not a polygon");

						enemies.Add(new NPC(obj.X, obj.Y, obj.polygon.GetPolyPoints(), SpritePath(obj.propertyList), 2));
					}

				}
			}
		}

		string SpritePath(PropertyList pList)
		{
			if (pList == null) return null;
			foreach (Property property in pList.properties)
				if (property.Name == "spriteSheet")
					return property.Value;
			return null;
		}

		private string TextThing(string text) //For calculating tabs in Console useless but fun -Jesse
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
		}

		public void WinGame()
		{
			(parent as MyGame).WinGame();
			LateDestroy();
		}

		public void LoseGame()
		{
			(parent as MyGame).LoseGame();
			LateDestroy();
		}
	}
}