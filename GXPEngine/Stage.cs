using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Stage : Pivot
	{
		public Stage() : base()
		{
			Sprite background = new Sprite("textures/mockupLevel.png", false);
			AddChild(background);
			Player player = new Player(100, 100);
			AddChild(player);
		}

		void Update()
		{

		}

	}
}
