using System;
using board;

namespace pieces
{
    class ChessMatch
    {
        public Board brd { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessMatch()
        {
            brd = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            placePieces();
        }

        public void executeMoviment(Position origin, Position destination)
        {
            Piece p = brd.removePiece(origin);
            p.incrementQntMoviments();
            Piece capturedPiece = brd.removePiece(destination);
            brd.placePiece(p, destination);
        }

        public void performMove(Position origin, Position destination)
        {
            executeMoviment(origin, destination);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos)
        {
            if (brd.piece(pos) == null)
                throw new BoardException("Doesn't exist a piece in the chosen position!");

            if (currentPlayer != brd.piece(pos).color)
                throw new BoardException("The chosen piece isn't your!");

            if (!brd.piece(pos).existePossibleMovements())
                throw new BoardException("There is not possible movements for this piece");
        }

        public void validateDestinationPosition(Position origin, Position destination)
        {
            if (!brd.piece(origin).canMoveTo(destination)){
                throw new BoardException("Invalid destination position!");
            }
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
                currentPlayer = Color.White;
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
