public class Solution
{
    public int ReversePairs(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;
        return MergeSort(nums, 0, nums.Length - 1);
    }
    private int MergeSort(int[] nums, int left, int right)
    {
        if (left >= right) return 0;
        int mid = left + (right - left) / 2;
        int count = 0;
        count += MergeSort(nums, left, mid);
        count += MergeSort(nums, mid + 1, right);
        count += CountPairs(nums, left, mid, right);
        Merge(nums, left, mid, right);
        return count;
    }
    private int CountPairs(int[] nums, int left, int mid, int right)
    {
        int count = 0;
        int j = mid + 1;
        for (int i = left; i <= mid; i++)
        {
            while (j <= right && (long)nums[i] > 2L * nums[j])
            {
                j++;
            }
            count += (j - (mid + 1));
        }
        return count;
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