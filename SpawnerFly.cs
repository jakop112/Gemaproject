using GameLib;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameproject
{
    public class SpawnerFly : Group
    {
        EnemyFly enemyfly;
        Group allObj;
        Clock clock;
        Random rand;
        float randomtime;
        public SpawnerFly(Group allObjs)
        {
            Origin = new Vector2f(-1450, -250);
            this.enemyfly = new EnemyFly(allObjs,Origin);
            this.allObj = allObjs;
            rand = new Random();
            randomtime = rand.Next(2,5);
            clock = new Clock();
            
        }
        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);
            if (clock.ElapsedTime.AsSeconds() > randomtime)
            {
                randomtime = rand.Next(2, 5);
                this.enemyfly = new EnemyFly(allObj, Origin);
                this.allObj.Add(this.enemyfly);
                clock.Restart();
            }

        }
        public override void PhysicsUpdate(float fixTime)
        {
            base.PhysicsUpdate(fixTime);
        }
    }
}
