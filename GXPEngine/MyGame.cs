using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	Stage stage;
	public MyGame() : base(1920, 1080, false, true)
	{
		startAnew();
	}

    void Update()
	{
		if (Input.GetKeyDown(Key.SPACE))
			stage.Destroy();
			
	}

	public void startAnew()
	{
		Menu mainMenu = new Menu("mainMenu", Color.FromArgb(255, 255, 241, 201));
		LateAddChild(mainMenu);
	}

	public void StartGame()
	{
		stage = new Stage();
		LateAddChild(stage);
	}

	public void WinGame()
	{
		Menu winScreen = new Menu("winMenu", Color.FromArgb(255, 130, 255, 130));
		LateAddChild(winScreen);
	}

	public void LoseGame()
	{
		Menu loseScreen = new Menu("loseMenu", Color.FromArgb(255, 255, 133, 120));
		LateAddChild(loseScreen); //The game miserably fails after 2 retries for some reason -Jesse
	}

	static void Main()
	{
		new MyGame().Start();
	}
}