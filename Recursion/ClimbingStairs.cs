public class Solution
{
    public int ClimbStairs(int n)
    {
        return Helper(0, n);
    }

    public int Helper(int i, int n)
    {
        if (i > n)
        {
            return 0;
        }
        if (i == n)
        {
            return 1;
        }
        int oneStep = Helper(i + 1, n);
        int twoStep = Helper(i + 2, n);
        return oneStep + twoStep;
    }
}