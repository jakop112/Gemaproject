using GameLib;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SFML.System;

namespace Gameproject
{
    public class SpawnerWalk : Group
    {
        EnemyWalk enemyWalk;
        Group allObj;
        Clock clock;
        public SpawnerWalk(Group allObj)
        {
            Origin = new Vector2f(-1450, -350);

            this.enemyWalk = new EnemyWalk(allObj, Origin);
            this.allObj = allObj;

            //var obj = new RectangleEntity(rect.GetSize());
            //obj.OutlineColor = Color.Red;
            //obj.OutlineThickness = 4;   
            //Add(obj);

            clock = new Clock();
        }

        public override void FrameUpdate(float deltaTime)
        {
            if (clock.ElapsedTime.AsSeconds() > 3.0f) 
            {
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
