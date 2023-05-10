using Game08;
using GameLib;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.ComponentModel;

namespace Gameproject
{
    public class Game
    {
        GameWindow window = new GameWindow(new VideoMode(1280, 720), "GameProject");
        Group allObjs = new Group();
 
        public void GameMain()
        {
            allObjs.Add(new SoundJump());
            allObjs.Add(new Block(new FloatRect(0, 540, 1280, 300)));

            var dino = new Dino();
            allObjs.Add(dino);

            //var enemyWalk = new EnemyWalk(allObjs);
            //allObjs.Add(enemyWalk);

            //var enemyFly = new EnemyFly(allObjs);
            //allObjs.Add(enemyFly);

            var spawnerWalk = new SpawnerWalk(allObjs);
            allObjs.Add(spawnerWalk);


            window.RunGameLoop(allObjs);
            
        }
    }
}
