namespace Sudoku
{
    public static class Arguments
    {
        public static string? ReadInput()
        {
            TextReader reader;
            var filename = Environment.GetCommandLineArgs().Skip(1).FirstOrDefault();

            if (filename == null)
            {
                reader = Console.In;
            }
            else 
            {
                try
                {
                    reader = new StreamReader(filename);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                    return null;
                }
            }

            try
            {
                return reader.ReadToEnd();
            }
            finally 
            {
                reader.Close();
            }
        }

        public static Board? ParseBoard(string text)
        {
            char[] charactersToIgnore = new[]{',', ' ', '\n', '\r', '\t'};
            var boardData = 
                text.ToCharArray()
                    .Where(c => !charactersToIgnore.Contains(c))
                    .Select(c => int.Parse(c.ToString()))
                    .ToArray();
            var board = new Sudoku.Board(boardData);

            return board;
        }

        public static Board? ReadBoardFromInput()
        {
            if (ReadInput() is string text)
            {
                return ParseBoard(text);
            }
            else 
            {
                return null;
            }
        }
    }
}