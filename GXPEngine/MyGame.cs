using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{
	Stage stage;
	public MyGame() : base(1920, 1080, false)
	{
		stage = new Stage();
		AddChild(stage);
    }

    void Update()
	{
		
	}

	static void Main()
	{
		new MyGame().Start();
	}
}