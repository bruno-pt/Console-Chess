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
                Console.Write(8 - i + " ");
                for(int j=0; j<brd.columns; j++)
                {
                    if (brd.piece(i, j) == null)
                        Console.Write("- ");
                    else
                    {
                        printPiece(brd.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printPiece(Piece piece)
        {
            if(piece.color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;

            }
        }
    }
}
