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

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[brd.rows, brd.columns];

            Position pos = new Position(0, 0);

            return mat;
        }
    }
}
