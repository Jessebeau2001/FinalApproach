using System;
using TiledMapParser;

namespace GXPEngine
{
	class Stage : Pivot
	{
		private string mapPath = "maps/test.tmx";

		//EasyDraw col;

		//Pickup item;

		Sprite background;
		NPC testNPC;
		Player player;
		Map leveldata;
		StageColliders colBox;
		HUDOverlay playerHUD;

		public Stage() : base()
		{
			background = new Sprite("textures/mockupLevel_empty.png", false, false);
			AddChild(background);

			testNPC = new NPC(900, 400);
			testNPC.SetMovementPattern("LR"); //LR = LeftRight, UD = UpDown, SQ = Square
			AddChild(testNPC);

			player = new Player(100, 100, 7);
			AddChild(player);

			leveldata = MapParser.ReadMap(mapPath);
			colBox = new StageColliders(leveldata);
			AddChild(colBox);

			//SpawnColliders(leveldata, true);

			playerHUD = new HUDOverlay(player);
			AddChild(playerHUD);
		}

		public void Update()
		{
			testNPC.OnCollision(colBox);
		}

		//void CreateBoundingBox(int x, int y, int width, int height, bool addCollider, bool showBounds)
		//{
		//	col = new EasyDraw(width, height, addCollider);
		//	col.NoFill();
		//	col.Stroke(245, 66, 66);
		//	if (showBounds)
		//		col.StrokeWeight(1);
		//	col.ShapeAlign(CenterMode.Min, CenterMode.Min);
		//	col.Rect(0, 0, col.width - 1, col.height - 1);
		//	col.x = x;
		//	col.y = y;
		//	AddChild(col);
		//}

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
		//				Console.WriteLine($"{ obj }");
		//				CreateBoundingBox(Mathf.Round(obj.X), Mathf.Round(obj.Y), Mathf.Round(obj.Width), Mathf.Round(obj.Height), true, showBounds);
		//			}
		//		}
		//		if (group.Name == "Items")
		//		{
		//			foreach (TiledObject obj in group.Objects)
		//			{
		//				if (group.Objects == null || group.Objects.Length == 0) return;

		//				item = new Pickup(Mathf.Round(obj.X), Mathf.Round(obj.Y), obj.GID);
		//				AddChild(item);
		//			}
		//		}
		//	}
		//}
	}
}