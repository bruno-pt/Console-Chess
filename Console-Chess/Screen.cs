using System;
using board;

namespace Console_Chess
{
    class Screen
    {
        public static void printBoard(Board brd)
        {
            for(int i=0; i<brd.rows; i++)
            {
                for(int j=0; j<brd.columns; j++)
                {
                    if(brd.piece(i,j) == null)
                        Console.Write("- ");
                    else
                        Console.Write(brd.piece(i,j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
