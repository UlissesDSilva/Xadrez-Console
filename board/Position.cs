namespace board {

  class Position {

    public Position(int row, int column) 
    {
      Row = row;
      Column = column;
    }

    public int Row { get; set; }
    public int Column { get; set; }

    public void setPosition(int row, int column) {
      Row = row;
      Column = column;
    }

    public override string ToString() 
    {
      return $"{Row}, {Column}";
    }
  }
}