using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Map
    {
        public const int BoardWidth = 60;
        public const int BoardHeight = 20;

        public const char Roof = '─';
        public const char Wall = '│';
        public const char TopRightCorner = '┐';
        public const char TopLeftCorner = '┌';
        public const char BottomRightCorner = '┘';
        public const char BottomLeftCorner = '└';
        public const char Food = '*';
        public const char SnakeBody = '#';
        public const char SnakeHead = 'O';
        public const char Empty = ' ';
        private Random _random = new Random();
        private readonly char[,] _board = new char[BoardWidth, BoardHeight];
        public char[,] Board { get { return _board; } }

        public Map()
        {
            NewGame();
        }

        public void Input()
        {
        }

        public void Update()
        {
        }

        public void SpawnFood()
        {
            int x = _random.Next(1, BoardWidth - 1);
            int y = _random.Next(1, BoardHeight - 1);

            _board[x, y] = Food;
        }

        public void Draw()
        {
            for (var y = BoardHeight - 1; y >= 0; y--)
            {
                for (var x = 0; x < BoardWidth; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(_board[x, y]);
                }
            }
        }

        public void Initialize()
        {
            for (var y = BoardHeight - 1; y >= 0; y--)
            {
                for (var x = 0; x < BoardWidth; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(_board[x, y]);
                }
            }
        }

        internal void NewGame()
        {
            for (var y = 0; y < BoardHeight; y++)
            {
                for (var x = 0; x < BoardWidth; x++)
                {
                    if (x == 0 && y == 0)
                    {
                        _board[x, y] = BottomLeftCorner;
                    }
                    else if (x == BoardWidth - 1 && y == 0)
                    {
                        _board[x, y] = BottomRightCorner;
                    }
                    else if (x == 0 && y == BoardHeight - 1)
                    {
                        _board[x, y] = TopLeftCorner;
                    }
                    else if (x == BoardWidth - 1 && y == BoardHeight - 1)
                    {
                        _board[x, y] = TopRightCorner;
                    }
                    else if (x == 0 || x == BoardWidth - 1)
                    {
                        _board[x, y] = Wall;
                    }
                    else if (y == 0 || y == BoardHeight - 1) 
                    {
                        _board[x, y] = Roof;
                    }
                    else
                    {
                        _board[x, y] = Empty;
                    }
                } 
            }
        }
    }
}