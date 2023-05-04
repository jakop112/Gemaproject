using GameLib;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Label : Group
    {
        public Label(string name, uint fontsize)
        {
            var font = FontCache.Get("Thasadith-Regular.ttf");
            var text = new TextEntity(name, font, fontsize);
            text.FillColor = Color.Blue;

            var bound = text.GetLocalBounds();

            var rect = new RectangleEntity(new Vector2f(bound.Width, font.GetLineSpacing(fontsize)));
            rect.FillColor = Color.White;

            this.Add(rect);
            this.Add(text);
        }
    }
}
