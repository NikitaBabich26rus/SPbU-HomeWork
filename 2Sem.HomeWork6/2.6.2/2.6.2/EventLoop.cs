using System;
using System.Collections.Generic;
using System.Text;

namespace _2._6._2
{
    /// <summary>
    /// Events class
    /// </summary>
    public class EventLoop
    {
        /// <summary>
        /// Event for going to the top
        /// </summary>
        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

        /// <summary>
        /// Event for going to the down
        /// </summary>
        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

        /// <summary>
        /// Event for going on the left
        /// </summary>
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };

        /// <summary>
        /// Event for going on the right
        /// </summary>
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

        /// <summary>
        /// Class for going on the map
        /// </summary>
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        LeftHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.RightArrow:
                        RightHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.UpArrow:
                        UpHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.DownArrow:
                        DownHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.Enter:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
