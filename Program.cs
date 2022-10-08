using System;
using board;
using chess;

namespace xadrez 
{

  public class Program 
  {
    static void Main(string[] args) 
    {

      try
      {
        ChessPlay chessPlay = new ChessPlay();
        Display.printBoard(chessPlay.Board);
      }
      catch (BoardException e)
      {
        Console.WriteLine(e.Message);
      }

    }
  }
}