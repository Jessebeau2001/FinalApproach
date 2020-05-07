using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Stage : Pivot
	{
		EasyDraw col;
		public Stage() : base()
		{
			Sprite background = new Sprite("textures/mockupLevel.png", false, false);
			AddChild(background);
			Player player = new Player(100, 100);
			AddChild(player);

			col = new EasyDraw(40, 60, true);
			col.NoFill();
			col.Stroke(245, 66, 66);
			col.StrokeWeight(1);
			col.ShapeAlign(CenterMode.Min, CenterMode.Min);
			col.Rect(0, 0, col.width - 1, col.height - 1);
			col.x = 500;
			col.y = 700;

			AddChild(col);
		}

		void Update()
		{

		}

	}
}
