////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : MergeSortTests.cs
//Author      : Travis Mann
//Date        : 01/14/2023
//Description : Script for testing MergeSort.cs
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using Xunit;


// --- classes ---
namespace InversionCounter.Tests
{
    public class MergeSortTests
    {
        [Fact]
        public void RunTest()
        {
            // step 1: arrange
            int[] arrayToSort = { 10, 9, 7, 6, 5, 54, 101, 2, -1, 0 };
            int[] expected = { -1, 0, 2, 5, 6, 7, 9, 10, 54, 101 };

            // step 2: act
            int[] actual = MergeSort.Run(arrayToSort);

            // step 3: assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void SplitArraysTest()
        {
            // step 1: Arrange
            int[] array = { 1, 5, 9, 3, 44 };
            int[][] expected = { new int[] { 1, 5 }, new int[] { 9, 3, 44 } };

            // step 2: Act
            int[][] actual = MergeSort.SplitArray(array);

            // step 3: Assert
            Assert.Equal(expected, actual);
        }
        }
}
