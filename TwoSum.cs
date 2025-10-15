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
     * Complete the 'two_sum' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY arr
     *  2. INTEGER target
     */
    // Hashing Approach (if the array is not sorted)
    public static List<int> two_sum(List<int> arr, int target)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        for (int i = 0; i < arr.Count; i++)
        {
            int remainder = target - arr[i];
            if (dictionary.ContainsKey(remainder))
            {
                return new List<int> { dictionary[remainder], i };
            }

            dictionary[arr[i]] = i;

        }
        return new List<int>();
    }
    // Two Pointer Approach (only works if the array is sorted)
    public static int[] TwoSum_TwoPointer(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int sum = nums[left] + nums[right];

            if (sum == target)
                return new int[] { left, right };
            else if (sum < target)
                left++; // move right to get a bigger sum
            else
                right--; // move left to get a smaller sum
        }

        return Array.Empty<int>(); // no valid pair
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int target = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.two_sum(arr, target);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}