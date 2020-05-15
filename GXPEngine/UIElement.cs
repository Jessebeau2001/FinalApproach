using System;
using System.Drawing;

namespace GXPEngine
{
    class UIElement : Pivot
    {
        Sprite ElementTexture; //For pictures to overlay over the HUD
        EasyDraw textContainer;

        public UIElement(float x, float y, string texturePath, string UIText = null)
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
            textContainer.TextAlign(CenterMode.Center, CenterMode.Center);
            UpdateString(text);
            AddChild(textContainer);
        }

        public void UpdateString(string text)
        {
            if (text == null) return;
            textContainer.Clear(Color.Transparent);
            textContainer.Fill(0, 0, 0);
            textContainer.Text(text, textContainer.width / 2, textContainer.height / 2);
        }

        public void SetOrigin(float x, float y)
        {
            this.x -= x;
            this.y -= y;
        }

        public bool IsClicked(float mouseX, float mouseY)
        {
            if (mouseX > x && mouseX < x + ElementTexture.width)
                if (mouseY > y && mouseY < y + ElementTexture.height)
                    if(Input.GetMouseButtonUp(0))
                        return true;
            return false;
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
