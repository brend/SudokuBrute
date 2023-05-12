namespace Sudoku
{
    using System.Linq;

    using Place = System.Int32;

    public class Solver
    {
        public Board? Solve(Board initialBoard)
        {
            var queue = new Queue<Board>();

            queue.Enqueue(initialBoard);

            while (queue.Count > 0)
            {
                Console.WriteLine($"{queue.Count} boards left to try");

                var board = queue.Dequeue();

                if (board.IsSolved)
                {
                    return board;
                }

                if (GetFreePlace(board) is Place place)
                {
                    foreach (Board successor in GetSuccessors(board, place))
                    {
                        queue.Enqueue(successor);
                    }
                }
            }

            return null;
        }

        Place? GetFreePlace(Board board) => board.GetFreePlace();

        IEnumerable<Board> GetSuccessors(Board board, Place place)
        {
            foreach (var move in Enumerable.Range(1, 9))
            {
                var attempt = new Board(board, place, move);

                if (attempt.IsConsistent)
                {
                    yield return attempt;
                }
            }
        }
    }
}