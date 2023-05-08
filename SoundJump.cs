using GameLib;
using SFML.Audio;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameproject
{
    public class SoundJump : BlankEntity
    {
        SoundBuffer buffer = new SoundBuffer("Jump.wav");
        Music music = new Music("song.ogg");
        
        public SoundJump()
        {
            Playsong();
        }
        public override void KeyPressed(KeyEventArgs e)
        {
            base.KeyPressed(e);
            if (e.Code == Keyboard.Key.Space)
            {
                Sound sound = new Sound(buffer);
                sound.Play();
            }
        }
        private void Playsong()
        { 
            music.Play();
        }
    }
}
