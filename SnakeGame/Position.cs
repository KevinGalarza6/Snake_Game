using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Position Zero = new Position() { X = 0, Y = 0 };
    }
}
