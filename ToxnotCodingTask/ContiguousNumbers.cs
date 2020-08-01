using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ToxnotCodingTask
{
    public class ContiguousNumbers
    {
        static void Main(string[] args)
        {
            var escape = false;
            //TEST INPUT ARRAY 
            //int[] numberArray = new[] { 0, 1, 2, 4, 5, 9, 10, 11 };
            while (!escape)
            {
                Console.WriteLine("Type in a list of sets of congituous numbers in ascending order seperated with a comma and hit Enter: ");
                var numberList = Console.ReadLine();
                Console.WriteLine("Inputing: " + numberList);
                try
                {
                    string[] inputValues = numberList.Split(',');
                    int[] numberArray = Array.ConvertAll<string, int>(inputValues, int.Parse);

                    var returnItem = GetContiguousNumbers(numberArray);

                    //Formatting final string output.
                    if (returnItem.Length != 0)
                    {
                        var returnString = "[";
                        foreach (var outerNumber in returnItem)
                        {
                            var innerString = "[ ";
                            foreach (var innerNumber in outerNumber)
                            {
                                if (innerNumber == outerNumber.Last() && outerNumber != returnItem.Last())
                                {
                                    innerString += innerNumber + "], ";
                                }
                                else if (innerNumber == outerNumber.Last() && outerNumber == returnItem.Last())
                                {
                                    innerString += innerNumber + "]";
                                }
                                else
                                {
                                    innerString += innerNumber + ", ";
                                }
                            }
                            if (outerNumber == returnItem.Last())
                            {
                                returnString += innerString + "]";
                            }
                            else
                            {
                                returnString += innerString;
                            }
                        }
                        Console.WriteLine("Contiguous number list: " + returnString);
                    }
                } catch
                {
                    Console.Write("\nYou entered something incorrect.");
                    Console.Write("\nPress escape key to exit or Any other key to continue...");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        escape = true;
                    }
                }
                Console.Write("\nPress escape key to exit or Any other key to start again...");
                if(Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    escape = true;
                }

            }

        }

        public static int[][] GetContiguousNumbers(int[] numberArray)
        {
            try
            {
                int[][] contiguousArray;
                var innerList = new List<int>();
                var outerList = new List<List<int>>();
                for (int i = 0; i < numberArray.Length; i++)
                {
                    if (!innerList.Any())
                    {
                        innerList.Add(numberArray[i]);
                    }
                    int numValue = 0;
                    if (!(numberArray[i] == numberArray.Last()))
                    {
                        numValue = numberArray[i + 1] - numberArray[i];
                        if (numberArray[i + 1] < numberArray[i])
                        {
                            throw new Exception("List is not in ascending order");
                        }
                    }
                    if (numValue == 1)
                    {
                        innerList.Add(numberArray[i + 1]);
                    }
                    else
                    {
                        outerList.Add(new List<int>(innerList));
                        innerList.Clear();
                    }
                }
                contiguousArray = outerList.Select(x => x.ToArray()).ToArray();
                return contiguousArray;
            }
            catch
            {
                Console.WriteLine("List isn't in ascending order!");
                return new int[][] { };
            }

        }
    }
}
