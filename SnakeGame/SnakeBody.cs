using System.Collections.Generic;

namespace SnakeGame
{
    public class SnakeBody
    {
        public List<SnakeBodyPositions> History { get; set; }

        public bool IsHead { get; set; }
        
        public DirectionMovement directionMovementEnum { get; set; }
    }
}