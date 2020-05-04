using System;									// System contains a lot of default C# libraries 
using GXPEngine;								// GXPEngine contains the engine
using System.Drawing;

public class MyGame : Game
{
	public MyGame() : base(800, 600, false)		// Create a window that's 800x600 and NOT fullscreen
	{
        //----------------------------------------------------example-code----------------------------
        //create a canvas
        Canvas canvas = new Canvas(800, 600);

        //add some content
        canvas.graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(0, 0, 400, 300));
        canvas.graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(400, 0, 400, 300));
        canvas.graphics.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(0, 300, 400, 300));
        canvas.graphics.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(400, 300, 400, 300));

        //add canvas to display list
        AddChild(canvas);
        //------------------------------------------------end-of-example-code-------------------------
    }

    void Update()
	{
		// Empty
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}