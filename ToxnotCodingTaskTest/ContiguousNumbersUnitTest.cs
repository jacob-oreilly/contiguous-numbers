using System;
using System.Linq;
using Xunit;
using ToxnotCodingTask;
namespace ToxnotCodingTaskTest
{
    public class ContiguousNumbersUnitTest
    {
        [Fact]
        public void ContiguousTest()
        {
            int[] numberArray = new[] { 0, 1, 2, 4, 5, 9, 10, 11 };
            int[][] result = ContiguousNumbers.GetContiguousNumbers(numberArray);
            int[][] expectedResult = new int[][] { new int[3] { 0, 1, 2 }, new int[2] { 4, 5 }, new int[3] { 9, 10, 11 } };
            for(int i = 0; i < expectedResult.Length; i++)
            {
                for(int j = 0; j < expectedResult[i].Length; j++)
                {
                    Assert.Equal(expectedResult[i][j], result[i][j]);
                }
            }
        }
    }
}
