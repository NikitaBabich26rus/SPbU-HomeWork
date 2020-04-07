using System;
using System.Collections.Generic;
using System.Text;


namespace _2._6._2
{
    /// <summary>
    /// Game's class
    /// </summary>
    public class Game
    {
        public GameMap gameMap { get; private set; }

        /// <summary>
        /// Game's constructor
        /// </summary>
        /// <param name="file">File with map</param>
        public Game(string file)
        {
            gameMap = new GameMap(file);
            gameMap.Print();
        } 

        /// <summary>
        /// Go on the left
        /// </summary>
        public void ToTheLeft(object sender, EventArgs args)
        {
            gameMap.MoveTo(-1, 0);
            gameMap.Print();
        }

        /// <summary>
        /// Go on the right
        /// </summary>
        public void ToTheRight(object sender, EventArgs args)
        {
            gameMap.MoveTo(1, 0);
            gameMap.Print();
        }

        /// <summary>
        /// Go to the top
        /// </summary>
        public void ToTheUp(object sender, EventArgs args)
        {
            gameMap.MoveTo(0, -1);
            gameMap.Print();
        }

        /// <summary>
        /// Go to the down
        /// </summary>
        public void ToTheDown(object sender, EventArgs args)
        {
            gameMap.MoveTo(0, 1);
            gameMap.Print();
        }
    }
}
