using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    /*
    class Utils
    {
        public static void DrawChar(char c, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(c);
            } 
            catch (ArgumentOutOfRangeException a)
            {
                System.Diagnostics.Debug.WriteLine(a.Message);
            }
        }
    }
    */

    class Program
    {
        static void Main(string[] args)
        {
            /*
            Utils.DrawChar('A', 10, 10);
            Console.ReadKey();
            */

            //Controlar fps
            int fps = 0;
            int desiredFPS = 30;
            double inverseDesiredFPS = 1.0 / desiredFPS;
            DateTime currentTime;
            TimeSpan deltaTime;

            int frameCount = 0;
            DateTime lastTime = DateTime.Now;
            double elapsedTime = 0;

            var game = new Game();
            game.Initialize();

            while (true)
            {
                game.Input();
                game.Update();
                game.Draw();

                //Console.SetCursorPosition(0, 21);
                //Console.WriteLine("");
                //Console.WriteLine($"FPS: {fps}/{inverseDesiredFPS}/{desiredFPS}");

                currentTime = DateTime.Now;
                deltaTime = currentTime - lastTime;

                elapsedTime += deltaTime.TotalSeconds;

                while (deltaTime.TotalSeconds <= inverseDesiredFPS)
                {
                    deltaTime = DateTime.Now - lastTime;
                }

                if (elapsedTime >= 1)
                {
                    fps = frameCount;
                    frameCount = 0;
                    elapsedTime--;
                }

                lastTime = currentTime;

                frameCount++;
            }
        }
    }
}
