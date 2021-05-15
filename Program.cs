using System;
using SFML.System;
using SFML.Graphics;

namespace Interloper
{

    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC key to close window");
            GameWindow window = new GameWindow();
            window.Run();
        }
    }

    class GameWindow
    {

        //  The primary rendering window object 
        private RenderWindow window;
        private Clock clock;

        private int previousSecond;
        public void Run()
        {
            InitAndConfigureWindow();

            Ball ball = new Ball(window, new Vector2f(NextFloat(-10f, 10f), NextFloat(-10f, 10f)), 25f);
            Ball ball2 = new Ball(window, new Vector2f(NextFloat(-10f, 10f), NextFloat(-10f, 10f)), 5f);
            Ball ball3 = new Ball(window, new Vector2f(NextFloat(-10f, 10f), NextFloat(-10f, 10f)), 10f);
            Ball ball4 = new Ball(window, new Vector2f(NextFloat(-10f, 10f), NextFloat(-10f, 10f)), 35f);

            ball.Position = new Vector2f(window.Size.X / 2, window.Size.Y / 2);
            ball2.Position = new Vector2f(window.Size.X / 2, window.Size.Y / 2);
            ball3.Position = new Vector2f(window.Size.X / 2, window.Size.Y / 2);
            ball4.Position = new Vector2f(window.Size.X / 2, window.Size.Y / 2);

            // Start the game loop
            while (window.IsOpen)
            {
                window.Clear();

                // Process events
                window.DispatchEvents();
                previousSecond = GetCurrentSecond();

                ball.Move();
                ball2.Move();
                ball3.Move();
                ball4.Move();

                //  Draw
                window.Draw(ball);
                window.Draw(ball2);
                window.Draw(ball3);
                window.Draw(ball4);


                // Display
                window.Display();
            }
        }


        // Init the game window
        private void InitAndConfigureWindow()
        {
            var mode = new SFML.Window.VideoMode(800, 600);
            window = new SFML.Graphics.RenderWindow(mode, "Interloper");
            window.SetFramerateLimit(60);
            window.KeyPressed += HandleKeypress;

            clock = new SFML.System.Clock();
        }

        /// <summary>
        /// Main callback for keypresses
        /// </summary>
        private void HandleKeypress(object sender, SFML.Window.KeyEventArgs e)
        {
            var window = (SFML.Window.Window)sender;
            if (e.Code == SFML.Window.Keyboard.Key.Escape)
            {
                window.Close();
            }
        }

        int GetCurrentSecond()
        {
            return (int)clock.ElapsedTime.AsSeconds();
        }


        // Utility for gening random numbers
        static float NextFloat(float min, float max)
        {
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }
    }
}
