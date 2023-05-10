using GameLib;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameproject
{
    public class TitleScreen : Group
    {
        Game game;
        public TitleScreen(Game game)
        {
            this.game = game;
            var sprite = new SpriteEntity("Screen.png");
            sprite.Scale = new Vector2f(2.5f, 2.5f);
            Add(sprite);
        }

       
    }
}
