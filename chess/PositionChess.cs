using board;

namespace chess
{
  class PositionChess
  {
    public PositionChess(char column, int row)
    {
      Column = column;
      Row = row;
    }

    public char Column { get; set; }
    public int Row { get; set; }

    public Position toPosition() 
    {
      return new Position(8 - Row, Column - 'a');
    }
    
    public override string ToString() 
    {    
      return $"{Column}, {Row}";    
    }
  }
}