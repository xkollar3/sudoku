using SudokuBoard;

namespace Formatter {
    public class CmdFormatter : IFormatter
    {
        public string format(IESudoku board)
        {
            string separator = "+-----+-----+-----+";
            string res = "";
            foreach (List<int> row in board.getBoardAsInts()) {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        res += string.Format("%d ", j);
                        if (j % 3 == 0) {
                            res += "| ";
                        }
                    }
                    if (i % 3 == 0) {
                        res += separator;
                    }
                    res += "|\n";
                }
            }
            res += separator;
            return res;
        }
    }
}