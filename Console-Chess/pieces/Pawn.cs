using board;

namespace pieces
{
    class Pawn : Piece
    {
        public Pawn(Board brd, Color color) : base(brd, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool hasEnemy(Position pos)
        {
            Piece p = brd.piece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos)
        {
            return brd.piece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[brd.rows, brd.columns];

            Position pos = new Position(0, 0);

            if(color == Color.White)
            {
                pos.setValue(position.row - 1, position.column);
                if (brd.validPosition(pos) && free(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValue(position.row - 2, position.column);
                if (brd.validPosition(pos) && free(pos) && qntMoviments == 0)
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValue(position.row - 1, position.column - 1);
                if (brd.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValue(position.row - 1, position.column + 1);
                if (brd.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            }
            else
            {
                pos.setValue(position.row + 1, position.column);
                if (brd.validPosition(pos) && free(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValue(position.row + 2, position.column);
                if (brd.validPosition(pos) && free(pos) && qntMoviments == 0)
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValue(position.row + 1, position.column - 1);
                if (brd.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValue(position.row + 1, position.column + 1);
                if (brd.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            }

            return mat;
        }
    }
}