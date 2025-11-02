public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        int[] count = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            count[s[i] - 'a']++;
            count[t[i] - 'a']--;
        }

        foreach (int val in count)
        {
            if (val != 0)
            {
                return false;
            }
        }
        return true;
    }

    public List<List<string>> GroupAnagrams(string[] strs)
    {
        var res = new Dictionary<string, List<string>>();
        foreach (var s in strs)
        {
            int[] count = new int[26];
            foreach (char c in s)
            {
                count[c - 'a']++;
            }
            string key = string.Join(",", count);
            if (!res.ContainsKey(key))
            {
                res[key] = new List<string>();
            }
            res[key].Add(s);
        }
        return res.Values.ToList<List<string>>();
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        foreach (var word in strs)
        {
            // sort characters to create the leaderKey
            char[] chars = word.ToCharArray();
            Array.Sort(chars);
            string leaderKey = new string(chars);

            if (!map.ContainsKey(leaderKey))
            {
                map[leaderKey] = new List<string>();
            }

            map[leaderKey].Add(word);
        }

        return map.Values.ToList<IList<string>>();
    }
}