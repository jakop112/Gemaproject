using GameLib;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameproject
{
    public class Enemy : KinematicBody
    {
        Group allObjs;
        CollisionObj collisionObj;
        Texture texture;
        float speed = 0.8f;

        public Enemy(Group allObjs)
        {

            this.allObjs = allObjs;

        }

        private void monsterfly()
        {
            //Origin = new Vector2f(-1290, -500);
            var sprite = new SpriteEntity();
            //sprite.Position = new Vector2f(1200, 300);
            sprite.Scale = new Vector2f(5, 5);
            Add(sprite);

            texture = TextureCache.Get("monsom.png");
            var fragments = FragmentArray.Create(texture, 16, 16);
            var walk = new Animation(sprite, fragments.SubArray(0, 4), speed);
            Add(walk);

            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(1.0f, 1.0f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = true;
            Add(collisionObj);
        }

        private void Monsterground()
        {
            //Origin = new Vector2f(-1290, -500);
            var sprite = new SpriteEntity();
            //sprite.Position = new Vector2f(1200, 300);
            sprite.Scale = new Vector2f(5, 5);
            Add(sprite);

            texture = TextureCache.Get("monsom.png");
            var fragments = FragmentArray.Create(texture, 16, 16);
            var walk = new Animation(sprite, fragments.SubArray(0, 4), speed);
            Add(walk);

            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(1.0f, 1.0f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = true;
            Add(collisionObj);
        }
    }
}
