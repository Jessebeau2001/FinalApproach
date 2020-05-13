using System;
using TiledMapParser;

namespace GXPEngine
{
	class Stage : Pivot
	{
		private string mapPath = "maps/test.tmx";

		Sprite background;
		Player player;
		NPC testNPC;
		StageColliders stageCol;
		HUDOverlay playerHUD;

		public Stage() : base()
		{
			background = new Sprite("textures/mockupLevel_empty.png", false, false);
			stageCol = new StageColliders(mapPath);
			playerHUD = new HUDOverlay(player, stageCol.itemList);
			player = new Player(100, 100, stageCol.itemList.Length, playerHUD);

			AddChild(background);
			AddChild(stageCol);
			AddChild(player);	//seperated the addChildren so we can set what render on top of what -Jesse
			AddChild(playerHUD);

			//InitializeNPCs();
		}

		public void Update()
		{
			if (Input.GetKeyDown(Key.SPACE))
				playerHUD.shopList.checkItem(0);
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