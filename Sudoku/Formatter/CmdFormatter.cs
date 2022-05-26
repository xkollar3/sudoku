using SudokuBoard;

namespace Formatter {
    public class CmdFormatter : ISudokuFormatter
    {
        public string format(IESudoku board)
        {
            string separator = "+-------+-------+-------+\n";
            string res = "";
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == 0) {
                        res += separator;
                    }
                    for (int j = 0; j < 9; j++)
                    {
                        if (j % 3 == 0) {
                            res += "| ";
                        }
                        res += board.get(i, j).ToString() + " ";
                        
                    }
                    res += "|\n";

                    
                }
            res += separator;
            return res;
        }
    }
}