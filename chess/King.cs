using board;

namespace chess
{
    class King : Piece
    {
        public King(Color color, Board board) : base(color, board) {}

        private bool canMove(Position position) {
            Piece piece = Board.piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] possibleMoves() {
            bool [,] possibleMoves = new bool [Board.Row, Board.Column];
            Position position = new Position(0, 0);

            //melhorias para o Position.Row. Se o position já recebi a posição da peça, é só usar position

            // north
            position.setPosition(Position.Row - 1, Position.Column);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //northeast
            position.setPosition(Position.Row - 1, Position.Column + 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //east
            position.setPosition(Position.Row, Position.Column + 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //southeast
            position.setPosition(Position.Row + 1, Position.Column + 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //south
            position.setPosition(Position.Row + 1, Position.Column);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //southwest
            position.setPosition(Position.Row + 1, Position.Column - 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //west
            position.setPosition(Position.Row, Position.Column - 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            //northwest
            position.setPosition(Position.Row - 1, Position.Column - 1);
            if(Board.validPosition(position) && canMove(position)) {
                possibleMoves[position.Row, position.Column] = true;
            }

            return possibleMoves;
        }

        public override string ToString() 
        {
            return "K";
        }
    }
}