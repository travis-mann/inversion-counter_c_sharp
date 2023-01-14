////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : InversionCounter.cs
//Author      : Travis Mann
//Date        : 01/13/2023
//Description : Script for counting the number of inversions in an array of integers.
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using System.Numerics;
using Xunit;


// --- classes ---

namespace InversionCounter.Tests
{
    public class InversionCounterTests
    {
        [Fact]
        public void RunTest()
        {
            // step 1: Arrange
            int[] array = { 1, 5, 9, 3, 44 };
            int expected = 2;

            // step 2: Act
            int actual = program.CountInversions(array);

            // step 3: Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CountSplitInversionsTest()
        {
            // step 1: Arrange
            int[] array1 = { 2, 3, 4 };
            int[] array2 = { 1, 5, 6 };
            int expected = 3;

            // step 2: Act
            int actual = program.CountSplitInversions(array1, array2);

            // step 3: Assert
            Assert.Equal(expected, actual);
        }

    }
}