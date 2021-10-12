using System.Threading.Tasks;

namespace Test4
{
    public class QSort
    {

        /// <summary>
        /// Return support element index.
        /// </summary>
        /// <param name="minIndex">First index of array</param>
        /// <param name="maxIndex">Second index of array</param>
        /// <returns>Support element</returns>
        private static int ReturnSupportElementIndex(int[] array, int minIndex, int maxIndex)
        {
            var supportElement = minIndex - 1;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    supportElement++;
                    (array[supportElement], array[i]) = (array[i], array[supportElement]);
                }
            }
            supportElement++;
            (array[supportElement], array[maxIndex]) = (array[maxIndex], array[supportElement]);
            return supportElement;
        }

        /// <summary>
        /// Single threaded quick sort function
        /// </summary>
        /// <param name="minIndex">First index</param>
        /// <param name="maxIndex">Second index</param>
        /// <returns>Array</returns>
        private static int[] SingleQuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var supportIndex = ReturnSupportElementIndex(array, minIndex, maxIndex);

            SingleQuickSort(array, minIndex, supportIndex - 1);
            SingleQuickSort(array, supportIndex + 1, maxIndex);
            return array;
        }

        /// <summary>
        /// Multi threaded quick sort function
        /// </summary>
        /// <param name="minIndex">First index</param>
        /// <param name="maxIndex">Second index</param>
        /// <returns>Array</returns>
        private static int[] MultiQuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }
            var supportIndex = ReturnSupportElementIndex(array, minIndex, maxIndex);
            Parallel.Invoke(
                () => MultiQuickSort(array, minIndex, supportIndex - 1),
                () => MultiQuickSort(array, supportIndex + 1, maxIndex)
            );
            return array;
        }

        /// <summary>
        /// Single-threaded implementation
        /// </summary>
        /// <param name="array">Array</param>
        /// <returns>Sorted array</returns>
        public int[] SingleThreadedQuickSort(int[] array) => SingleQuickSort(array, 0, array.Length - 1);

        /// <summary>
        /// Multithreaded implementation
        /// </summary>
        /// <param name="array">Array</param>
        /// <returns>Sorted array</returns>
        public int[] MultiThreadedQuickSort(int[] array) => MultiQuickSort(array, 0, array.Length - 1);
    }
}
