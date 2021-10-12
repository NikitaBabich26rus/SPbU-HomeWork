using System.Collections.Generic;

namespace test2._2
{
    /// <summary>
    /// Generic bubble sorting class.
    /// </summary>
    public static class BubbleSort
    {
        /// <summary>
        /// Sorting.
        /// </summary>
        /// <param name="list">List for sorting.</param>
        /// <param name="comparer">Comparer.</param>
        /// <returns>Sorted list.</returns>
        public static List<T> Sort<T>(List<T> list, IComparer<T> comparer)
        {
            for (int i = 0; i < list.Count - 1; ++i)
            {
                for (int j = 0; j < list.Count - i - 1; ++j)
                {
                    if (comparer.Compare(list[j], list[j + 1]) > 0)
                    {
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    }
                }
            }
            return list;
        }
    }
}
