////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : Main.cs
//Author      : Travis Mann
//Date        : 01/14/2023
//Description : Script for counting the number of inversions in an array of integers from a text file.
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- classes ---
namespace InversionCounter
{
    internal class Program
    {
        public static void Main()
        {
            /// <summary>Counts inversions in an integer array 
            ///          from a text file</summary>
            /// <returns>Count of inversions in the specified array</returns>

            // step 1: read array from txt file
            string filePath = "../../../IntegerArray.txt";
            int[] array = Array.ConvertAll(System.IO.File.ReadAllLines(@filePath), s => int.Parse(s));

            // step 2: count inversions
            TimeSpan startTime = DateTime.Now.TimeOfDay;

            // step 3: count inversions
            Console.WriteLine("starting inversion count...");
            Console.WriteLine($"Inversion Count: {CountInversions.Run(array)}");

            // step 4: show total run time
            TimeSpan endTime = DateTime.Now.TimeOfDay;
            Console.WriteLine($"Inversion counter run Time {endTime - startTime}");
        }
    }
}
