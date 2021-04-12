using System;
using System.Threading;

namespace GameOfLife
{
    static class Game
    {
        private const int X = 15;
        private const int Y = 15;
        private static bool[,] board = new bool[X, Y];

        
        public static void Draw()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            string str = "";
            
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (Board[x, y])
                    {
                        // Alive
                        str += "#";
                    }
                    else
                    {
                        // Dead
                        str += ".";
                    }

                    str += " ";
                }
                str += "\n";
            }

            Console.Clear();
            Console.WriteLine(str);

            Thread.Sleep(1000);
        }

        public static void Update()
        {
            bool[,] tempBoard = (bool[,]) Board.Clone();
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    int liveCells = NeighborCellsCount(x, y);

                    if (liveCells < 2 || liveCells > 3)
                    {
                        tempBoard[x, y] = false;
                    }
                    else if (liveCells == 3)
                    {
                        tempBoard[x, y] = true;
                    }
                }
            }

            Board = tempBoard;
        }

        static int NeighborCellsCount(int x, int y)
        {
            int livingCells = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    // If inside bounds
                    if ((x + j >= 0) && (y + i >= 0) && (x + j <= X - 1) && (y + i <= Y - 1))
                    {
                        if (!(i == 0 && j == 0))
                        {
                            if (Board[x + j, y + i])
                            {
                                livingCells++;
                            }
                        }
                    }
                }
            }

            return livingCells;
        }

        public static bool[,] Board
        {
            get {return board;}
            set {board = value;}
        }
    }
}