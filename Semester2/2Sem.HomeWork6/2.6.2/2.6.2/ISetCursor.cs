using System;
using System.Collections.Generic;
using System.Text;

namespace _2._6._2
{
    /// <summary>
    /// ISetCursor interface.
    /// </summary>
    public interface ISetCursor
    {
        /// <summary>
        /// Set cursor for player position.
        /// </summary>
        /// <param name="x">Coordinate x</param>
        /// <param name="y">Coordinate y</param>
        void SetCursor(int x, int y);
    }
}
