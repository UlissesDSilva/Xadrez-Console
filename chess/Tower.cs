using board;

namespace chess
{
    class Tower : Piece
    {
        public Tower(Color color, Board board) : base(color, board) {}

        private bool canMove(Position position) {
            Piece piece = Board.piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] possibleMoves() {
            bool [,] possibleMoves = new bool [Board.Row, Board.Column];
            Position position = new Position(0, 0);

            //north
            position.setPosition(Position.Row - 1, Position.Column);
            while(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;
                
                position.Row = position.Row - 1;
            }

            //south
            position.setPosition(Position.Row + 1, Position.Column);
            while(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;
                
                position.Row = position.Row + 1;
            }

            //east
            position.setPosition(Position.Row, Position.Column + 1);
            while(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;
                
                position.Column = position.Column + 1;
            }

            //west
            position.setPosition(Position.Row, Position.Column - 1);
            while(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;
                
                position.Column = position.Column - 1;
            }

            return possibleMoves;
        }


        public override string ToString() 
        {
            return "T";
        }
    }
}