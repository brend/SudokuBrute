if (Sudoku.Arguments.ReadBoardFromInput() is Sudoku.Board board)
{
    var solver = new Sudoku.Solver();

    if (solver.Solve(board) is Sudoku.Board solution)
    {
        Console.WriteLine(solution.Dump());
    }
    else 
    {
        Console.Error.WriteLine("No solution found");
    }
}