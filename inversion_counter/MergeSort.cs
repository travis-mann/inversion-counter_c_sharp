////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : merge_sort.cs
//Author      : Travis Mann
//Date        : 01/03/2023
//Description : Script for running the merge sort algorithm
////////////////////////////////////////////////////////////////////////////////////////////////////////


namespace InversionCounter
{
    public class MergeSort
    {
        public static int[] Run(int[] arrayToSort)
        {
            /// <summary>
            /// Perform recursive merge sort algorithm -> O(nlogn) computations
            /// </summary>
            /// <param name="arrayToSort">Array of random ints to sort</param>
            /// <returns>
            /// mergedArray: sorted array from merging firstArray and secondArray
            /// </returns>

            // base case: ArrayToSort has only 1 element
            if (arrayToSort.Length <= 1)
            {
                return arrayToSort;
            }

            // step 0: split array
            int[][] splitArrays = SplitArray(arrayToSort);

            // step 1: 1st half recursive sort
            int[] firstHalfSorted = Run(splitArrays[0]);

            // step 2:  2nd half recursive sort
            int[] secondHalfSorted = Run(splitArrays[1]);

            // step 3: merge 1st and 2nd half
            return Merge(firstHalfSorted, secondHalfSorted);
        }

        public static int[] Merge(int[] firstArray, int[] secondArray)
        {
            /// <summary>
            /// Merge functionality for MergeSort.
            /// </summary>
            /// <param name="firstArray">Sorted array to merge with secondArray.</param>
            /// <param name="secondArray">Sorted array to merge with firstArray.</param>
            /// <returns>
            /// mergedArray: sorted array from merging firstArray and secondArray
            /// </returns>

            // declare final array
            int totalLength = firstArray.Length + secondArray.Length;
            int[] mergedArray = new int[totalLength];

            // set array indecies
            int firstArrayIndex = 0;
            int secondArrayIndex = 0;

            // loop through arrays
            for (int mergedArrayIndex = 0; mergedArrayIndex < totalLength; mergedArrayIndex++)
            {
                // handle cases with remaining elements in both arrays
                // add next element from 1st array if 2nd array is out of elements or if 1st array still has elements 
                // and the next element from the 1st array is less than the next element from the 2nd array
                if (secondArrayIndex >= secondArray.Length || firstArrayIndex < firstArray.Length && firstArray[firstArrayIndex] < secondArray[secondArrayIndex])
                {
                    // add next element from 1st array to final array
                    mergedArray[mergedArrayIndex] = firstArray[firstArrayIndex];
                    // increment 1st array index now that the current element has been handled
                    firstArrayIndex++;
                }
                else  // next element in 2nd array is smaller
                {
                    // add next element from 2nd array to final array
                    mergedArray[mergedArrayIndex] = secondArray[secondArrayIndex];
                    // increment 1st array index now that the current element has been handled
                    secondArrayIndex++;
                }

            }

            // output merged array
            return mergedArray;
        }

        public static int[][] SplitArray(int[] arrayToSplit)
        {
            /// <summary>
            /// Splits a given array into 2 arrays roughly in the center
            /// </summary>
            /// <param name="arrayToSplit">Single array to split in 2</param>
            /// <returns>
            /// <param name="splitArrays">Array of 2 arrays which together form the original array</param>
            /// </returns>

            // init vars
            int splitNum = arrayToSplit.Length / 2;
            int[] array1 = new int[splitNum];

            // add extra element to array 2 if arrayToSplit.Length is odd
            int[] array2;
            if (arrayToSplit.Length % 2 == 0)
            {
                array2 = new int[splitNum];
            }
            else  // arrayToSplit.Length is odd
            {
                array2 = new int[splitNum + 1];
            }

            // slice
            Array.Copy(arrayToSplit, 0, array1, 0, array1.Length);
            Array.Copy(arrayToSplit, array1.Length, array2, 0, array2.Length);

            // package and return
            return new int[][] { array1, array2 };
        }
    }
}