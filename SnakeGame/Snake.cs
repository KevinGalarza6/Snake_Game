using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        const int initialPositionX = 5;
        const int initialPositionY = 5;
        //public const string Body = "#";
        //public const string Head = "O";

        public Position Head { get; set; }
        public Position Tail { get; set; }
        private bool _hasTails;

        public int Speed; //ms
        private Map _map;

        public Snake(Map map)
        {
            _map = map;
            Speed = 100;
            Head = new Position() { X = initialPositionX, Y = initialPositionY };
        }

        public void Input()
        {
        }

        private void UpdateTailPosition()
        {
            Tail = Head;
            _map.Board[Tail.X, Tail.Y] = Map.SnakeBody;
        }

        private void ClearTail()
        {
            _map.Board[Tail.X, Tail.Y] = Map.Empty;
        }

        internal void Eat(DirectionMovement direction)
        {
            ClearHead();
            MoveHead(direction);
            _hasTails = true;
        }

        private void ClearHead()
        {
            _map.Board[Head.X, Head.Y] = Map.Empty;
        }

        public void Move(DirectionMovement direction)
        {
            if (_hasTails)
            {
                ClearTail();
            }
            else
            {
                ClearHead();
            }

            MoveHead(direction);
        }

        private void MoveHead(DirectionMovement direction)
        {
            if (direction == DirectionMovement.Up)
            {
                Head = new Position() { X = Head.X, Y = Head.Y - 1 };
            }
            else if (direction == DirectionMovement.Left)
            {
                Head = new Position() { X = Head.X - 1, Y = Head.Y };
            }
            else if (direction == DirectionMovement.Down)
            {
                Head = new Position() { X = Head.X, Y = Head.Y + 1 };
            }
            else if (direction == DirectionMovement.Right)
            {
                Head = new Position() { X = Head.X + 1, Y = Head.Y };
            };

            _map.Board[Head.X, Head.Y] = Map.SnakeHead;
        }
    }
}
