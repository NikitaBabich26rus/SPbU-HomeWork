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
        private ISetCursor cursor;

        /// <summary>
        /// Class for "Console.SetCursorPosition()" operation. 
        /// </summary>
        private class Cursor : ISetCursor
        {
            /// <summary>
            /// Console.SetCursorPosition(x, y) operation.
            /// </summary>
            /// <param name="x">Coordinate x</param>
            /// <param name="y">Coordinate y</param>
            public void SetCursor(int x, int y) => Console.SetCursorPosition(x, y);
        }

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
            cursor = new Cursor();
            GameMap = new GameMap(file);
            GameMap.Print();
            Player = new Player(GameMap.X, GameMap.Y);
        } 

        /// <summary>
        /// Game`s constructor with ISetCursor.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="cursor"></param>
        public Game(string file, ISetCursor cursor)
        {
            this.cursor = cursor;
            GameMap = new GameMap(file);
            GameMap.Print();
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
            cursor.SetCursor(Player.X, Player.Y);
            Console.Write(' ');
            Player.Move(x, y);
            cursor.SetCursor(Player.X, Player.Y);
            Console.Write('@');
            cursor.SetCursor(Player.X, Player.Y);
        }
    }
}
