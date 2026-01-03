public class Facebook
{
    private Dictionary<string, Dictionary<string, int>> adjList;
    public Facebook()
    {
        adjList = new Dictionary<string, Dictionary<string, int>>();
    }
    public int SignUp(string userName)
    {
        if (adjList.ContainsKey(userName))
        {
            return -1;
        }
        adjList[userName] = new Dictionary<string, int>();
        return 0;
    }
    public int AddFriend(string firstUserName, string secondUserName,int weight)
    {
        if (!adjList.ContainsKey(firstUserName)|| !adjList.ContainsKey(secondUserName))
        {
            return -1;
        }
        adjList[firstUserName][secondUserName]= weight;
        adjList[secondUserName][firstUserName]=weight;
        return 0;
    }
    public int RemoveFriend(string firstUserName,string secondUserName)
    {
        if (!adjList.ContainsKey(firstUserName) || !adjList.ContainsKey(secondUserName))
        {
            return -1;
        }
        adjList[firstUserName].Remove(secondUserName);
        adjList[secondUserName].Remove(firstUserName);
        return 0;
    }
    public int DeleteAccount(string userName)
    {
        if (!adjList.ContainsKey(userName))
        {
            return -1;
        }
        adjList.Remove(userName);
        foreach (var user in adjList.Keys)
        {
            if (adjList[user].ContainsKey(userName))
            {
                adjList[user].Remove(userName);
            }
        }
        return 0;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Facebook facebook = new Facebook();
        facebook.SignUp("Alice");
        facebook.SignUp("Bob");
        facebook.AddFriend("Alice", "Bob", 5);
        facebook.RemoveFriend("Alice", "Bob");
        facebook.DeleteAccount("Alice");
        Console.ReadLine();
    }
}