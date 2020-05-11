using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class HUDOverlay : GameObject
    {
        HUDElement testElement;

        public HUDOverlay(Player player)
        {
            testElement = new HUDElement(200, 200, "textures/alphaList.png", "Im a weird placeholder list");
            //AddChild(testElement);
        }
    }
}
