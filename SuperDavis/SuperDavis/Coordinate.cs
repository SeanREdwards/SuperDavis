/*
 * Coordinate Object to easily pass individual sprite frame information for sprite generation.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis
{
    class Coordinate
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinate(int xCoord, int yCoord, int width, int height)
        {
            X = xCoord;
            Y = yCoord;
            Width = width;
            Height = height;
        }
    }
}