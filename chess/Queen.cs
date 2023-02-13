using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board) {}

        private bool canMove(Position position) {
            Piece piece = Board.piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] possibleMoves() {
            bool [,] possibleMoves = new bool [Board.Row, Board.Column];
            Position position = new Position(0, 0);

            //north
            position.setPosition(Position.Row - 1, Position.Column);
            while(Board.validPosition(position) && canMove(position)){
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;

                position.Row--;
            }

            //south
            position.setPosition(Position.Row + 1, Position.Column);
            while(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;
                
                position.Row++;
            }

            //east
            position.setPosition(Position.Row, Position.Column + 1);
            while(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;
                
                position.Column++;
            }

            //west
            position.setPosition(Position.Row, Position.Column - 1);
            while(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;
                
                position.Column--;
            }

            //northwest
            position.setPosition(Position.Row - 1, Position.Column - 1);
            while(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;

                position.Row--;
                position.Column--;
            }

            //northeast
            position.setPosition(Position.Row - 1, Position.Column + 1);
            while(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;

                position.Row--;
                position.Column++;
            }

            //southwest
            position.setPosition(Position.Row + 1, Position.Column - 1);
            while(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;

                position.Row++;
                position.Column--;
            }

            //southeast
            position.setPosition(Position.Row + 1, Position.Column + 1);
            while(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;

                if(Board.piece(position) != null && Board.piece(position).Color != Color)
                    break;

                position.Row++;
                position.Column++;
            }



            return possibleMoves;
        }

        public override string ToString() 
        {
            return "Q";
        }
    }
}