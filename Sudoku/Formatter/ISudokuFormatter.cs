using SudokuBoard;

namespace Formatter {
    public interface ISudokuFormatter {
        /// <summary>
        /// Make a formatter string output for a board
        /// </summary>
        /// <param name="board"></param>
        /// <returns>a formatted string</returns>
        public string format(IESudoku board);
        
    }
}