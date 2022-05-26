using Formatter;

namespace SudokuBoard {
    public class ListSudokuBoard : IESudoku
    {
        private readonly List<List<int>> board;
        public ListSudokuBoard() {
            board = new List<List<int>>();
            List<int> row = new List<int>();
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    row.Add(0);
                }
                board.Add(row);
                row = new List<int>();
            }
        }
        public bool checkValid()
        {
            return checkRows() && checkCols() && checkSquares();
            
        }

        private bool checkSquares()
        {
            for (int s = 0; s < 9; s++) {
                if (!checkSquare(s)) {
                    return false;
                }
            }

            return true;
        }

        private bool checkSquare(int s)
        {
            HashSet<int> square = new HashSet<int>();
            int rowOffset = s / 3 * 3;
            int colOffset = s % 3 * 3;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (!square.Add(board.ElementAt(rowOffset + i).ElementAt(colOffset + j))) {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool checkCols()
        {
            HashSet<int> col = new HashSet<int>();
            for (int c = 0; c < 9; c++) {
                for (int row = 0; row < 9; row++) {
                    if (!col.Add(board.ElementAt(row).ElementAt(c))) {
                        return false;
                    }
                }
                col = new HashSet<int>();
            }
            return true;
        }

        private bool checkRows() {
            HashSet<int> col = new HashSet<int>();
            for (int c = 0; c < 9; c++) {
                for (int row = 0; row < 9; row++) {
                    if (!col.Add(board.ElementAt(c).ElementAt(row))) {
                        return false;
                    }
                }
                col = new HashSet<int>();
            }
            return true;
        }

        public int get(int x, int y)
        {
            if (x > 8 || x < 0 || y < 0 || y > 8) {
                throw new ArgumentException("Invalid get index");
            }
            return board.ElementAt(x).ElementAt(y);
        }

        public List<List<int>> getBoardAsInts()
        {
            return board;
        }

        public bool put(int x, int y, int num)
        {
            if (!checkInx(x) || !checkInx(y)) {
                throw new ArgumentException("invalid put index");
            }

            if (num == 0) {
                board[x][y] = 0;
                return true;
            }
            if (!isCellEmpty(x,y)) {
                return false;
            }
            
            int squareInx = x / 3 * 3 + y / 3;

            if (getSquareAsInts(squareInx).Contains(num) || getColAsInts(y).Contains(num) || getRowAsInts(x).Contains(num)) {
                return false;
            }

            board[x][y] = num;
            return true;
        }
        

        public bool solve()
        {
            return genericSolve(0, 0);
        }

        private bool genericSolve(int row, int col)
        {
            for (int i = 1; i < 10; i++) {
                if (put(row, col, i)) {
                    if (row == 8 && col == 8) {
                        return true;
                    }
                    if (col == 8) {
                        if (genericSolve(row + 1, 0)) {
                            return true;
                        }
                    }
                    else {
                        if (genericSolve(row, col + 1)) {
                            return true;
                        }
                    }
                    put(row, col,  0);
                }
            }
            
            
            return false;

        }

        public ICollection<int> getRowAsInts(int rownum)
        {
            if (!checkInx(rownum)) {
                throw new ArgumentException("Index out of bounds [0, 8]");
            }

            return new HashSet<int>(board.ElementAt(rownum));
        }

        public ICollection<int> getColAsInts(int colnum)
        {
            if (!checkInx(colnum)) {
                throw new ArgumentException("Index out of bounds [0, 8]");
            }

            HashSet<int> col = new HashSet<int>();

            for (int row = 0; row < 9; row++) {
                col.Add(board.ElementAt(row).ElementAt(colnum));
            }

            return col;
        }

        public ICollection<int> getSquareAsInts(int square)
        {
            int rowOffset = square / 3 * 3;
            int colOffset = square % 3 * 3;

            HashSet<int> cells = new HashSet<int>();

            for (int row = 0; row < 3; row++) {
                for (int col = 0; col < 3; col++) {
                    cells.Add(board.ElementAt(row+rowOffset).ElementAt(col + colOffset));
                }
            }

            return cells;
        }

        private bool checkInx(int inx) {
            return inx > -1 && inx < 9;
        }

        public bool isCellEmpty(int x, int y)
        {
            if (!checkInx(x) || !checkInx(y)) {
                throw new ArgumentException("Cell doesn't exist");
            }

            return board[x][y] == 0;
        }

        public IESudoku copy(IESudoku src)
        {
            IESudoku res = new ListSudokuBoard();
            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    res.put(row, col, src.get(row, col));
                }
            }           
            return res;
        }
    }
}