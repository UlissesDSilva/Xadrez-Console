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
            vulnerablePiecePassant = null;
            putPieces();
        }

        public Board Board {get; private set;}
        public int Turn {get; private set;}
        public Color PlayCurrent {get; private set;}
        public bool Endgame {get; private set;}
        private HashSet<Piece> PiecesInGame;
        private HashSet<Piece> CapturedPieces;
        public bool Check {get; private set;}
        public Piece vulnerablePiecePassant {get; private set;}

        public void performMove(Position origin, Position destiny){
            Piece capturedPiece = movement(origin, destiny);
            Piece piece = Board.piece(destiny);

            if(verifyIfItsInCheck(PlayCurrent)) {
                undoMove(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            //Promotion
            if(piece is Pawn) {
                if((piece.Color == Color.White && destiny.Row == 0) || (piece.Color != Color.White && destiny.Row == 7)) {
                    piece = Board.removePiece(destiny);
                    PiecesInGame.Remove(piece);

                    char piecePromotion = choosePiece();
                    
                    switch (piecePromotion.ToString().ToUpper())
                    {
                        case "T":
                            Piece tower = new Tower(piece.Color, Board);
                            Board.positionPiece(tower, destiny);
                            PiecesInGame.Add(tower);
                            break;
                        case "H":
                            Piece house = new Horse(piece.Color, Board);
                            Board.positionPiece(house, destiny);
                            PiecesInGame.Add(house);
                            break;
                        case "B":
                            Piece bishop = new Bishop(piece.Color, Board);
                            Board.positionPiece(bishop, destiny);
                            PiecesInGame.Add(bishop);
                            break;
                        case "Q":
                            Piece queen = new Queen(piece.Color, Board);
                            Board.positionPiece(queen, destiny);
                            PiecesInGame.Add(queen);
                            break;
                        default:
                            break;
                    }
                }
            }

            Check = verifyIfItsInCheck(getAdversary(PlayCurrent)) ? true : false;

            if (verifyCheckmate(getAdversary(PlayCurrent))) {
                Endgame = true;
            } else {
                Turn++;
                PlayCurrent = PlayCurrent == Color.White ? Color.Pink : Color.White;
            }
            
            //En passant
            if(piece is Pawn && (destiny.Row == origin.Row + 2 || destiny.Row == origin.Row - 2)) {
                vulnerablePiecePassant = piece;
            } else {
                vulnerablePiecePassant = null;
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
            
            //Small castling
            if (piece is King && destiny.Column == origin.Column + 2) {
                Position towerOrigin = new Position(origin.Row, origin.Column + 3);
                Position towerDestiny = new Position(origin.Row, origin.Column + 1);
                movement(towerOrigin, towerDestiny);
                // Piece tower = Board.removePiece(towerOrigin);
                // tower.incrementMovements();
                // Board.positionPiece(tower, towerDestiny);
            }

            //Big castling
            if (piece is King && destiny.Column == origin.Column - 2) {
                Position towerOrigin = new Position(origin.Row, origin.Column - 4);
                Position towerDestiny = new Position(origin.Row, origin.Column - 1);
                movement(towerOrigin, towerDestiny);
                // Piece tower = Board.removePiece(towerOrigin);
                // tower.incrementMovements();
                // Board.positionPiece(tower, towerDestiny);
            }

            //En passant
            if(piece is Pawn) {
                if (origin.Column != destiny.Column && capturedPiece == null) {
                    Position p;
                    if(piece.Color == Color.White) {
                        p = new Position(destiny.Row + 1, destiny.Column);
                    }else {
                        p = new Position(destiny.Row - 1, destiny.Column);
                    }

                    capturedPiece = Board.removePiece(p);
                    CapturedPieces.Add(capturedPiece);
                }
            }
            
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

            //Small castling
            if (movedPiece is King && destiny.Column == origin.Column + 2) {
                Position towerOrigin = new Position(origin.Row, origin.Column + 3);
                Position towerDestiny = new Position(origin.Row, origin.Column + 1);
                undoMove(towerOrigin, towerDestiny, movedPiece);
                // Piece tower = Board.removePiece(towerOrigin);
                // tower.incrementMovements();
                // Board.positionPiece(tower, towerDestiny);
            }

            //Big castling
            if (movedPiece is King && destiny.Column == origin.Column - 2) {
                Position towerOrigin = new Position(origin.Row, origin.Column - 4);
                Position towerDestiny = new Position(origin.Row, origin.Column - 1);
                undoMove(towerOrigin, towerDestiny, movedPiece);
                // Piece tower = Board.removePiece(towerOrigin);
                // tower.incrementMovements();
                // Board.positionPiece(tower, towerDestiny);
            }

            //En passant
            if(movedPiece is Pawn) {
                if (origin.Column != destiny.Column && capturedPiece == vulnerablePiecePassant) {
                    Piece piece = Board.removePiece(destiny);
                    Position position;
                    int rowEnPassantWhite = 3;
                    int rowEnPassantBlack = 4;

                    if(movedPiece.Color == Color.White) {
                        position = new Position(rowEnPassantWhite, destiny.Column);
                    }else {
                        position = new Position(rowEnPassantBlack, destiny.Column);
                    }
                    Board.positionPiece(piece, position);
                }
            }
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
            putNewPiece(new King(Color.White, Board, this), 'e', 1);
            putNewPiece(new Bishop(Color.White, Board), 'f', 1);
            putNewPiece(new Horse(Color.White, Board), 'g', 1);
            putNewPiece(new Tower(Color.White, Board), 'h', 1);
            putNewPiece(new Pawn(Color.White, Board, this), 'a', 2);
            putNewPiece(new Pawn(Color.White, Board, this), 'b', 2);
            putNewPiece(new Pawn(Color.White, Board, this), 'c', 2);
            putNewPiece(new Pawn(Color.White, Board, this), 'd', 2);
            putNewPiece(new Pawn(Color.White, Board, this), 'e', 2);
            putNewPiece(new Pawn(Color.White, Board, this), 'f', 2);
            putNewPiece(new Pawn(Color.White, Board, this), 'g', 2);
            putNewPiece(new Pawn(Color.White, Board, this), 'h', 6);

            putNewPiece(new Tower(Color.Pink, Board), 'a', 8);
            putNewPiece(new Horse(Color.Pink, Board), 'b', 8);
            putNewPiece(new Bishop(Color.Pink, Board), 'c', 8);
            putNewPiece(new Queen(Color.Pink, Board), 'd', 8);
            putNewPiece(new King(Color.Pink, Board, this), 'e', 8);
            putNewPiece(new Bishop(Color.Pink, Board), 'f', 8);
            putNewPiece(new Horse(Color.Pink, Board), 'g', 8);
            putNewPiece(new Tower(Color.Pink, Board), 'h', 8);
            putNewPiece(new Pawn(Color.Pink, Board, this), 'a', 3);
            putNewPiece(new Pawn(Color.Pink, Board, this), 'b', 7);
            putNewPiece(new Pawn(Color.Pink, Board, this), 'c', 7);
            putNewPiece(new Pawn(Color.Pink, Board, this), 'd', 7);
            putNewPiece(new Pawn(Color.Pink, Board, this), 'e', 7);
            putNewPiece(new Pawn(Color.Pink, Board, this), 'f', 7);
            putNewPiece(new Pawn(Color.Pink, Board, this), 'g', 7);
            putNewPiece(new Pawn(Color.Pink, Board, this), 'h', 7);
        }

        private char choosePiece() {
            Console.WriteLine("Choose a piece");
            Console.WriteLine("[ T H B Q ]");
            char piece = char.Parse(Console.ReadLine());
            return piece;
        }
    }

}