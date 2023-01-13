////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : InversionCounter.cs
//Author      : Travis Mann
//Date        : 01/13/2023
//Description : Script for counting the number of inversions in an array of integers.
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using System;
using System.Numerics;


// --- classes ---
namespace InversionCounter
{
    public class program
    {
        public static void Main()
        {
            // todo
        }

        public static int CountInversions(int[] array)
        {
            // step 1: check base case
            if (array.Length == 1)
            {
                return 0;  // 0 inversions in an array of length 1 
            }

            // step 2: split array in half
            int[][] splitArrays = SplitArray(array);

            // step 3: count left and right inversions
            int leftInversionCount = CountInversions(splitArrays[0]);
            int rightInversionCount = CountInversions(splitArrays[0]);

            // step 4: count split inversions (inversions between 2 halves)
            int splitInversionCount = CountSplitInversions(splitArrays[0], splitArrays[1]);

            // test - todo
            return leftInversionCount + rightInversionCount + splitInversionCount;
        }

        public static int CountSplitInversions(int[] array1, int[] array2)
        {
            // todo
            return 0;
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
            Console.WriteLine($"array2.Length {array2.Length}");
            
            // slice
            Array.Copy(arrayToSplit, 0, array1, 0, array1.Length);
            Array.Copy(arrayToSplit, array1.Length, array2, 0, array2.Length);

            // package and return
            return new int[][] {array1, array2};
        }

        public static int[] SortArray(int[] arrayToSplit)
        {
            /// <summary>
            /// Splits a given array into 2 arrays roughly in the center
            /// </summary>
            /// <param name="arrayToSplit">Single array to split in 2</param>
            /// <returns>
            /// <param name="splitArrays">Array of 2 arrays which together form the original array</param>
            /// </returns>

            // todo
        }
    }
}
