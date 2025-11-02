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
     * Complete the 'singlelement' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr
     */
    //Explanation: In a sorted array where every element appears twice except for one,
    //we can use a binary search approach to efficiently find the single element.
    //The key observation is that pairs of identical elements will always start at even indices.
    //If we find that the middle index is even and the next element is the same,
    //it means the single element must be in the right half of the array.
    //Conversely, if the middle index is odd and the previous element is the same,
    //the single element must be in the left half. By adjusting our search boundaries
    //based on these observations, we can narrow down to the single element in O(log n) time.
    public static int singlelement(int n, List<int> arr)
    {
        int left = 0;
        int right = arr.Count - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (mid % 2 == 1)
            {
                mid--;
            }
            if (arr[mid] == arr[mid + 1])
            {
                left = mid + 2;
            }
            else
            {
                right = mid;
            }
        }
        return arr[left];
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.singlelement(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
