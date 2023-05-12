using GameLib;
using SFML.System;
using System;

namespace Gameproject
{
    public class SpawnerWalk : Group
    {
        EnemyWalk enemyWalk;
        Group allObj;
        Clock clock;
        Random rand;
        float randomtime;
        public SpawnerWalk(Group allObj)
        {
            Origin = new Vector2f(-1450, -350);

            this.enemyWalk = new EnemyWalk(allObj, Origin);
            this.allObj = allObj;
            rand = new Random();
            randomtime = rand.Next(2, 5);

            //var obj = new RectangleEntity(rect.GetSize());
            //obj.OutlineColor = Color.Red;
            //obj.OutlineThickness = 4;   
            //Add(obj);

            clock = new Clock();
        }

        public override void FrameUpdate(float deltaTime)
        {
            if (clock.ElapsedTime.AsSeconds() > randomtime) 
            {
                randomtime = rand.Next(2, 5);
                this.enemyWalk = new EnemyWalk(allObj, Origin);
                this.allObj.Add(this.enemyWalk);
                clock.Restart();
            }
            base.FrameUpdate(deltaTime);
        }

        public override void PhysicsUpdate(float fixTime)
        {
            base.PhysicsUpdate(fixTime);
        }
    }
}