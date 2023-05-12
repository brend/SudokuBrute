var filename = Environment.GetCommandLineArgs().Skip(1).FirstOrDefault();

if (filename == null)
{
    Console.Error.WriteLine("Usage: sudoku <puzzle filename>");
    return;
}

var text = File.ReadAllText(filename);
var boardData =
    text.ToCharArray()
        .Where(c => !new[]{',', ' ', '\n', '\r', '\t'}.Contains(c))
        .Select(c => int.Parse("" + c))
        .ToArray();
var board = new Sudoku.Board(boardData);
var solver = new Sudoku.Solver();

if (solver.Solve(board) is Sudoku.Board solution)
{
    Console.WriteLine("Solution:");
    Console.WriteLine(solution.Dump());
}
else 
{
    Console.WriteLine("No solution found");
}