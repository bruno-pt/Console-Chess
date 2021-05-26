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
        public bool check { get; private set; }

        public ChessMatch()
        {
            brd = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            placePieces();
        }

        public Piece executeMovement(Position origin, Position destination)
        {
            Piece p = brd.removePiece(origin);
            p.incrementQntMoviments();
            Piece capturedPiece = brd.removePiece(destination);
            brd.placePiece(p, destination);
            if (capturedPiece != null)
                captured.Add(capturedPiece);
            return capturedPiece;
        }

        public void undoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = brd.removePiece(destination);
            p.decrementQntMoviments();

            if(capturedPiece != null)
            {
                brd.placePiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            brd.placePiece(p, origin);
        }

        public void performMove(Position origin, Position destination)
        {
            Piece capturedPiece = executeMovement(origin, destination);

            if (isInCheck(currentPlayer))
            {
                undoMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if (isInCheck(opponent(currentPlayer)))
                check = true;
            else
                check = false;

            if (testCheckMate(opponent(currentPlayer)))
                finished = true;
            else
            {
                turn++;
                changePlayer();
            }
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

        private Color opponent (Color color)
        {
            if (color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }

        private Piece king(Color color)
        {
            foreach(Piece p in inGamePieces(color))
            {
                if (p is King)
                    return p;
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece K = king(color);

            foreach(Piece p in inGamePieces(opponent(color)))
            {
                bool[,] mat = p.possibleMovements();
                if (mat[K.position.row, K.position.column])
                    return true;
            }
            return false;
        }

        public bool testCheckMate(Color color)
        {
            if (!isInCheck(color))
                return false;

            foreach(Piece p in inGamePieces(color))
            {
                bool[,] mat = p.possibleMovements();
                for(int i=0; i<brd.rows; i++)
                {
                    for(int j=0; i<brd.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position destination = new Position(i, j);
                            Piece capturedPiece = executeMovement(p.position, destination);
                            bool testCheck = isInCheck(color);
                            undoMove(p.position, destination, capturedPiece);
                            if (!testCheck)
                                return false;
                        }
                    }
                }
            }
            return true;
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
