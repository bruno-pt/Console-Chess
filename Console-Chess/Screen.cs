using System;
using System.Collections.Generic;
using board;
using pieces;

namespace Console_Chess
{
    class Screen
    {   

        public static void printMatch(ChessMatch match)
        {
            printBoard(match.brd);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);
            Console.WriteLine("Current player: " + match.currentPlayer);
            if(match.check)
                Console.WriteLine("CHECK!");
        }

        public static void printCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            printGroup(match.capturedPieces(Color.White));            
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printGroup(match.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
        }

        public static void printGroup(HashSet<Piece> group)
        {
            Console.Write("[");
            foreach(Piece p in group)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        public static void printBoard(Board brd)
        {
            for(int i=0; i<brd.rows; i++)
            {
                Console.Write(8 - i + " ");
                for(int j=0; j<brd.columns; j++)
                {                   
                    printPiece(brd.piece(i, j));                   
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board brd, bool[,] possiblePositions)
        {
            ConsoleColor bgOriginal = Console.BackgroundColor;
            ConsoleColor bgChanged = ConsoleColor.DarkGray;

            for (int i = 0; i < brd.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < brd.columns; j++)
                {
                    if (possiblePositions[i, j])                    
                        Console.BackgroundColor = bgChanged;
                    else
                        Console.BackgroundColor = bgOriginal;

                    printPiece(brd.piece(i, j));
                    Console.BackgroundColor = bgOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = bgOriginal;
        }

        public static void printPiece(Piece piece)
        {
            if (piece == null)
                Console.Write("- ");
            else
            {
                if (piece.color == Color.White)
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
                Console.Write(" ");
            }
        }

        public static PiecePosition readPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];            
            int row = int.Parse(s[1] + "");
            return new PiecePosition(column, row);
        }
    }
}
