using Game08;
using GameLib;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameproject
{
    public class MainScreen : Group
    {
        Group allObjs = new Group();
        Game game;
        public MainScreen(Game game)
        {
            this.game = game;
            allObjs.Add(new SoundJump());
            allObjs.Add(new Block(new FloatRect(0, 540, 1280, 300)));

            var dino = new Dino();
            allObjs.Add(dino);
            var spawnerWalk = new SpawnerWalk(allObjs);
            allObjs.Add(spawnerWalk);
            var spawnerFly = new SpawnerFly(allObjs);
            allObjs.Add(spawnerFly);

        }
    }
}
