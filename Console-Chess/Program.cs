using System;
using board;
using pieces;

namespace Console_Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.finished)
                {
                    Console.Clear();
                    Screen.printBoard(match.brd);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.readPosition().toPosition();

                    bool[,] possiblePositions = match.brd.piece(origin).possibleMovements();

                    Console.Clear();
                    Screen.printBoard(match.brd, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.readPosition().toPosition();

                    match.executeMoviment(origin, destination);
                }
                
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
