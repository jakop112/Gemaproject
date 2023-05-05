using GameLib;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Gameproject
{
    public class Background : Group
    {
        Texture backgroundTexture;
        Sprite backgroundSprite;
        public Background()
        {
            backgroundTexture = new Texture("BG.png");

            backgroundSprite = new Sprite(backgroundTexture);
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(backgroundSprite);
        }

        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);
        }
    }
}
