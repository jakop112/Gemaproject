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
using System.Windows.Forms;

namespace Gameproject
{
    
    public class Obstruction : KinematicBody
    {
        Group obj;
        CollisionObj collisionObj;
        Texture texture;
        float speed = 0.8f;
        bool onFloor;
        bool isFly = false;
        bool isWalk = false;
        public Obstruction(Group allObjs)
        {
            Random rand = new Random();
            var number = rand.Next(0,2);
            if (number == 0)
            {
                isWalk = true;
                isFly = false;
            }
            else
            {
                isWalk = false;
                isFly = true;
            }
            this.obj = allObjs;
            anothermonster();
            monster();
        }
        private void monster()
        {
            //Origin = new Vector2f(-1290, -300);
            var spritepee = new SpriteEntity();
            spritepee.Scale = new Vector2f(4, 4);
            //spritepee.Position = new Vector2f(1200,300);
            Add(spritepee);

            texture = TextureCache.Get("monpee.png");
            var fragments = FragmentArray.Create(texture, 32, 32);
            var fly = new Animation(spritepee, fragments.SubArray(0, 4), speed);
            Add(fly);

            var shape = new CollisionRect(spritepee.GetGlobalBounds().AdjustSize(0.7f, 0.7f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = true;
            collisionObj.OnCollide += OnCollide;
            Add(collisionObj);
        }
        private void anothermonster()
        {
            //Origin = new Vector2f(-1290, -300);
            var sprite = new SpriteEntity();
            sprite.Position = new Vector2f(1200, 300);
            sprite.Scale = new Vector2f(5, 5);
            Add(sprite);

            texture = TextureCache.Get("monsom.png");
            var fragments = FragmentArray.Create(texture, 16, 16);
            var walk = new Animation(sprite, fragments.SubArray(0, 4), speed);
            Add(walk);

            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(1.0f, 1.0f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = true;
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
            if (isWalk)
            {
                Vector2f a = new Vector2f(0, 1000);
                V += a * fixTime;
            }
 
            base.PhysicsUpdate(fixTime);
        }
    }
}
