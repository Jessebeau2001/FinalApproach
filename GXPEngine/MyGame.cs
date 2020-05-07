using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;								// GXPEngine contains the engine

public class MyGame : Game
{
	Stage stage;
	public MyGame() : base(1920, 1080, false, true, 1360,720)
	{
		stage = new Stage();
		AddChild(stage);
	}

    void Update()
	{

	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}