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
     * Complete the 'twoArrays' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY A
     *  3. INTEGER_ARRAY B
     */

    public static string twoArrays(int k, List<int> A, List<int> B)
    {
        int n = A.Count;

        // Sort A ascending
        MergeSort(A, 0, n - 1, true);

        // Sort B descending
        MergeSort(B, 0, n - 1, false);

        // Check condition
        for (int i = 0; i < n; i++)
        {
            if (A[i] + B[i] < k)
                return "NO";
        }

        return "YES";
    }
    static void MergeSort(List<int> arr, int left, int right, bool ascending)
    {
        if (left >= right) return;

        int mid = left + (right - left) / 2;

        MergeSort(arr, left, mid, ascending);
        MergeSort(arr, mid + 1, right, ascending);
        Merge(arr, left, mid, right, ascending);
    }
    static void Merge(List<int> arr, int left, int mid, int right, bool ascending)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];

        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int i1 = 0, i2 = 0, k = left;

        while (i1 < n1 && i2 < n2)
        {
            if (ascending)
            {
                if (L[i1] <= R[i2])
                    arr[k++] = L[i1++];
                else
                    arr[k++] = R[i2++];
            }
            else
            {
                if (L[i1] >= R[i2])
                    arr[k++] = L[i1++];
                else
                    arr[k++] = R[i2++];
            }
        }

        while (i1 < n1) arr[k++] = L[i1++];
        while (i2 < n2) arr[k++] = R[i2++];
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

            List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

            string result = Result.twoArrays(k, A, B);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
