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
          Console.Clear();
          Display.printBoard(chessPlay.Board);

          origin = Display.writePositionPiece().toPosition();
          destiny = Display.writePositionPiece().toPosition();
          
          chessPlay.movement(origin, destiny);
        }
        
      }
      catch (BoardException e)
      {
        Console.WriteLine(e.Message);
      }

    }
  }
}