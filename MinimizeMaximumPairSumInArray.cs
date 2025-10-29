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
//Minimize Maximum Pair Sum in Array
//Intuition:
//To minimize the maximum pair sum, we can sort the array and pair the smallest
//and largest elements together. This way, we balance out the sums of the pairs,
//ensuring that no single pair sum becomes excessively large.
//To achieve this, first we sort and then we can use a two-pointer technique to form min maximum pair.
//TC: O(n log n) due to sorting, SC: O(1)
class Result
{

    /*
     * Complete the 'minPairSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr
     */

    public static int minPairSum(int n, List<int> arr)
    {
        int l = 0; int r = arr.Count - 1; int max = 0;
        arr.Sort();
        while (l < r)
        {
            if (max < Math.Max((arr[l] + arr[r]), max))
            {
                max = arr[l] + arr[r];
            }
            l++; r--;
        }
        return max;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.minPairSum(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
