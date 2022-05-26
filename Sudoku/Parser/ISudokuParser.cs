using SudokuBoard;

namespace Parser {
    public interface ISudokuParser {
        /// <summary>
        /// Parse a sudoku in inline format into an obj
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A representation of sudoku depending on impl</returns>
        public IESudoku parse(String input);

        public string read(String file);
    }
}