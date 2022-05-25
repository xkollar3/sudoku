namespace SudokuBoard {
    public interface IESudoku {
        public int get(int x, int y);

        public bool put(int x, int y, int num);

        public List<List<int>> getBoardAsInts();

        public ICollection<int> getRowAsInts(int rownum);

        public ICollection<int> getColAsInts(int colnum);

        public ICollection<int> getSquareAsInts(int square);
        public bool solve();

        public bool checkValid();

        public bool isCellEmpty(int x, int y);

        public IESudoku copy(IESudoku src);
    }
}