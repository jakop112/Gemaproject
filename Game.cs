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

            var obj = new Obstruction(allObjs);
            allObjs.Add(obj);

            
            window.RunGameLoop(allObjs);
            
        }
    }
}
