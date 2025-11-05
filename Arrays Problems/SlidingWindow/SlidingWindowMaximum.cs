//Brute Force Approach
//fix window start, scan k items, record max. move one step right. repeat.
//TC O((n-k)*k) SC O(1)
public int[] MaxSlidingWindow(int[] nums, int k)
{
    int[] output = new int[nums.Length - k + 1];
    int max = int.MinValue;
    for (int i=0;i<=nums.Length-k;i++)
    {
        for(int j=i;j<i+k;j++){
            max=Math.Max(max,nums[j]);
        }
        output[i]=max;
    }
}
//Using monotonic deque
//TC O(N) SC O(K)
//Intuition:
//We can use a deque to store indices of useful elements for each window of size k.
//An element is considered useful if it can be the maximum in the current or future windows.
//Maintain a monotonic decreasing deque (by values). While the last element in deque has value less than nums[r], remove it from the back.
//Why? Because if nums[r] is larger, any smaller values behind it can never become the max while nums[r] is inside the window — they are useless and can be discarded.
//if (l > deque.First.Value) { deque.RemoveFirst(); }
//Remove expired indices from the front. If the index at the front is left of the current window (deque.First.Value < l), it’s no longer in the window — drop it. Note the code checks l > deque.First.Value (equivalent to deque.First.Value < l)
//deque.AddLast(r);
//Add the current index r to the back. After the previous loop, everything behind it has value ≥ nums[r], so deque remains decreasing.
//if (l > deque.First.Value) { deque.RemoveFirst(); }
//Remove expired indices from the front. If the index at the front is left of the current window (deque.First.Value < l), it’s no longer in the window — drop it. Note the code checks l > deque.First.Value (equivalent to deque.First.Value < l).
//if (r + 1 >= k)
//Only once we've seen at least k elements (i.e., the window size has become k) do we start producing outputs. r + 1 is the current window size if we were to start at l=0. Since l is advanced with each produced output, this condition effectively ensures the first output is produced when the first full window finishes (at r = k-1).
//output[l] = nums[deque.First.Value]; l++;
//The maximum for the current window is at the front of the deque (largest value, since deque is decreasing). Store it in output at index l (we use l as the output index), then move l forward: window slides right by one.
//r++;
//Expand/move the right pointer to the next element (next iteration).
//return output;deque.AddLast(r);
//Add the current index r to the back. After the previous loop, everything behind it has value ≥ nums[r], so deque remains decreasing.
//if (l > deque.First.Value) { deque.RemoveFirst(); }
//Remove expired indices from the front. If the index at the front is left of the current window (deque.First.Value < l), it’s no longer in the window — drop it. Note the code checks l > deque.First.Value (equivalent to deque.First.Value < l).
//if (r + 1 >= k)
//Only once we've seen at least k elements (i.e., the window size has become k) do we start producing outputs. r + 1 is the current window size if we were to start at l=0. Since l is advanced with each produced output, this condition effectively ensures the first output is produced when the first full window finishes (at r = k-1).
//output[l] = nums[deque.First.Value]; l++;
//The maximum for the current window is at the front of the deque (largest value, since deque is decreasing). Store it in output at index l (we use l as the output index), then move l forward: window slides right by one.
//r++;
//Expand/move the right pointer to the next element (next iteration).
//return output;
static int[] MaxSlidingWindow(int[] nums, int k)
{
    int n = nums.Length;
    int[] output = new int[n - k + 1];
    int l = 0; int r = 0;
    LinkedList<int> deque = new LinkedList<int>();
    while (r < n)
    {
        while (deque.Count > 0 && nums[deque.Last.Value] < nums[r])
        {
            deque.RemoveLast();
        }
        deque.AddLast(r);
        if (l > deque.First.Value)
        {
            deque.RemoveFirst();
        }
        if (r + 1 >= k)
        {
            output[l] = nums[deque.First.Value];
            l++;
        }
        r++;
    }
    return output;
}
int[] nums = { 1, 2, 1, 0, 4, 2, 6 }; int k = 3;
int[] output = MaxSlidingWindow(nums, 3);
Console.ReadLine();