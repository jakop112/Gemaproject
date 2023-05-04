using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace GameLib
{
    public class GameWindow : RenderWindow
    {
        public CollisionDetection CollisionDetectionUnit { get; } = new CollisionDetection();
        private Group allObjs = new Group();
        public GameWindow(VideoMode mode, string title) : base(mode, title)
        {
            this.Closed += WindowClosed;

            this.KeyPressed += GameWindow_KeyPressed;
            this.TextEntered += GameWindow_TextEntered;
            this.KeyReleased += GameWindow_KeyReleased;

            this.MouseButtonPressed += GameWindow_MouseButtonPressed;
            this.MouseButtonReleased += GameWindow_MouseButtonReleased;
            this.MouseMoved += GameWindow_MouseMoved;
            this.MouseWheelScrolled += GameWindow_MouseWheelScrolled;
        }

        private void GameWindow_MouseWheelScrolled(object? sender, MouseWheelScrollEventArgs e)
        {
            allObjs.MouseWheelScrolled(e);
        }

        private void GameWindow_MouseMoved(object? sender, MouseMoveEventArgs e)
        {
            allObjs.MouseMoved(e);
        }

        private void GameWindow_MouseButtonReleased(object? sender, MouseButtonEventArgs e)
        {
            allObjs.MouseButtonReleased(e);
        }

        private void GameWindow_MouseButtonPressed(object? sender, MouseButtonEventArgs e)
        {
            allObjs.MouseButtonPressed(e);
        }

        private void GameWindow_KeyReleased(object? sender, KeyEventArgs e)
        {
                allObjs.KeyReleased(e);
        }

        private void GameWindow_TextEntered(object? sender, TextEventArgs e)
        {
                allObjs.TextEntered(e);
        }

        private void GameWindow_KeyPressed(object? sender, KeyEventArgs e)
        {
                allObjs.KeyPressed(e);
        }

        const int cutoffRatio = 20; // physics update will do at most 20 times per frame
        public void RunGameLoop(Group allObjs)
        {
            this.allObjs = allObjs;
            var clock = new Clock();
            float physicsInterval = 1 / 120.0f;
            float physicsCutoff = (-1 / 8f) * physicsInterval;
            float remainder = 0;
            while (this.IsOpen) // Game Loop
            {
                // Event Dispatching
                DispatchEvents();

                // Game State Updating
                float deltaTime = clock.Restart().AsSeconds();
                remainder += deltaTime;
                int i = 0;
                while (remainder - physicsInterval >= physicsCutoff)
                {
                    PhysicsUpdateAll(physicsInterval);
                    CollisionDetectionUnit.DetectAndResolve(allObjs);

                    remainder -= physicsInterval;

                    i++;
                    if (i >= cutoffRatio)
                    {
                        remainder = 0;
                        break;
                    }
                }
                FrameUpdateAll(deltaTime);

                // Rendering
                Clear(new Color(200, 200, 200)); // Background Color
                DrawAll();
                Display();
            }
        }

        private void PhysicsUpdateAll(float physicsInterval)
        {
                allObjs.PhysicsUpdate(physicsInterval);
        }

        private void FrameUpdateAll(float deltaTime)
        {
                allObjs.FrameUpdate(deltaTime);
        }
        private void DrawAll()
        {
            this.Draw(allObjs);
        }

        void WindowClosed(object? sender, EventArgs e)
        {
            var window = (RenderWindow)sender!;
            window.Close();
        }
    }
}
