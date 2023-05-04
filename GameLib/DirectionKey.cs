using SFML.System;
using SFML.Window;
using System;

namespace GameLib
{
    public class DirectionKey
    {
        private static float sin45 = MathF.Sin(MathF.PI / 4.0f);
        public static Vector2f Direction
        {
            get
            {
                Vector2f direction = new Vector2f();
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                    direction += new Vector2f(1, 0);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                    direction += new Vector2f(-1, 0);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                    direction += new Vector2f(0, -1);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                    direction += new Vector2f(0, 1);
                return direction;
            }
        }
        public static Vector2f Normalized
        {
            get
            {
                var direction = Direction;
                if (direction.X != 0 && direction.Y != 0)
                    direction *= sin45;
                return direction;
            }
        }
    }
}
