using System;
using board;

namespace pieces
{
    class ChessMatch
    {
        public Board brd { get; private set; }
        private int turn;
        private Color currentPlayer;

        public ChessMatch()
        {
            brd = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            placePieces();
        }

        public void executeMoviment(Position origin, Position destination)
        {
            Piece p = brd.removePiece(origin);
            p.incrementQntMoviments();
            Piece capturedPiece = brd.removePiece(destination);
            brd.placePiece(p, destination);
        }

        private void placePieces()
        {
            brd.placePiece(new Rook(brd, Color.Black), new PiecePosition('a', 8).toPosition());
            brd.placePiece(new Knight(brd, Color.Black), new PiecePosition('b', 8).toPosition());
            brd.placePiece(new Bishop(brd, Color.Black), new PiecePosition('c', 8).toPosition());
            brd.placePiece(new Queen(brd, Color.Black), new PiecePosition('d', 8).toPosition());
            brd.placePiece(new King(brd, Color.Black), new PiecePosition('e', 8).toPosition());
            brd.placePiece(new Bishop(brd, Color.Black), new PiecePosition('f', 8).toPosition());
            brd.placePiece(new Knight(brd, Color.Black), new PiecePosition('g', 8).toPosition());
            brd.placePiece(new Rook(brd, Color.Black), new PiecePosition('h', 8).toPosition());

            brd.placePiece(new Rook(brd, Color.White), new PiecePosition('a', 1).toPosition());
            brd.placePiece(new Knight(brd, Color.White), new PiecePosition('b', 1).toPosition());
            brd.placePiece(new Bishop(brd, Color.White), new PiecePosition('c', 1).toPosition());
            brd.placePiece(new Queen(brd, Color.White), new PiecePosition('d', 1).toPosition());
            brd.placePiece(new King(brd, Color.White), new PiecePosition('e', 1).toPosition());
            brd.placePiece(new Bishop(brd, Color.White), new PiecePosition('f', 1).toPosition());
            brd.placePiece(new Knight(brd, Color.White), new PiecePosition('g', 1).toPosition());
            brd.placePiece(new Rook(brd, Color.White), new PiecePosition('h', 1).toPosition());
        }
    }
}
