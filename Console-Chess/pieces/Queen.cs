using board;

namespace pieces
{
    class Queen : Piece
    {
        public Queen(Board brd, Color color) : base(brd, color)
        {
        }

        public override string ToString()
        {
            return "Q";
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
            while (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (brd.piece(pos) != null && brd.piece(pos).color != color)
                    break;
                pos.row = pos.row - 1;
            }

            //bellow
            pos.setValue(position.row + 1, position.column);
            while (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (brd.piece(pos) != null && brd.piece(pos).color != color)
                    break;
                pos.row = pos.row + 1;
            }

            //right
            pos.setValue(position.row, position.column + 1);
            while (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (brd.piece(pos) != null && brd.piece(pos).color != color)
                    break;
                pos.column = pos.column + 1;
            }

            //left
            pos.setValue(position.row, position.column - 1);
            while (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (brd.piece(pos) != null && brd.piece(pos).color != color)
                    break;
                pos.column = pos.column - 1;
            }

            //NE
            pos.setValue(position.row - 1, position.column + 1);
            while (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (brd.piece(pos) != null && brd.piece(pos).color != color)
                {
                    break;
                }
                pos.setValue(pos.row - 1, pos.column + 1);
            }

            //NW
            pos.setValue(position.row - 1, position.column - 1);
            while (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (brd.piece(pos) != null && brd.piece(pos).color != color)
                {
                    break;
                }
                pos.setValue(pos.row - 1, pos.column - 1);
            }

            //SE
            pos.setValue(position.row + 1, position.column + 1);
            while (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (brd.piece(pos) != null && brd.piece(pos).color != color)
                {
                    break;
                }
                pos.setValue(pos.row + 1, pos.column + 1);
            }

            //SW
            pos.setValue(position.row + 1, position.column - 1);
            while (brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (brd.piece(pos) != null && brd.piece(pos).color != color)
                {
                    break;
                }
                pos.setValue(pos.row + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
