namespace GXPEngine
{
	class ColBox : GameObject
	{
		EasyDraw col;
		public ColBox(int x, int y, int width, int height, bool addCollider = true, bool showBounds = false)
		{

			col = new EasyDraw(width, height, addCollider);
			col.name = "colBox";
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
	}
}
