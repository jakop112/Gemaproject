using GameLib;
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

            var sprite = new RectangleEntity(rect.GetSize());
            sprite.Position = rect.GetPosition();
            Add(sprite);

            var shape = new CollisionRect(sprite.GetGlobalBounds());
            var collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = false;
            Add(collisionObj);
        }

      
    }
}
