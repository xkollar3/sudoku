using Formatter;
using Parser;
using SudokuBoard;

namespace Sudoku {
    public class App {
        public static void Main(String[] argv) {
            if (argv.Length < 1) {
                System.Console.WriteLine("please provide a source for a sudoku file");
                System.Environment.Exit(1);
            }

            string sudokuPath = argv[0];

            ISudokuFormatter formatter = new CmdFormatter();
            ISudokuParser parser = new InlineFormatParser();
            IESudoku sudoku = parser.parse(sudokuPath);

            
            System.Console.WriteLine(formatter.format(sudoku));
            if (!sudoku.solve()) {
                System.Console.WriteLine("Sudoku cannot be solved");
                System.Environment.Exit(1);
            }
            System.Console.WriteLine("Succesfully solved sudoku solution:");
            System.Console.WriteLine(formatter.format(sudoku));

            
        }
    }
}