using board;

namespace pieces
{
    class Bishop : Piece
    {
        public Bishop(Board brd, Color color) : base(brd, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[brd.rows, brd.columns];

            Position pos = new Position(0, 0);

            return mat;
        }
    }
}