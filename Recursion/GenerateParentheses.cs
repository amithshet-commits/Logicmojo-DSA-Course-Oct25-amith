public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> result = new List<string>();
        helper(n, 0, 0, "", result);
        return result;
    }
    public void helper(int n, int close, int open, string s, List<string> result)
    {
        if (close + open == 2 * n)
        {
            result.Add(s);
        }
        if (open < n)
        {
            helper(n, close, open + 1, s + "(", result);
        }
        if (close < open)
        {
            helper(n, close + 1, open, s + ")", result);
        }
    }
}