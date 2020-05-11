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

        public HUDOverlay(Player player)
        {
            //_listObject = new HUDElement(0, 0);
            //AddChild(_listObject);

            _listText = new HUDElement("Onion", 0, 0);
            AddChild(_listText);
        }

        public void Update() //Use to update the current state
        {

        }
    }
}
