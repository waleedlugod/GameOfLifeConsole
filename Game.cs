using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace GameOfLife
{
    static class Game
    {
        private static List<List<bool>> board = new List<List<bool>>();

        
        public static List<List<bool>> Load(string fileName)
        {
            TextReader textIn = new StreamReader(fileName);
            string text;
            int row = -1;
            
            while ((text = textIn.ReadLine()) != null)
            {
                char[] cells = text.ToCharArray();
                List<bool> tempRows = new List<bool>();
                row++;

                foreach (char cell in cells)
                {
                    switch (cell)
                    {
                        case '.':
                            tempRows.Add(false);
                            break;
                        case 'x':
                            tempRows.Add(true);
                            break;
                        default:
                            break;
                    }
                }

                board.Add(tempRows);
            }

            return board;
        }
        public static void Draw()
        {
            string str = "";
            
            for (int y = 0; y < board.Count; y++)
            {
                for (int x = 0; x < board[y].Count; x++)
                {
                    if (board[y][x])
                    {
                        // Alive
                        str += "# ";
                    }
                    else
                    {
                        // Dead
                        str += ". ";
                    }
                }
                str += "\n";
            }

            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            Console.Clear();
            
            Console.WriteLine(str);

            Thread.Sleep(1000);
        }

        public static void Update()
        {
            List<List<bool>> tempBoard = new List<List<bool>>();

            // Copies board to temporary board
            // since we need to change the whole board
            // at the same time not cell by cell
            foreach (List<bool> row in board)
            {
                tempBoard.Add(new List<bool>(row));
            }  

            for (int y = 0; y < board.Count; y++)
            {
                for (int x = 0; x < board[y].Count; x++)
                {
                    int liveCells = NeighborCellsCount(x, y);

                    if (liveCells < 2 || liveCells > 3)
                    {
                        tempBoard[y][x] = false;
                    }
                    else if (liveCells == 3)
                    {
                        tempBoard[y][x] = true;
                    }
                }
            }

            board = tempBoard;
        }

        static int NeighborCellsCount(int x, int y)
        {
            int livingCells = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    // If cell is not itself
                    if (!(i == 0 && j == 0))
                    {
                        if ((x + j >= 0) // To the right of the leftmost boundary
                            && (x + j < board[y].Count) // To the left of the rightmost boundary
                            && (y + i >= 0) // Lower than the uppermost boundary
                            && (y + i < board.Count)) // Higher than the lowermost boundary)
                        {
                            // If current cell is alive
                            if (board[y + i][x + j])
                            {
                                livingCells++;
                            }
                        }
                    }
                }
            }

            return livingCells;
        }
    }
}