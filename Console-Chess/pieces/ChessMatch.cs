using System.Collections.Generic;
using board;

namespace pieces
{
    class ChessMatch
    {
        public Board brd { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            brd = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            placePieces();
        }

        public void executeMoviment(Position origin, Position destination)
        {
            Piece p = brd.removePiece(origin);
            p.incrementQntMoviments();
            Piece capturedPiece = brd.removePiece(destination);
            brd.placePiece(p, destination);
            if (capturedPiece != null)
                captured.Add(capturedPiece);
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

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece p in captured)
            {
                if (p.color == color)
                    aux.Add(p);
            }
            return aux;
        }

        public HashSet<Piece> inGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in pieces)
            {
                if (p.color == color)
                    aux.Add(p);
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void placeNewPiece(char column, int row, Piece piece)
        {
            brd.placePiece(piece, new PiecePosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void placePieces()
        {
            placeNewPiece('a', 8, new Rook(brd, Color.Black));
            placeNewPiece('b', 8, new Knight(brd, Color.Black));
            placeNewPiece('c', 8, new Bishop(brd, Color.Black));
            placeNewPiece('d', 8, new Queen(brd, Color.Black));
            placeNewPiece('e', 8, new King(brd, Color.Black));
            placeNewPiece('f', 8, new Bishop(brd, Color.Black));
            placeNewPiece('g', 8, new Knight(brd, Color.Black));
            placeNewPiece('h', 8, new Rook(brd, Color.Black));

            placeNewPiece('a', 1, new Rook(brd, Color.White));
            placeNewPiece('b', 1, new Knight(brd, Color.White));
            placeNewPiece('c', 1, new Bishop(brd, Color.White));
            placeNewPiece('d', 1, new Queen(brd, Color.White));
            placeNewPiece('e', 1, new King(brd, Color.White));
            placeNewPiece('f', 1, new Bishop(brd, Color.White));
            placeNewPiece('g', 1, new Knight(brd, Color.White));
            placeNewPiece('h', 1, new Rook(brd, Color.White));
        }
    }
}
