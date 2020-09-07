using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    /// <summary>
    /// Vector`s operations.
    /// </summary>
    public static class VectorsOperations
    {
        /// <summary>
        /// Vector`s addition
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>vvector result</returns>
        public static VectorOnList Addition(VectorOnList vector1, VectorOnList vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                throw new VectorSizeException();
            }
            int[] arrayVector1 = vector1.GetVectorArray();
            int[] arrayVector2 = vector2.GetVectorArray();
            int[] sumArray = new int[arrayVector1.Length];
            for (int i = 0; i < arrayVector1.Length; i++)
            {
                sumArray[i] = arrayVector1[i] + arrayVector2[i];
            }
            return new VectorOnList(sumArray);
        }

        /// <summary>
        /// Vector`s substraction
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>vector result</returns>
        public static VectorOnList Subtraction(VectorOnList vector1, VectorOnList vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                throw new VectorSizeException();
            }
            int[] arrayVector1 = vector1.GetVectorArray();
            int[] arrayVector2 = vector2.GetVectorArray();
            int[] sumArray = new int[arrayVector1.Length];
            for (int i = 0; i < arrayVector1.Length; i++)
            {
                sumArray[i] = arrayVector1[i] - arrayVector2[i];
            }
            return new VectorOnList(sumArray);
        }

        /// <summary>
        /// Vector`s ScalarMultiplication.
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>Vector result</returns>
        public static int ScalarMultiplication(VectorOnList vector1, VectorOnList vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                throw new VectorSizeException();
            }
            int[] arrayVector1 = vector1.GetVectorArray();
            int[] arrayVector2 = vector2.GetVectorArray();
            int answer = 0;
            for (int i = 0; i < arrayVector1.Length; i++)
            {
                answer += arrayVector1[i] * arrayVector2[i];
            }
            return answer;
        }

        /// <summary>
        /// Get vector`s clone
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <returns>Vector`s clone</returns>
        public static VectorOnList GetVectorClone(VectorOnList vector)
        {
            int[] vectorArray = vector.GetVectorArray();
            return new VectorOnList(vectorArray);
        }
    }
}
