namespace board {
    class Board {
        public Board(int row, int column)
        {
            Row = row;
            Column = column;
            Parts = new Play[row, column];
        }

        public int Row { get; set; }
        public int Column { get; set; }
        private Play[,] Parts {get; set; }


        public Play play(int row, int column) {
            return Parts[row, column];
        }
    }
}