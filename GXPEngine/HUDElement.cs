using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class HUDElement : Sprite
    {
        float _width;       //Non class-bound width
        float _height;      //and height
        Sprite _listObject; //For pictures to overlay over the HUD
        EasyDraw _listText; //For text to overlay over the HUD

        public HUDElement(float x, float y) : base("")
        {

        }
    }
}
