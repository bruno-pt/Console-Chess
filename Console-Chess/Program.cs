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
                Board brd = new Board(8, 8);

                brd.placePiece(new Rook(brd, Color.Black), new Position(0, 0));
                brd.placePiece(new Rook(brd, Color.Black), new Position(0, 7));
                brd.placePiece(new Rook(brd, Color.White), new Position(7, 0));
                brd.placePiece(new Rook(brd, Color.White), new Position(7, 7));

                Screen.printBoard(brd);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
