﻿
var board = new Sudoku.Board(
    // new int[]
    // {
    //     1,4,5, 3,2,7, 6,9,8,
    //     8,3,9, 6,5,4, 1,2,7,
    //     6,7,2, 9,1,8, 5,4,3,
    //     4,9,6, 1,8,5, 3,7,2,
    //     2,1,8, 4,7,3, 9,5,6,
    //     7,5,3, 2,9,6, 4,8,1,
    //     3,6,7, 5,4,2, 8,1,9,
    //     9,8,4, 7,6,1, 2,3,5,
    //     5,2,1, 8,3,9, 7,6,4
    // }
    new int[]
    {
        0,0,0, 0,5,1, 0,3,0,
        0,0,5, 0,0,0, 0,4,0,
        0,7,4, 0,0,2, 0,0,0,

        4,9,6, 0,7,0, 3,0,0,
        7,0,0, 2,0,8, 9,0,0,
        2,0,8, 0,0,9, 4,7,5,

        0,0,1, 0,0,7, 8,9,0,
        8,2,7, 5,9,0, 1,6,0,
        6,4,0, 0,1,0, 5,0,0
    }
);

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