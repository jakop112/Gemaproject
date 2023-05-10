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
        protected Group allObjs;
        protected CollisionObj collisionObj;
        protected Texture texture;
        protected float speed = 0.8f;
        protected bool onFloor = false;
        public Obstruction(Group allObjs)
        {
            this.allObjs = allObjs;
        }

        protected Dictionary<CollisionObj, Vector2f> directions = new Dictionary<CollisionObj, Vector2f>();

        protected void OnCollide(CollisionObj objB, CollideData Data)
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
            //else if (direction.X != 0)
            //{
            //    V.X = 0;
            //    Position -= new Vector2f(Data.OverlapRect.Width * direction.X, 0);
            //}
        }
        
        public override void FrameUpdate(float deltaTime)
        {  
            this.V.X = -400;
            base.FrameUpdate(deltaTime);
            if (Position.X < -1500)
            {
                this.Detach();
            }
        }
        public override void PhysicsUpdate(float fixTime)
        {
            onFloor = false;
            //if (isWalk)
            //{
            //    Vector2f a = new Vector2f(0, 1000);
            //    V += a * fixTime;
            //}
 
            base.PhysicsUpdate(fixTime);
        }
    }
}
