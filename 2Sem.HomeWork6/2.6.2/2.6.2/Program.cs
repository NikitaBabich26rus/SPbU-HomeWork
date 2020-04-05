using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace _2._6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var game = new Game("../../../Map.txt");
                var eventLoop = new EventLoop();
                eventLoop.LeftHandler += game.ToTheLeft;
                eventLoop.RightHandler += game.ToTheRight;
                eventLoop.UpHandler += game.ToTheUp;
                eventLoop.DownHandler += game.ToTheDown;

                eventLoop.Run();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File is not found");
            }
            catch (InvalidMapException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
