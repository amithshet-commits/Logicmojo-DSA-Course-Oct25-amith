//TC O(N*M) SC O(1)
public string LongestCommonPrefix(string[] strs)
{
    string queryStr = strs[0];
    string result = "";
    int minLength = strs.Min(s => s.Length);
    for (int i = 0; i < minLength; i++)
    {
        bool flag = true;
        for (int j = 1; j < strs.Length; j++)
        {
            if (strs[j][i] != queryStr[i])
            {
                flag = false;
                break;
            }
        }
        if (!flag)
            break;
        result += queryStr[i];
    }
    return result;
}
//TC O(N log N) SC O(1)
public string LongestCommonPrefix(string[] strs)
{
    Array.Sort(strs);
    string result = "";
    for (int i = 0; i < strs[0].Length; i++)
    {
        if (strs[0][i] != strs[strs.Length - 1][i])
        {
            return result;
        }
        result += strs[0][i];
    }
    return result;
}
string[] strs = new string[] { "flower", "flow", "flight" };
string result = LongestCommonPrefix(strs);
Console.ReadLine();
