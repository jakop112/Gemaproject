using GameLib;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Gameproject
{
    
    public class Obstruction : KinematicBody
    {
        Group obj;
        CollisionObj collisionObj;
        Texture texture;
        float speed = 1.0f;
        bool onFloor;
        public Obstruction(Group allObjs)
        {
            this.obj = allObjs;
            monster();
        }
        private void monster() 
        {
            Origin = new Vector2f(-1290, -300);

            var sprite = new SpriteEntity();
            sprite.Scale = new Vector2f(3, 3);
            Add(sprite);

            texture = TextureCache.Get("mons.png");
            var fragments = FragmentArray.Create(texture, 48, 48);
            var walk = new Animation(sprite, fragments.SubArray(0, 8), speed);
            Add(walk);

            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(0.6f, 0.6f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = false;
            collisionObj.OnCollide += OnCollide;
            Add(collisionObj);
        }

        Dictionary<CollisionObj, Vector2f> directions = new Dictionary<CollisionObj, Vector2f>();

        private void OnCollide(CollisionObj objB, CollideData Data)
        {
            if (Data.FirstContact)
                directions[objB] = this.collisionObj.RelativeDirection(Data.OverlapRect);
            var direction = directions[objB];

            if (direction.Y == 1)
                onFloor = true;

            if (direction.Y == 1)
            {
                V.Y = 0;
                Position -= new Vector2f(0, Data.OverlapRect.Height * direction.Y);
            }
            else if (direction.X != 0)
            {
                V.X = 0;
                Position -= new Vector2f(Data.OverlapRect.Width * direction.X, 0);
            }
        }

        public override void FrameUpdate(float deltaTime)
        {  
            this.V.X = -300;
            base.FrameUpdate(deltaTime);
            if (Position.X < -1500)
            {
                Debug.WriteLine("die");
                this.Detach();
                this.obj.Add(new Obstruction(this.obj));
            }
        }
        public override void PhysicsUpdate(float fixTime)
        {
            onFloor = false;
            Vector2f a = new Vector2f(0, 2000);
            V += a * fixTime;
            base.PhysicsUpdate(fixTime);
        }
    }
}
