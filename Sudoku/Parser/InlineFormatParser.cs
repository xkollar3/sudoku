using SudokuBoard;

namespace Parser {
    public class InlineFormatParser : ISudokuParser
    {
        public IESudoku parse(string input)
        {
            input = this.read(input);
            if (input is null || input.Length > 81) {
                throw new ArgumentException("Sudoku format error");
            }
            IESudoku sudoku = new ListSudokuBoard();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudoku.put(i, j, '0' - input[i * 9 + j]);
                }
            }            

            return sudoku;
        }

        public string read(string file)
        {
            if (file is null) {
                throw new ArgumentException("File location cannot be null");
            }
            
            string? res;

            using (StreamReader reader = new StreamReader(file))
            {
                if ((res = reader.ReadLine()) == null) {
                    throw new IOException("not the correct format");
                }
            }

            return res;
        }
    }
}