using Game08;
using GameLib;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.ComponentModel;

namespace Gameproject
{
    public class Game : Group
    {
        GameWindow window = new GameWindow(new VideoMode(1280, 720), "GameProject");
        Group allObjs = new Group();
        Group screen = new Group();
        TitleScreen titlescreen;
        MainScreen mainScreen;
        GameOver gameover;
        public Game()
        {
            titlescreen = new TitleScreen(this);
            mainScreen = new MainScreen(this);
            gameover = new GameOver(this);
        }
        public void GameMain()
        {
            //allObjs.Add(new SoundJump());
            //allObjs.Add(new Block(new FloatRect(0, 540, 1280, 300)));

            //var dino = new Dino();
            //allObjs.Add(dino);

            ////var enemyWalk = new EnemyWalk(allObjs);
            ////allObjs.Add(enemyWalk);

            ////var enemyFly = new EnemyFly(allObjs);
            ////allObjs.Add(enemyFly);

            //var spawnerWalk = new SpawnerWalk(allObjs);
            //allObjs.Add(spawnerWalk);
            //var spawnerFly = new SpawnerFly(allObjs);
            //allObjs.Add(spawnerFly);

            allObjs.Add(this);
            allObjs.Add(screen);
            screen.Add(titlescreen);

            window.RunGameLoop(allObjs);
            
        }

        public void StartMainScene()
        {
            screen.Clear();
            screen.Add(mainScreen);
        }
        public void StopMainScene()
        {
            screen.Clear();
            screen.Add(gameover);
        }
        public void Reset()
        {
            screen.Clear();
            screen.Add(titlescreen);
        }
    }
}
