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
    //Code walkthrough:
    //Find the first decreasing index i (right-to-left scan).
    //Find the just larger element j (right-to-left scan).
    //Swap elements at i and j.
    //TC: O(n) SC: O(n)
    public static int nge_func(int n)
    {
        char[] digits = n.ToString().ToCharArray();
        int i;
        //first determine the first decreasing digit from right
        for (i = digits.Length - 2; i >= 0; i--)
        {
            if (digits[i] < digits[i + 1])
            {
                break;
            }
        }
        // If no such element found, return -1
        if (i == -1)
        {
            return -1;
        }
        int j;
        for (j = digits.Length - 1; j >= i; j--)
        {
            if (digits[j] > digits[i])
            {
                break;
            }
        }
        //Swap the digits.
        char temp = digits[i];
        digits[i] = digits[j];
        digits[j] = temp;
        //Reverse the digits to the right of i
        Array.Reverse(digits, i + 1, digits.Length - 1 - i);
        int result = int.Parse(new string(digits));
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.nge_func(n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
