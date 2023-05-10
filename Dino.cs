using GameLib;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Gameproject
{
    public class Dino : KinematicBody
    {
        CollisionObj collisionObj;
        bool onFloor;
        AnimationStates states;
        float speed = 0.5f;
        bool isJump = false;
        int jumpCount = 0;
        bool hit = false;
        Clock clockHit;

        public Dino() 
        {
            Origin = new Vector2f(-10, 30);

            var sprite = new SpriteEntity();
            //sprite.Position = new Vector2f(10, 390);
            sprite.Scale = new Vector2f(6, 6);
            Add(sprite);

            var texture = TextureCache.Get("Dino.png");
            var fragments = FragmentArray.Create(texture, 24, 24);
            var idle = new Animation(sprite, fragments.SubArray(4, 6), speed);
            var jump = new Animation(sprite, fragments.SubArray(10, 4), speed);
            var hurt = new Animation(sprite, fragments.SubArray(14, 3), speed);
            states = new AnimationStates(idle,jump,hurt);
            Add(states);

            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(0.7f, 0.7f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = true;
            collisionObj.OnCollide += OnCollide;
            Add(collisionObj);
        }

        Dictionary<CollisionObj, Vector2f> directions = new Dictionary<CollisionObj, Vector2f>();

        private void OnCollide(CollisionObj objB, CollideData Data)
        {
            var obstruction = objB.Parent as Obstruction;

            if (Data.FirstContact)
                directions[objB] = this.collisionObj.RelativeDirection(Data.OverlapRect);
            var direction = directions[objB];
            
            if (direction.Y == 1)
            {
                onFloor = true;
                jumpCount = 0;
            }

            if (direction.Y == 1 && obstruction == null)
            {
                isJump = false;
                V.Y = 0;
                Position -= new Vector2f(0, Data.OverlapRect.Height * direction.Y);
            }

            if (obstruction != null && !hit)
            {
                hit = true;
                clockHit = new Clock();
            }
            //else if (direction.X != 0)
            //{
            //    V.X = 0;
            //    Position -= new Vector2f(Data.OverlapRect.Width * direction.X, 0);
            //}
        }
        public override void KeyPressed(KeyEventArgs e)
        {
            base.KeyPressed(e);
            if (e.Code == Keyboard.Key.Space && jumpCount < 2) {
                jumpCount += 1;
                this.isJump = true;
                V.Y = -850;
            }
            
            
        }
        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);
            var direction = DirectionKey.Normalized;

            if (isJump && !hit)
            {
                states.Animate(1);
            }
            else if (hit)
            {
                states.Animate(2);
                if(clockHit.ElapsedTime.AsSeconds() > 0.8f)
                {
                    hit = false;
                }
            }
            else
                states.Animate(0);
           
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
