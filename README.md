# SudokuBrute

A brute force sudoku solver.

This will save you from ever having to do
a Sudoku again. 
Good riddance to that pointless exercise!

## Puzzle Format

Sudoku Brute expects puzzles in a simple text format:

```
000 000 006
031 000 790
000 007 000

008 000 069
920 000 041
640 000 800

000 300 000
016 020 980
500 069 002
```

## Building
```$ dotnet build SudokuBrute.sln ```

## Running

The program reads input from standard input:

```$ dotnet run < samples/puzzle3.txt```

This will output a solution to the puzzle:

```
2 5 7 8 9 3 4 1 6
4 3 1 2 5 6 7 9 8
8 6 9 1 4 7 3 2 5
1 7 8 4 3 5 2 6 9
9 2 3 6 7 8 5 4 1
6 4 5 9 1 2 8 7 3
7 9 2 3 8 1 6 5 4
3 1 6 5 2 4 9 8 7
5 8 4 7 6 9 1 3 2
```