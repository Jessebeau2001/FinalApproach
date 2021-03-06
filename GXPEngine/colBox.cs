﻿namespace GXPEngine
{
	class ColBox : GameObject
	{
		EasyDraw col;
		public ColBox(int x, int y, int width, int height, bool addCollider = true, bool showBounds = false, string name = "wall")
		{
			if (addCollider == false) return;
			col = new EasyDraw(width, height, addCollider);
			col.name = name;
			col.NoFill();
			col.Stroke(245, 66, 66);
			if (name == "WinBox") col.Stroke(19, 252, 3);
			if (showBounds)
				col.StrokeWeight(1);
			else
				col.NoStroke();
			col.ShapeAlign(CenterMode.Min, CenterMode.Min);
			col.Rect(0, 0, col.width - 1, col.height - 1);
			col.x = x;
			col.y = y;
			AddChild(col);
		}
	}
}
