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
    }
}
