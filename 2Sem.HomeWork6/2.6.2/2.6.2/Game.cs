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
        private bool PassingTests;

        /// <summary>
        /// Map for game.
        /// </summary>
        public GameMap GameMap { get; private set; }

        /// <summary>
        /// PLayer.
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// Game's constructor
        /// </summary>
        /// <param name="file">File with Map</param>
        public Game(string file)
        {
            GameMap = new GameMap(file);
            GameMap.Print();
            Player = new Player(GameMap.X, GameMap.Y);
        } 

        /// <summary>
        /// Game`s constructor for tests.
        /// </summary>
        /// <param name="file">File with Map</param>
        /// <param name="PassingTests">Value for passing tests(True : If you want to passed tests)</param>
        public Game(string file, bool PassingTests)
        {
            this.PassingTests = PassingTests;
            GameMap = new GameMap(file);
            Player = new Player(GameMap.X, GameMap.Y);
        }

        /// <summary>
        /// Go on the left
        /// </summary>
        public void ToTheLeft(object sender, EventArgs args) => MoveTo(-1, 0);

        /// <summary>
        /// Go on the right
        /// </summary>
        public void ToTheRight(object sender, EventArgs args) => MoveTo(1, 0);

        /// <summary>
        /// Go to the top
        /// </summary>
        public void ToTheUp(object sender, EventArgs args) => MoveTo(0, -1);

        /// <summary>
        /// Go to the down
        /// </summary>
        public void ToTheDown(object sender, EventArgs args) => MoveTo(0, 1);

        /// <summary>
        /// Move on the Map
        /// </summary>
        /// <param name="x">Coordinate X</param>
        /// <param name="y">Coordinate Y</param>
        public void MoveTo(int x, int y)
        {
            if (Player.X + x < 0 || Player.Y + y < 0 || Player.X + x >= GameMap.Map.GetLength(1)
                || Player.Y + y >= GameMap.Map.GetLength(0) || GameMap.Map[Player.Y + y, Player.X + x])
            {
                return;
            }
            if (PassingTests)
            {
                Player.Move(x, y);
                return;
            }
            Console.SetCursorPosition(Player.X, Player.Y);
            Console.Write(' ');
            Player.Move(x, y);
            Console.SetCursorPosition(Player.X, Player.Y);
            Console.Write('@');
            Console.SetCursorPosition(Player.X, Player.Y);
        }
    }
}
