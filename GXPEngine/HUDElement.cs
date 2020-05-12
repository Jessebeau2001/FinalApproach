using System;
using System.Drawing;

namespace GXPEngine
{
    class HUDElement : Pivot
    {
        Sprite ElementTexture; //For pictures to overlay over the HUD
        EasyDraw textContainer;

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
            textContainer = new EasyDraw(ElementTexture.width, ElementTexture.height, false);
            AddChild(textContainer);

            UpdateString(text);
        }

        public void UpdateString(string text)
        {
            if (text == null) return;
            textContainer.Clear(Color.Transparent);
            textContainer.Fill(0, 0, 0);
            textContainer.Text(text, textContainer.width / 2, textContainer.height / 2);
        }

        public float height
        {
            get { return ElementTexture.height; }
        }

        public float width
        {
            get { return ElementTexture.width; }
        }

    }
}
