using board;

namespace pieces
{
    class Knight : Piece
    {
        public Knight(Board brd, Color color) : base(brd, color)
        {
        }

        public override string ToString()
        {
            return "L"; //not to come into conflict with the King
        }

        private bool canMove(Position pos)
        {
            Piece p = brd.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[brd.rows, brd.columns];

            Position pos = new Position(0, 0);

            pos.setValue(position.row - 1, position.column - 2);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.setValue(position.row - 2, position.column - 1);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.setValue(position.row - 2, position.column + 1);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.setValue(position.row - 1, position.column + 2);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.setValue(position.row + 1, position.column + 2);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.setValue(position.row + 2, position.column + 1);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.setValue(position.row + 2, position.column - 1);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.setValue(position.row + 1, position.column - 2);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            return mat;
        }
    }
}