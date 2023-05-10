using GameLib;
using Gameproject;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game08
{
    public class Block : Group
    {
       
        public Block(FloatRect rect)
        {

            var sprite = new SpriteEntity(new Texture("tileset.png"));
            sprite.Position = rect.GetPosition();
            sprite.Scale = new Vector2f(2,1);
            Add(sprite);

            var shape = new CollisionRect(sprite.GetGlobalBounds());
            var collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = true;
            Add(collisionObj);
        }

      
    }
}
