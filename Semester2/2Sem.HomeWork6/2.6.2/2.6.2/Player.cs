using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _2._6._2
{
    /// <summary>
    /// Class player.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Current player`s coordinate x.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Current player`s coordinate y.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Player`s constructor.
        /// </summary>
        /// <param name="x">Coordinate x value</param>
        /// <param name="y">Coordinate y value</param>
        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Move around the map
        /// </summary>
        /// <param name="x">Coordinate x</param>
        /// <param name="y">Coordinate y</param>
        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }
    }
}
