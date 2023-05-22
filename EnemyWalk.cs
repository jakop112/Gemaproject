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
    public class EnemyWalk : Obstruction
    {
        public EnemyWalk(Group allObjs, Vector2f origin) : base(allObjs)
        {
            Origin = origin;
            var sprite = new SpriteEntity();
            sprite.Scale = new Vector2f(5, 5);
            Add(sprite);
            
            texture = TextureCache.Get("monsom.png");
            var fragments = FragmentArray.Create(texture, 16, 16);
            var walk = new Animation(sprite, fragments.SubArray(0, 4), speed);
            Add(walk);

            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(0.8f, 0.8f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = false;
            collisionObj.OnCollide += OnCollide;
            Add(collisionObj);
        }

        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);
        }

        public override void PhysicsUpdate(float fixTime)
        {
            Vector2f a = new Vector2f(0, 1000);
            V += a * fixTime;
            base.PhysicsUpdate(fixTime);
        }
    }
}
