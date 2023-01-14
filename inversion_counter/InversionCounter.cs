////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : InversionCounter.cs
//Author      : Travis Mann
//Date        : 01/13/2023
//Description : Divide and conquer algorithm for counting the number of inversions in an array of
//              integers.
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using System.Numerics;


// --- classes ---
namespace InversionCounter
{
    public class CountInversions
    {
        public static BigInteger Run(int[] array)
        {
            /// <summary>Divide and conquer algorithm for counting inversions 
            ///          in a given integer array with no repeats</summary>
            /// <param name="array">array to count inversions from</param>
            /// <returns>Count of inversions in the given array</returns>

            // announce start
            //Console.WriteLine($"Counting inversions in {array.Length} element array");

            // step 1: check base case
            if (array.Length == 1)
            {
                return 0;  // 0 inversions in an array of length 1 
            }
            // step 2: split array in half
            int[][] splitArrays = MergeSort.SplitArray(array);

            // step 3: count left and right inversions
            BigInteger leftInversionCount = CountInversions.Run(splitArrays[0]);
            BigInteger rightInversionCount = CountInversions.Run(splitArrays[1]);

            // step 4: count split inversions (inversions between 2 halves)
            BigInteger splitInversionCount = CountSplitInversions(splitArrays[0], splitArrays[1]);

            // step 5: total inversion counts
            BigInteger totalInversions = leftInversionCount + rightInversionCount + splitInversionCount;
            BigInteger maxInversions = (new BigInteger (array.Length - 1) * array.Length) / 2;
            if (totalInversions > maxInversions)
            {
                throw new ArgumentOutOfRangeException($"total inversions ({totalInversions}) exceeded maximum possible inversions {maxInversions}");
            }
            return totalInversions;
        }

        public static BigInteger CountSplitInversions(int[] array1, int[] array2)
        {
            /// <summary>Counts inversions across 2 split arrays</summary>
            /// <param name="array1">1st array to analyze</param>
            /// <param name="array2">2nd array to analyze</param>
            /// <returns>Count of inversions between the given arrays</returns>

            // step 1: sort input arrays, O(nlogn)
            int[] sortedArray1 = MergeSort.Run(array1);
            int[] sortedArray2 = MergeSort.Run(array2);

            // step 2: initialize final count
            BigInteger splitInversionCount = 0;

            // step 3: iterate over sorted arrays with pointers
            int arrayIndex1 = 0;
            int arrayIndex2 = 0;
            for (int mergedArrayIndex = 0; mergedArrayIndex < sortedArray1.Length + sortedArray2.Length; mergedArrayIndex++)
            {
                // step 3.1: compare next element in each array
                // 1st branch taken if 1. array 2 is out of elements or
                // 2. array 1 has elements and next array 1 element less than next array 2 element
                if (arrayIndex2 >= sortedArray2.Length || (arrayIndex1 < sortedArray1.Length && sortedArray1[arrayIndex1] < sortedArray2[arrayIndex2]))
                {
                    // inc index for array 1
                    arrayIndex1++;
                }
                else  // next array 2 element is smaller
                {
                    // calculate split inversion count (total array 1 indicies - current array 1 index
                    splitInversionCount += sortedArray1.Length - arrayIndex1;

                    // inc index for array 2
                    arrayIndex2++;
                }
            }

            // step 4: return final count
            return splitInversionCount;
        }
    }
}
