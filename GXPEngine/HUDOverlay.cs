using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class HUDOverlay : GameObject
    {
        HUDElement _listObject;
        HUDElement _listText;

        public HUDOverlay(Inventory InvRef) //Reference to where the items are read from
        {
            _listObject = new HUDElement(0, 0, "/texture/Onion.png");
            AddChild(_listObject);

            _listText = new HUDElement(0, 0, "Onion");
            AddChild(_listText);
        }

        public void Update() //Use to update the current state
        {

        }
    }
}
