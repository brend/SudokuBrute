namespace Sudoku
{
    using Place = System.Int32;
    using Move = System.Int32;

    public struct Board
    {
        public Board(int[] places)
        {
            Places = (int[])places.Clone();
            IsConsistent = ComputeConsistency(Places);
            IsSolved = IsConsistent && Array.IndexOf(Places, 0) < 0;
        }

        public Board(): this(new int[9 * 9])
        {
        }

        public Board(Board b): this(b.Places)
        {
        }

        public Board(Board b, Place p, Move m)
        {
            Places = (int[])b.Places.Clone();
            Places[p] = m;
            IsConsistent = ComputeConsistency(Places);
            IsSolved = IsConsistent && Array.IndexOf(Places, 0) < 0;
        }

        private int[] Places { get; set; }

        public bool IsSolved { get; }

        public bool IsConsistent { get; }

        private static bool ComputeConsistency(int[] places)
        {
            foreach (var row in Enumerable.Range(0, 9))
            {
                int[] test = new int[10];

                foreach (var col in Enumerable.Range(0, 9))
                {
                    var index = col + row * 9;
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
            }

            foreach (var col in Enumerable.Range(0, 9))
            {
                int[] test = new int[10];

                foreach (var row in Enumerable.Range(0, 9))
                {
                    var index = col + row * 9;
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
            }

            foreach (var box in Enumerable.Range(0, 9))
            {
                int[] test = new int[10];

                foreach (var cell in Enumerable.Range(0, 9))
                {
                    var index = 3 * (box % 3) + 3 * 9 * (box / 3) + 9 * (cell / 3) + (cell % 3);
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