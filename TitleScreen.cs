using GameLib;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameproject
{
    public class TitleScreen : Group
    {
        Game game;
        public TitleScreen(Game game)
        {
            this.game = game;
            var sprite = new SpriteEntity("Screen.png");
            sprite.Scale = new Vector2f(1.0f, 1.0f);
            Origin = new Vector2f(0, 0);
            Add(sprite);
            Buttonimg();
        }

        public void Buttonimg()
        {
            var font = FontCache.Get("Thasadith-Regular.ttf");
            var buttonimg = new SpriteEntity("Button.png") { Scale = new Vector2f(1.0f, 1.0f) };
            var playbutton = new ImageButton("Play", font, 40, buttonimg);
            
            Add(playbutton);

        }
        public override void MouseButtonPressed(MouseButtonEventArgs e)
        {
            base.MouseButtonPressed(e);
            game.StartMainScene();
        }


    }
}
