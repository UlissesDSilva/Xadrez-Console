namespace board 
{
    class Board 
    {
        public Board(int row, int column)
        {
            Row = row;
            Column = column;
            Pieces = new Piece[row, column];
        }

        public int Row { get; set; }
        public int Column { get; set; }
        private Piece[,] Pieces {get; set; }

        public Piece piece(int row, int column)
            => Pieces[row, column];

        public Piece piece(Position position) 
            => Pieces[position.Row, position.Column];

        public void positionPiece(Piece piece, Position position) {

            if(existPiece(position)){
                throw new BoardException("There is already a piece in that position");
            }
            
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public bool existPiece(Position position)
        {   
            validatePosition(position);
            return piece(position) != null;
        }

        public bool validPosition(Position position)
        {
            if(position.Row < 0 || position.Row >= Row || position.Column < 0 || position.Column >= Column){
                return false;
            }
            return true;
        }

        public void validatePosition(Position position) {
            if (!validPosition(position)){
                throw new BoardException("Position is not valid");
            }
        }

    }
}