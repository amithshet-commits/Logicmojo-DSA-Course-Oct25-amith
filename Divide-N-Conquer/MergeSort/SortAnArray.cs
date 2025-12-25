public class Solution
{
    public int[] SortArray(int[] nums)
    {
        if (nums.Length == 0)
        {
            return Array.Empty<int>();
        }
        Sort(nums, 0, nums.Length - 1);
        return nums;
    }
    private void Sort(int[] nums, int l, int r)
    {
        if (l < r)
        {
            int m = l + (r - l) / 2;
            Sort(nums, l, m);
            Sort(nums, m + 1, r);
            Merge(nums, l, m, r);
        }
    }
    private void Merge(int[] nums, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;

        int[] L = new int[n1];
        int[] R = new int[n2];

        int i = 0, j = 0;
        for (i = 0; i < n1; i++)
            L[i] = nums[l + i];

        for (j = 0; j < n2; j++)
            R[j] = nums[m + 1 + j];

        i = 0; j = 0; int k = l;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                nums[k] = L[i];
                i++;
            }
            else
            {
                nums[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            nums[k] = L[i];
            k++;
            i++;
        }

        while (j < n2)
        {
            nums[k] = R[j];
            k++;
            j++;
        }
    }
}