using System;
using TiledMapParser;

namespace GXPEngine
{
	class Stage : Pivot
	{
		private string mapPath = "maps/test.tmx";

		Sprite background;
		NPC testNPC;
		Player player;
		StageColliders stageCol;
		HUDOverlay playerHUD;

		public Stage() : base()
		{
			background = new Sprite("textures/mockupLevel_empty.png", false, false);
			AddChild(background);

			InitializeNPCs();

			player = new Player(100, 100, 7);
			AddChild(player);

			stageCol = new StageColliders(mapPath);
			AddChild(stageCol);

			playerHUD = new HUDOverlay(player);
			AddChild(playerHUD);
		}

		public void Update()
		{
		}

		private void InitializeNPCs()
		{
			string[] movePattern;

			testNPC = new NPC(900, 400);
			movePattern = new string[] { "L", "R" };
			testNPC.SetMovePattern(movePattern);
			AddChild(testNPC);

			testNPC = new NPC(400, 600);
			movePattern = new string[] { "U", "D" };
			testNPC.SetMovePattern(movePattern);
			AddChild(testNPC);
		}
	}
}