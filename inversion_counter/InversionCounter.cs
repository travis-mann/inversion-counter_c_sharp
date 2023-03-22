////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : InversionCounter.cs
//Author      : Travis Mann
//Date        : 01/13/2023
//Description : Script for counting the number of inversions in an array of BigIntegeregers from BigInteger_array.txt
//              using a divide and conquer paradigm.
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
            // store start time
            DateTime startTime = DateTime.Now;

            // count inversions in list of BigIntegers from int_array.txt using brute force method
            Console.WriteLine("Starting brute force approach");
            Console.WriteLine($"    Inversions: {slowInversionCount(GetBigIntegerArray())}");

            // calculate total run time
            Console.WriteLine($"    Brute Force Total Run Time: {(DateTime.Now - startTime).TotalSeconds} seconds");

            // update start time
            startTime = DateTime.Now;

            // count inversions in list of BigIntegers from int_array.txt using divide and conquer algorithm
            Console.WriteLine("Starting divide and conquer approach");
            Console.WriteLine($"    Inversions: {SortAndCount(GetBigIntegerArray()).Item2}");
            
            // calculate total run time
            Console.WriteLine($"    Divide and Conquer Total Run Time: {(DateTime.Now - startTime).TotalSeconds} seconds");
        }

        // public: allows other classes to access the method such as unit testing
        // static: indicates that the method can be used outside of a specific class instance
        // BigInteger: indicates that the method returns a BigInteger
        public static (BigInteger[], BigInteger) SortAndCount(BigInteger[] array)
        {
            /// <summary>
            /// Inversion counting algorithm using the divide and conquer paradigm for the given array.
            /// Uses sort algoritm from MergeSort to count inversions while sorting.
            /// </summary>
            /// <param name="array">Array to count inversions in</param>
            /// <returns>
            /// <param name="sortedArray">Sorted input array</param>
            /// <param name="inversionCount">Number of pairs (i, j) in Array where i < j and Array[i] > A[j]</param>
            /// </returns>

            // Step 1: Check for base case
            if (array.Length == 1)
            {
                // inversions are not possible in arrays with only 1 element
                // 1 element array is already sorted
                return (array, 0);
            }

            // Step 2: Split array in 2 halves with the same number of elements
            (BigInteger[] array1, BigInteger[] array2) = SplitArray(array);

            // Step 3: Recursive calls to "conquer" the "divided" array
            (BigInteger [] sortedArray1, BigInteger inversionCount1) = SortAndCount(array1);
            (BigInteger[] sortedArray2, BigInteger inversionCount2) = SortAndCount(array2);

            // Step 4: Count split inversions between arrays
            (BigInteger[] mergedArray, BigInteger splitInversionCount) = MergeAndCountSplitInv(sortedArray1, sortedArray2);

            // Step 5: Return merged array & total inversion count
            return (mergedArray, inversionCount1 + inversionCount2 + splitInversionCount);
        }

        public static (BigInteger[], BigInteger) MergeAndCountSplitInv(BigInteger[] array1, BigInteger[] array2)
        {
            /// <summary>
            /// Merge the 2 arrays per the MergeSort algorithm by counting 
            /// the number of elements left in array1 every time an element 
            /// in array2 is added to the final array.
            /// </summary>
            /// <param name="array1">Array to compare with array2 to count 
            /// split inversions</param>
            /// <param name="array2">Array to compare with array2 to count 
            /// split inversions</param>
            /// <returns>
            /// <param name="splitInversionCount">Number of pairs (i, j) 
            /// where i is an element of array1, j is an element of array2, 
            /// i < jand Array[i] > A[j]</param>
            /// </returns>

            // Step 1: Create final array to merge BigIntegero
            BigInteger[] mergedArray = new BigInteger[array1.Length + array2.Length];

            // Step 2: Track count of split inversions
            int splitInversionCount = 0;

            // Step 3: Create poBigIntegerers for both input arrays
            int i = 0;
            int j = 0;

            // Step 4: iterate over combined length of both input arrays
            for (int k = 0; k < mergedArray.Length; k++)
            {
                // Step 4.1: Compare currently indexed elements
                // Step 4.1 - Case 1: next element in array1 is smaller

                if (
                    // check that array 2 is exhausted and array1 still has elements
                    (j >= array2.Length)  // array 2 is exhausted
                    ||
                    (
                        (i < array1.Length) // array 1 still has elements to add
                        && (array1[i] < array2[j])  // next array1 element less than next array2 element
                    )
                    )
                {
                    // Step 4.1 - Case 2 Step 1: no split inversions for this iteration

                    // Step 4.1 - Case 2 Step 2: Add next array1 element to final array
                    mergedArray[k] = array1[i];

                    // Step 4.1 - Case 2 Step 3: Increment array1 poBigIntegerer
                    i++;

                }
                // Step 4.1 - Case 2: next element in array2 is smaller
                else
                {
                    // Step 4.1 - Case 2 Step 1: Increment split inversions
                    // by number of elements left in array1
                    splitInversionCount += array1.Length - i;

                    // Step 4.1 - Case 2 Step 2: Add next array2 element to final array
                    mergedArray[k] = array2[j];

                    // Step 4.1 - Case 2 Step 3: Increment array2 poBigIntegerer
                    j++;
                }
            }

            // Step 4: Return final split inversion count
            return (mergedArray, splitInversionCount);
        }

        public static (BigInteger[], BigInteger[]) SplitArray(BigInteger[] arrayToSplit)
        {
            /// <summary>
            /// Splits a given array BigIntegero 2 arrays roughly in the center
            /// </summary>
            /// <param name="arrayToSplit">Single array to split in 2</param>
            /// <returns>
            /// <param name="splitArrays">Array of 2 arrays which together form the original array</param>
            /// </returns>

            // init vars
            int splitNum = arrayToSplit.Length / 2;
            BigInteger[] array1 = new BigInteger[splitNum];

            // add extra element to array 2 if arrayToSplit.Length is odd
            BigInteger[] array2;
            if (arrayToSplit.Length % 2 == 0)
            {
                array2 = new BigInteger[splitNum];
            }
            else  // arrayToSplit.Length is odd
            {
                array2 = new BigInteger[splitNum + 1];
            }
            
            // slice
            Array.Copy(arrayToSplit, 0, array1, 0, array1.Length);
            Array.Copy(arrayToSplit, array1.Length, array2, 0, array2.Length);

            // package and return
            return (array1, array2);
        }

        public static BigInteger[] StringArrayToBigIntegerArray(string[] stringArray)
        {
            /// <summary>
            /// Converts an array of strings to an array of BigIntegers 
            /// given that those strings can be converted to BigIntegers
            /// </summary>
            /// <param name="stringArray">Array of BigIntegers as string types</param>
            /// <returns>
            /// <param name="BigIntegerArray">stringArray converted to an array of BigIntegers</param>
            /// </returns>
            
            return Array.ConvertAll(stringArray, s => BigInteger.Parse(s));
        }

        public static string LoadIntArrayToString()
        {
            /// <summary>
            /// Loads BigInteger array from BigInteger_array.txt BigIntegero a singular string
            /// </summary>
            /// <returns>
            /// <param name="BigIntegerArrayStr">Contents of BigInteger_array.txt as a string</param>
            /// </returns>
            
            return System.IO.File.ReadAllText(@"int_array.txt");
        }

        public static BigInteger[] GetBigIntegerArray()
        {
            /// <summary>
            /// Loads BigInteger array from BigInteger_array.txt BigIntegero an BigInteger array
            /// </summary>
            /// <returns>
            /// <param name="BigIntegerArray">array of BigIntegers from BigInteger_array.txt</param>
            /// </returns>
            
            return StringArrayToBigIntegerArray(LoadIntArrayToString().Split('\n'));
        }

        static BigInteger slowInversionCount(BigInteger[] array)
        {
            /// <summary>
            /// Brute force inversion counter without divide and conquer
            /// </summary>
            /// <param name="array">array of integers to count inversions from</param>
            /// <returns>
            /// <param name="inversionCount">count of inversion in given array</param>
            /// </returns>

            // get number of elements
            BigInteger n = array.Length;

            // init inversion count
            BigInteger inversionCount = 0;

            // iterate all elements in the array
            for (int i = 0; i < n - 1; i++)
                // iterate over all remaining elements
                // to check for inversions
                for (int j = i + 1; j < n; j++)
                    // check if current remaining element is larger than
                    // current indexed element
                    if (array[i] > array[j])
                        // inversion found: increment inversions
                        inversionCount++;

            // return final inversion count
            return inversionCount;
        }
    }
}
