using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'subsetSum' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY nums
     *  2. INTEGER n
     */

    public static List<int> subsetSum(List<int> nums, int n)
    {
        List<int> result = new List<int>();
        nums.Sort();
        helper(nums, 0, 0, result);
        result.Sort();
        return result;
    }

    private static void helper(List<int> nums, int index, int currSum, List<int> result)
    {
        if (index == nums.Count)
        {
            result.Add(currSum);
            return;
        }
        helper(nums, index + 1, currSum + nums[index], result);
        helper(nums, index + 1, currSum, result);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> subsetSumArray = Result.subsetSum(arr, n);

        textWriter.WriteLine(String.Join(" ", subsetSumArray));

        textWriter.Flush();
        textWriter.Close();
    }
}
