### Arquitetura - Padrão de camadas

  Camada de Aplicação

  Camada Jogo de Xadrez

  Camada Tabuleiro

# Possíveis soluções
  `Controle de movimentação na origem`
      while(chessPlay.Board.piece(origin) == null) {
        newDisplay(chessPlay);
        Console.WriteLine($"There is not piece in this location: {origin}");
        Console.Write("Origin: ");
        origin = Display.writePositionPiece().toPosition();
      }

      while(!chessPlay.Board.piece(origin).existMove()) {
        newDisplay(chessPlay);
        Console.WriteLine($"Peça presa: {origin}");
        Console.Write("Origin: ");
        origin = Display.writePositionPiece().toPosition();
      }

      while(chessPlay.Board.piece(origin).Color != chessPlay.PlayCurrent) {
        newDisplay(chessPlay);
        Console.WriteLine($"The turn is for the pieces: {chessPlay.PlayCurrent}");
        Console.Write("Origin: ");
        origin = Display.writePositionPiece().toPosition();
      } 