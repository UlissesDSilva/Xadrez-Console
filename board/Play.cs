namespace board 
{
    class Play 
    {
        public Play(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
        }

        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public Board Board { get; protected set; }
        public int NumberMoves { get; protected set; }
    }
}