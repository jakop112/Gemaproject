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
        Game game;
        public Background(Game game)
        {
            this.game = game;
            var sprite = new SpriteEntity();
            sprite.Scale = new Vector2f(2.5f, 2.5f);
            Add(sprite);
        }
  
    }
}
