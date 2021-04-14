namespace board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qntMoviments { get; protected set; }
        public Board brd{ get; protected set; }

        public Piece(Position position, Color color, Board brd)
        {
            this.position = position;
            this.color = color;
            this.brd = brd;
            this.qntMoviments = 0; //start quant
        }
    }
}
