using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Game
    {
        private Snake _snake;
        private Map _map;
        private DirectionMovement _directionMovement;

        public Game()
        {
            _map = new Map();
            _snake = new Snake(_map);
        }

        public void Initialize()
        {
            _map.Initialize();
            _map.SpawnFood();
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                ReadMovement();
            }
        }

        public void Update()
        {
            Thread.Sleep(_snake.Speed);

            var item = GetNextBoardItem();

            if (item == Map.Empty)
            {
                _snake.Move(_directionMovement);
            }
            else if (item == Map.Food)
            {
                _snake.Eat(_directionMovement);
                _map.SpawnFood();
            }
            else if (item == Map.Roof || item == Map.Wall)
            {
                Environment.Exit(0);
            }
        }

        private char GetNextBoardItem()
        {
            Position position = Position.Zero;

            switch (_directionMovement)
            {
                case DirectionMovement.Up:
                    position = new Position() { X = _snake.Head.X, Y = _snake.Head.Y - 1 };
                    break;
                case DirectionMovement.Left:
                    position = new Position() { X = _snake.Head.X - 1, Y = _snake.Head.Y };
                    break;
                case DirectionMovement.Down:
                    position = new Position() { X = _snake.Head.X, Y = _snake.Head.Y + 1 };
                    break;
                case DirectionMovement.Right:
                    position = new Position() { X = _snake.Head.X + 1, Y = _snake.Head.Y };
                    break;
                default:
                    position = Position.Zero;
                    break;
            }

            return _map.Board[position.X, position.Y];
        }

        private void ReadMovement()
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.A)
            {
                _directionMovement = DirectionMovement.Left;
            }
            else if (key.Key == ConsoleKey.W)
            {
                _directionMovement = DirectionMovement.Up;
            }
            else if (key.Key == ConsoleKey.S)
            {
                _directionMovement = DirectionMovement.Down;
            }
            else if (key.Key == ConsoleKey.D)
            {
                _directionMovement = DirectionMovement.Right;
            }
        }

        public void Draw()
        {
            _map.Draw();
        }

        /*
        private void ValidateMovement(Position position)
        {
            if (position.X >= Map.BoardWidth - 1 ||
                position.Y >= Map.BoardHeight - 1 ||
                position.X == 0 ||
                position.Y == 0)
            {
                position.X = 5;
                position.Y = 5;

            }
        }

        private void ClearLastSnakeBodyDraw()
        {
            foreach (SnakeBody position in Positions)
            {
                Console.SetCursorPosition(position.History.LastOrDefault().PositionX, position.History.LastOrDefault().PositionY);
                Console.Write(" ");
            }
        }
        */
    }
}
