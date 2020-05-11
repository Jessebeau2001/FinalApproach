using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class HUDElement : Pivot
    {
        Sprite ElementTexture; //For pictures to overlay over the HUD
         
        public HUDElement(float x, float y, string texturePath, string UIText = null)
        {
            this.x = x;
            this.y = y;
            ElementTexture = new Sprite(texturePath, false, false);
            AddChild(ElementTexture);

            InititalizeText(UIText);
        }

        void InititalizeText(string text) //For text to overlay over the HUD
        {
            if (text == null) return;
            EasyDraw textContainer = new EasyDraw(ElementTexture.width, ElementTexture.height, false);
            AddChild(textContainer);

            textContainer.TextAlign(CenterMode.Center, CenterMode.Center);
            textContainer.Fill(0, 0, 0);
            textContainer.Text(text, textContainer.width / 2, textContainer.height / 2);
        }

        public float height
        {
            get { return ElementTexture.height; }
        }
    }
}
