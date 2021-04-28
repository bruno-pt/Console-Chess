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

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[brd.rows, brd.columns];

            Position pos = new Position(0, 0);

            return mat;
        }
    }
}