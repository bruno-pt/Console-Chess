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
    }
}