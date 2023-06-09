namespace Sudoku
{
    using Place = System.Int32;
    using Move = System.Int32;

    public struct Board
    {
        public Board(int[] places)
        {
            if (places == null)
            {
                throw new ArgumentNullException(nameof(places));
            }

            if ((places.Length) < 81)
            {
                throw new ArgumentException("expected 81 integers", nameof(places));
            }

            if (places.Any(i => i < 0 || i > 9))
            {
                throw new ArgumentException("expected only integers between 0 and 9 inclusively", nameof(places));
            }

            var myPlaces = (int[])places.Clone();
            
            Places = myPlaces;

            _isConsistent = new Lazy<bool>(() => ComputeConsistency(myPlaces));
        }

        public Board(Board b, Place p, Move m)
        {
            if (p < 0 || p >= b.Places.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(p));
            }

            if (m < 1 || m > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(m));
            }

            var myPlaces = (int[])b.Places.Clone();

            Places = myPlaces;
            Places[p] = m;

            _isConsistent = new Lazy<bool>(() => ComputeConsistency(myPlaces));
        }

        private int[] Places { get; set; }

        public bool IsSolved => IsConsistent && Array.IndexOf(Places, 0) < 0;

        private Lazy<bool> _isConsistent;

        public bool IsConsistent => _isConsistent.Value;

        private static bool TestConsistency(int[] places, Func<int, int> mapIndex)
        {
            int[] test = new int[10];

            foreach (var i in Enumerable.Range(0, 9))
            {
                var index = mapIndex(i);
                var move = places[index];

                test[move] += 1;

                if (move == 0)
                {
                    continue;
                }

                if (test[move] > 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool RowConsistent(int[] places, int row) =>
            TestConsistency(places, i => i + row * 9);

        private static bool ColumnConsistent(int[] places, int column) =>
            TestConsistency(places, i => column + i * 9);

        private static bool BoxConsistent(int[] places, int box) =>
            TestConsistency(places, i => 3 * (box % 3) + 3 * 9 * (box / 3) + 9 * (i / 3) + (i % 3));

        private static bool ComputeConsistency(int[] places)
        {
            foreach (var i in Enumerable.Range(0, 9))
            {
                if (!(RowConsistent(places, i)
                    && ColumnConsistent(places, i)
                    && BoxConsistent(places, i)))
                {
                    return false;
                }
            }

            return true;
        }

        public string Dump() =>
            string.Join("\n",
                Places.Chunk(9).Select(row => string.Join(" ", row))
            );

        public Place? GetFreePlace() 
        {
            int index = Array.IndexOf(Places, 0);

            return index < 0 ? null : index;
        }
    }
}