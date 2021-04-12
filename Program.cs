using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates custom starting board
            // https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life#/media/File:Game_of_life_pulsar.gif
            for (int i = 0; i < 3; i++)
            {
                Game.Board[3 + i, 1] = true;
                Game.Board[9 + i, 1] = true;

                Game.Board[3 + i, 6] = true;
                Game.Board[9 + i, 6] = true;


                Game.Board[3 + i, 8] = true;
                Game.Board[9 + i, 8] = true;

                Game.Board[3 + i, 13] = true;
                Game.Board[9 + i, 13] = true;



                Game.Board[1, 3 + i] = true;
                Game.Board[6, 3 + i] = true;

                Game.Board[8, 3 + i] = true;
                Game.Board[13, 3 + i] = true;


                Game.Board[1, 9 + i] = true;
                Game.Board[6, 9 + i] = true;

                Game.Board[8, 9 + i] = true;
                Game.Board[13, 9 + i] = true;
            }

            while (true)
            {
                Game.Draw();
                Game.Update();
            }
        }
    }
}
