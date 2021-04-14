using board;

namespace pieces
{
    class Rook : Piece
    {
        public Rook(Board brd, Color color) : base(brd, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
