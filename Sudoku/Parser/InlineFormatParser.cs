using SudokuBoard;

namespace Parser {
    public class InlineFormatParser : ISudokuParser
    {
        public IESudoku parse(String input)
        {
            StreamReader reader = new StreamReader(File.OpenRead(input));
            string sudoku = reader.ReadLine();
            System.Console.WriteLine("new commit");
            
        }
    }
}