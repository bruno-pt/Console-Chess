namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qntMoviments { get; protected set; }
        public Board brd{ get; protected set; }

        public Piece(Board brd, Color color)
        {
            this.position = null;
            this.color = color;
            this.brd = brd;
            this.qntMoviments = 0;
        }

        public void incrementQntMoviments()
        {
            qntMoviments++;
        }

        public abstract bool[,] possibleMovements();
    }
}
