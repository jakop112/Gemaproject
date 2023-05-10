using GameLib;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameproject
{
    internal class EnemyFly : Obstruction
    {
        public EnemyFly(Group allObjs, Vector2f origin) : base(allObjs)
        {

            Origin = new Vector2f(-1290, -300);
            var spritepee = new SpriteEntity();
            spritepee.Scale = new Vector2f(4, 4);
            Add(spritepee);

            texture = TextureCache.Get("monpee.png");
            var fragments = FragmentArray.Create(texture, 32, 32);
            var fly = new Animation(spritepee, fragments.SubArray(0, 4), speed);
            Add(fly);

            var shape = new CollisionRect(spritepee.GetGlobalBounds().AdjustSize(0.5f, 0.5f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = true;
            //collisionObj.OnCollide += OnCollide;
            Add(collisionObj);
        }

        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);
        }

        public override void PhysicsUpdate(float fixTime)
        {
            base.PhysicsUpdate(fixTime);
        }
    }
}
