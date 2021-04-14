using System;
using board;
using pieces;

namespace Console_Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            PiecePosition pos = new PiecePosition('a', 1);

            Console.WriteLine(pos);

            Console.WriteLine(pos.toPosition());
        }
    }
}
