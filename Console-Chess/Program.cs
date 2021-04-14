using System;
using board;

namespace Console_Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board brd = new Board(8,8);

            Screen.printBoard(brd);
        }
    }
}
