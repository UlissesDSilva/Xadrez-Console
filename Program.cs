using System;
using board;
using chess;

namespace xadrez 
{

  public class Program 
  {
    static void Main(string[] args) 
    {
      Position origin, destiny;

      try
      {
        ChessPlay chessPlay = new ChessPlay();

        while(!chessPlay.Endgame) {
          try {
            newDisplay(chessPlay);

            Console.WriteLine($"Jogada da: {chessPlay.PlayCurrent}");
            Console.WriteLine($"Turno: {chessPlay.Turn}");
            
            Console.Write("Origin: ");
            origin = Display.writePositionPiece().toPosition();
            chessPlay.validateOriginPosition(origin);

            bool[,] possibleMoves = chessPlay.Board.piece(origin).possibleMoves();

            newDisplay(chessPlay, possibleMoves);

            Console.Write("Destiny: ");
            destiny = Display.writePositionPiece().toPosition();
            chessPlay.validateDestinyPosition(origin, destiny);
            
            chessPlay.performMove(origin, destiny);
          } catch (BoardException e) {
            Console.WriteLine(e.Message);
            Console.ReadLine();
          }
        }
        
      }
      catch (BoardException e)
      {
        Console.WriteLine(e.Message);
      }

    }

    private static void newDisplay(ChessPlay chessPlay, bool[,] possibleMoves = null) {
      Console.Clear();
      if (possibleMoves == null) {
        Display.printBoard(chessPlay.Board);
      } else {
        Display.printBoard(chessPlay.Board, possibleMoves);
      }
    }
  }
}