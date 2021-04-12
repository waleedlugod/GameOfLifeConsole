using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Load("Board.txt");

            while (true)
            {
                Game.Draw();
                Game.Update();
            }
        }
    }
}
