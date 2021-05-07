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
                    try
                    {
                        Console.Clear();
                        Screen.printMatch(match);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readPosition().toPosition();
                        match.validateOriginPosition(origin);

                        bool[,] possiblePositions = match.brd.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.printBoard(match.brd, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.readPosition().toPosition();
                        match.validateDestinationPosition(origin, destination);

                        match.performMove(origin, destination);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
