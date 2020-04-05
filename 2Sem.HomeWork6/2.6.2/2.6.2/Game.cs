using System;
using System.Collections.Generic;
using System.Text;

namespace _2._6._2
{
    public class Game
    {
        public GameMap gameMap { get; private set; }

        public Game(string file)
        {
            gameMap = new GameMap(file);
            gameMap.Print();
        } 

        public void ToTheLeft(object sender, EventArgs args)
        {
            gameMap.MoveTo(-1, 0);
            gameMap.Print();
        }

        public void ToTheRight(object sender, EventArgs args)
        {
            gameMap.MoveTo(1, 0);
            gameMap.Print();
        }

        public void ToTheUp(object sender, EventArgs args)
        {
            gameMap.MoveTo(0, -1);
            gameMap.Print();
        }

        public void ToTheDown(object sender, EventArgs args)
        {
            gameMap.MoveTo(0, 1);
            gameMap.Print();
        }
    }
}
