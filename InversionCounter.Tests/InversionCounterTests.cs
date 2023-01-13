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
            int expected = 0;

            // step 2: Act
            int actual = program.CountInversions(array);

            // step 4: Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitArraysTest()
        {
            // step 1: Arrange
            int[] array = { 1, 5, 9, 3, 44 };
            int[][] expected = { new int[] { 1, 5 }, new int[] { 9, 3, 44 } };

            // step 2: Act
            int[][] actual = program.SplitArray(array);

            // step 4: Assert
            Assert.Equal(expected, actual); 
        }
    }
}