using board;

namespace chess
{
    class ChessPlay
    {
        public ChessPlay()
        {
            Board = new Board(8, 8);
            Turn = 1;
            PlayCurrent = Color.White;
            Endgame = false;
            Check = false;
            PiecesInGame = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            putPieces();
        }

        public Board Board {get; private set;}
        public int Turn {get; private set;}
        public Color PlayCurrent {get; private set;}
        public bool Endgame {get; private set;}
        private HashSet<Piece> PiecesInGame;
        private HashSet<Piece> CapturedPieces;
        public bool Check {get; private set;}

        public void performMove(Position origin, Position destiny){
            Piece piece = movement(origin, destiny);

            if(verifyIfItsInCheck(PlayCurrent)) {
                undoMove(origin, destiny, piece);
                throw new BoardException("You can't put yourself in check!");
            }

            Check = verifyIfItsInCheck(getAdversary(PlayCurrent)) ? true : false;

            if (verifyCheckmate(getAdversary(PlayCurrent))) {
                Endgame = true;
            } else {
                Turn++;
                PlayCurrent = PlayCurrent == Color.White ? Color.Pink : Color.White;
            }
        }

        public Piece movement(Position origin, Position destiny)
        {
            Piece piece = Board.removePiece(origin);
            piece.incrementMovements();
            Piece capturedPiece = Board.removePiece(destiny);
            Board.positionPiece(piece, destiny);

            if (capturedPiece != null)
                CapturedPieces.Add(capturedPiece);
            
            return capturedPiece;
        }

        private void undoMove(Position origin, Position destiny, Piece capturedPiece) {
            Piece movedPiece = Board.removePiece(destiny);
            movedPiece.decrementMovements();
            if(capturedPiece != null) {
                Board.positionPiece(capturedPiece, destiny);
                CapturedPieces.Remove(capturedPiece);
            }
            Board.positionPiece(movedPiece, origin);
        }

        public void validateOriginPosition(Position position){
            if (Board.piece(position) == null) {
                throw new BoardException("There is not piece in this location!");
            }
            if (Board.piece(position).Color != PlayCurrent) {
                throw new BoardException($"The turn is for the pieces: {PlayCurrent}");
            }
            if (!Board.piece(position).existPossibleMove()) {
                throw new BoardException("There is not movement");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny) {
            if(!Board.piece(origin).canMoveTo(destiny))
                throw new BoardException("Invalid target position!");
        }

        public HashSet<Piece> getCapturedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece piece in CapturedPieces) {
                if (piece.Color == color)
                    aux.Add(piece);
            }
            return aux;
        }

        public HashSet<Piece> getPiecesInGame(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece piece in PiecesInGame) {
                if (piece.Color == color)
                    aux.Add(piece);
            }
            aux.ExceptWith(getCapturedPieces(color));
            return aux;
        }

        private Color getAdversary(Color color) {
            return color == Color.White ? Color.Pink : Color.White;
        }

        private Piece getKing(Color color) {
            foreach(Piece piece in getPiecesInGame(color)) {
                //Instância de King
                if (piece is King) {
                    return piece;
                }
            }
            return null;
        }

        private bool verifyIfItsInCheck(Color color){
            Piece king = getKing(color);
            if (king == null) {
                throw new BadImageFormatException($"There is not king the color {color}");
            }

            foreach(Piece piece in getPiecesInGame(getAdversary(color))){
                bool[,] moves = piece.possibleMoves();
                if(moves[king.Position.Row, king.Position.Column]) {
                    return true;
                }
            }
            return false;
        }

        private bool verifyCheckmate(Color color){
            if(!verifyIfItsInCheck(color))
                return false;

            foreach(Piece piece in getPiecesInGame(color)){
                bool[,] moves = piece.possibleMoves();

                for(int row = 0; row < Board.Row; row++) {
                    for(int column = 0; column < Board.Column; column++) {
                        if(moves[row, column]){
                            Position origin = piece.Position;
                            Position destiny = new Position(row, column);
                            Piece capturedPiece = movement(origin, destiny);
                            bool checkTest = verifyIfItsInCheck(color);
                            undoMove(origin, destiny, capturedPiece);
                            if (!checkTest) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void putNewPiece(Piece piece, char column, int row){
            Board.positionPiece(piece, new PositionChess(column, row).toPosition());
            PiecesInGame.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece(new Tower(Color.White, Board), 'a', 1);
            putNewPiece(new Horse(Color.White, Board), 'b', 1);
            putNewPiece(new Bishop(Color.White, Board), 'c', 1);
            putNewPiece(new Queen(Color.White, Board), 'd', 1);
            putNewPiece(new King(Color.White, Board), 'e', 1);
            putNewPiece(new Bishop(Color.White, Board), 'f', 1);
            putNewPiece(new Horse(Color.White, Board), 'g', 1);
            putNewPiece(new Tower(Color.White, Board), 'h', 1);
            putNewPiece(new Pawn(Color.White, Board), 'a', 2);
            putNewPiece(new Pawn(Color.White, Board), 'b', 2);
            putNewPiece(new Pawn(Color.White, Board), 'c', 2);
            putNewPiece(new Pawn(Color.White, Board), 'd', 2);
            putNewPiece(new Pawn(Color.White, Board), 'e', 2);
            putNewPiece(new Pawn(Color.White, Board), 'f', 2);
            putNewPiece(new Pawn(Color.White, Board), 'g', 2);
            putNewPiece(new Pawn(Color.White, Board), 'h', 2);

            putNewPiece(new Tower(Color.Pink, Board), 'a', 8);
            putNewPiece(new Horse(Color.Pink, Board), 'b', 8);
            putNewPiece(new Bishop(Color.Pink, Board), 'c', 8);
            putNewPiece(new Queen(Color.Pink, Board), 'd', 8);
            putNewPiece(new King(Color.Pink, Board), 'e', 8);
            putNewPiece(new Bishop(Color.Pink, Board), 'f', 8);
            putNewPiece(new Horse(Color.Pink, Board), 'g', 8);
            putNewPiece(new Tower(Color.Pink, Board), 'h', 8);
            putNewPiece(new Pawn(Color.Pink, Board), 'a', 7);
            putNewPiece(new Pawn(Color.Pink, Board), 'b', 7);
            putNewPiece(new Pawn(Color.Pink, Board), 'c', 7);
            putNewPiece(new Pawn(Color.Pink, Board), 'd', 7);
            putNewPiece(new Pawn(Color.Pink, Board), 'e', 7);
            putNewPiece(new Pawn(Color.Pink, Board), 'f', 7);
            putNewPiece(new Pawn(Color.Pink, Board), 'g', 7);
            putNewPiece(new Pawn(Color.Pink, Board), 'h', 7);
        }

    }
}