using SudokuBoard;

namespace Parser {
    public interface ISudokuParser {
        public IESudoku parse(String input);
    }
}