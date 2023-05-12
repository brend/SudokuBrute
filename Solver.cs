namespace Sudoku
{
    using System.Linq;

    using Place = System.Int32;
    using Move = System.Int32;

    public class Solver
    {
        public Board? Solve(Board initialBoard)
        {
            var queue = new Queue<Board>();

            queue.Enqueue(new Board(initialBoard));

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
                    foreach (Move move in GetMoves(board, place))
                    {
                        Board successor = new Board(board, place, move);

                        queue.Enqueue(successor);
                    }
                }
            }

            return null;
        }

        Place? GetFreePlace(Board board) => board.GetFreePlace();

        Move? GetMove(Board board, Place place)
        {
            foreach (var move in Enumerable.Range(1, 9))
            {
                var attempt = new Board(board, place, move);

                if (attempt.IsConsistent)
                {
                    return move;
                }
            }

            return null;
        }

        IEnumerable<Move> GetMoves(Board board, Place place)
        {
            foreach (var move in Enumerable.Range(1, 9))
            {
                var attempt = new Board(board, place, move);

                if (attempt.IsConsistent)
                {
                    yield return move;
                }
            }
        }
    }
}