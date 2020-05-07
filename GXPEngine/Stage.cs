using System;
using TiledMapParser;

namespace GXPEngine
{
	class Stage : Pivot
	{
		private string mapPath = "maps/test.tmx";

		EasyDraw col;
		public Stage() : base()
		{
			Sprite background = new Sprite("textures/mockupLevel.png", false, false);
			AddChild(background);
			Player player = new Player(100, 100);
			AddChild(player);

			NPC testNPC = new NPC(700, 400);
			testNPC.SetMovementPattern("LR"); //LR = LeftRight, UD = UpDown, SQ = Square
			AddChild(testNPC);

			Pickup item = new Pickup(900, 900, "textures/grapes.png");
			AddChild(item);

			Map leveldata = MapParser.ReadMap(mapPath);
			SpawnColliders(leveldata, true);
		}

		void Update()
		{


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
			ObjectGroup colliderGroup = leveldata.ObjectGroups[0];
			if (colliderGroup.Objects == null || colliderGroup.Objects.Length == 0) return;

			foreach (TiledObject obj in colliderGroup.Objects)
			{
				Console.WriteLine($"{ obj }");
				CreateBoundingBox(Mathf.Round(obj.X), Mathf.Round(obj.Y), Mathf.Round(obj.Width), Mathf.Round(obj.Height), true, showBounds);
			}
		}

	}
}
