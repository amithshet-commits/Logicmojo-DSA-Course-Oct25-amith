public class Solution
{
    public int NumDecodings(string s)
    {
        int[] memo = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
            memo[i] = -1;
        return dfs(0, s, memo);
    }
    private int dfs(int i, string s, int[] memo)
    {
        if (i == s.Length) return 1;
        if (s[i] == '0') return 0;
        if (memo[i] != -1) return memo[i];

        int ways = dfs(i + 1, s, memo);

        if (i + 1 < s.Length)
        {
            int num = (s[i] - '0') * 10 + (s[i + 1] - '0');
            if (num >= 10 && num <= 26)
            {
                ways += dfs(i + 2, s, memo);
            }
        }

        memo[i] = ways;
        return ways;
    }
}