using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;

namespace _2._6._2
{
    /// <summary>
    /// Map`s class
    /// </summary>
    /// 
    public class GameMap
    {
        /// <summary>
        /// Start player coordinate x.
        /// </summary>
        public int X { get; private set; } = -1;

        /// <summary>
        /// Start player coordinate y.
        /// </summary>
        public int Y { get; private set; } = -1;

        /// <summary>
        /// Map.
        /// </summary>
        public bool[,] Map { get; private set; }

        /// <summary>
        /// GameMap`s constructor
        /// </summary>
        /// <param name="file">File with Map</param>
        public GameMap(string file)
        {
            string line;
            using (var sr = new StreamReader(file))
            {
                line = sr.ReadToEnd();
                sr.Close();
            }
            CreateTheMap(line);
        }

        /// <summary>
        /// Create the Map 
        /// </summary>
        /// <param name="line">String with Map</param>
        public void CreateTheMap(string line)
        {
            int columnCounter = 0;
            int columnCounterMax = 0;
            int stringCounter = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != '\n' && line[i] != '\r')
                {
                    columnCounter++;
                }
                if (line[i] == '\n' || i == line.Length - 1)
                {
                    stringCounter++;
                    if (columnCounter > columnCounterMax)
                    {
                        columnCounterMax = columnCounter;
                    }
                    columnCounter = 0;
                }
            }
            Map = new bool[stringCounter, columnCounterMax];
            int k = 0;
            int l = 0;
            for (int count = 0; count < line.Length; count++)
            {
                if (line[count] == '@')
                {
                    this.X = l;
                    this.Y = k;
                }
                if (line[count] == 'A')
                {
                    Map[k, l] = true;
                }
                if (line[count] == '\n')
                {
                    k++;
                    l = -1;
                }
                l++;
            }
            if (this.X < 0 || this.Y < 0)
            {
                throw new InvalidMapException("No player on the map");
            }
        }

        /// <summary>
        /// Print the map with player`s start position.
        /// </summary>
        public void Print()
        { 
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (j == this.X && i == this.Y)
                    {
                        Console.Write('@');
                    }
                    else if (Map[i, j])
                    {
                        Console.Write('A');                
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
