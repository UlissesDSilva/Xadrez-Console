﻿using System;
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
            Display.newDisplay(chessPlay);
            
            Console.Write("Origin: ");
            origin = Display.writePositionPiece().toPosition();
            chessPlay.validateOriginPosition(origin);

            bool[,] possibleMoves = chessPlay.Board.piece(origin).possibleMoves();

            Display.newDisplay(chessPlay, possibleMoves);

            Console.Write("Destiny: ");
            destiny = Display.writePositionPiece().toPosition();
            chessPlay.validateDestinyPosition(origin, destiny);
            
            chessPlay.performMove(origin, destiny);
          } catch (BoardException e) {
            Console.WriteLine(e.Message);
            Console.ReadLine();
          }
        }
        Display.newDisplay(chessPlay);
      }
      catch (BoardException e)
      {
        Console.WriteLine(e.Message);
      }

    }
  }
}