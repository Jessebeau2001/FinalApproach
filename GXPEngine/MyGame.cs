using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	Stage stage;
	public MyGame() : base(1920, 1080, false, true)
	//public MyGame() : base(1920, 1080, false, true, 1360,720)
	{
		stage = new Stage();
		AddChild(stage);
	}

    void Update()
	{
		if (Input.GetKeyDown(Key.SPACE))
		{
			stage.LateDestroy();
			stage = new Stage();
			AddChild(stage);
		}
	}

	static void Main()
	{
		new MyGame().Start();
	}
}