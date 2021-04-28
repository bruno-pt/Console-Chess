using board;

namespace pieces
{
    class King : Piece
    {
        public King(Board brd, Color color) : base (brd, color)
        {
        }

        public override string ToString()
        {
            return "K";
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

            //above
            pos.setValue(position.row - 1, position.column);
            if(brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //NE
            pos.setValue(position.row - 1, position.column + 1);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //right
            pos.setValue(position.row, position.column + 1);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //SE
            pos.setValue(position.row + 1, position.column + 1);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //above
            pos.setValue(position.row + 1, position.column);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //SW
            pos.setValue(position.row + 1, position.column - 1);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //left
            pos.setValue(position.row, position.column - 1);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //NW
            pos.setValue(position.row - 1, position.column - 1);
            if (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            return mat;
        }
    }
}
