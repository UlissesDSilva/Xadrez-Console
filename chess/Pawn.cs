using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Color color, Board board, ChessPlay chessPlay) : base(color, board) {
            ChessPlay = chessPlay;
        }

        private ChessPlay ChessPlay;

        private bool thereIsAnOpponent(Position position) {
            Piece pieceOpponent = Board.piece(position);
            return pieceOpponent != null && pieceOpponent.Color != Color;
        }

        private bool freePosition(Position position) {
            return Board.piece(position) == null;
        }

        public override bool[,] possibleMoves() {
            bool [,] possibleMoves = new bool [Board.Row, Board.Column];
            Position position = new Position(0, 0);

            if(Color == Color.White) {
                //initial move
                position.setPosition(Position.Row - 2, Position.Column);
                if(Board.validPosition(position) && NumberMoves == 0) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //north
                position.setPosition(Position.Row - 1, Position.Column);
                if(Board.validPosition(position) && freePosition(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //northwest
                position.setPosition(Position.Row - 1, Position.Column - 1);
                if(Board.validPosition(position) && thereIsAnOpponent(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //northeast
                position.setPosition(Position.Row - 1, Position.Column + 1);
                if(Board.validPosition(position) && thereIsAnOpponent(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                // passing pawn
                if (Position.Row == 3) {
                    Position pawnLeft = new Position(Position.Row, Position.Column - 1);
                    if(Board.validPosition(pawnLeft) && thereIsAnOpponent(pawnLeft) && Board.piece(pawnLeft) == ChessPlay.vulnerablePiecePassant) {
                        possibleMoves[Position.Row - 1, Position.Column - 1] = true;
                    }

                    Position pawnRight = new Position(Position.Row, Position.Column + 1);
                    if(Board.validPosition(pawnRight) && thereIsAnOpponent(pawnRight) && Board.piece(pawnRight) == ChessPlay.vulnerablePiecePassant) {
                        possibleMoves[Position.Row - 1, Position.Column + 1] = true;
                    }
                }

            } else {
                position.setPosition(Position.Row + 2, Position.Column);
                if(Board.validPosition(position) && NumberMoves == 0) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //north
                position.setPosition(Position.Row + 1, Position.Column);
                if(Board.validPosition(position) && freePosition(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //northwest
                position.setPosition(Position.Row + 1, Position.Column - 1);
                if(Board.validPosition(position) && thereIsAnOpponent(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                //northeast
                position.setPosition(Position.Row + 1, Position.Column + 1);
                if(Board.validPosition(position) && thereIsAnOpponent(position)) {
                    possibleMoves[position.Row, position.Column] = true;
                }

                // passing pawn
                if (Position.Row == 4) {
                    Position pawnLeft = new Position(Position.Row, Position.Column - 1);
                    if(Board.validPosition(pawnLeft) && thereIsAnOpponent(pawnLeft) && Board.piece(pawnLeft) == ChessPlay.vulnerablePiecePassant) {
                        possibleMoves[Position.Row + 1, Position.Column - 1] = true;
                    }

                    Position pawnRight = new Position(Position.Row, Position.Column + 1);
                    if(Board.validPosition(pawnRight) && thereIsAnOpponent(pawnRight) && Board.piece(pawnRight) == ChessPlay.vulnerablePiecePassant) {
                        possibleMoves[Position.Row + 1, Position.Column + 1] = true;
                    }
                }
            }

            return possibleMoves;
        }

        public override string ToString() 
        {
            return "P";
        }
    }
}