namespace board {
    class Board {
        public Board(int row, int column)
        {
            Row = row;
            Column = column;
            Pieces = new Piece[row, column];
        }

        public int Row { get; set; }
        public int Column { get; set; }
        private Piece[,] Pieces {get; set; }

        public Piece play(int row, int column) {
            return Pieces[row, column];
        }

        public void positionPiece(Piece piece, Position position) {
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
    }
}