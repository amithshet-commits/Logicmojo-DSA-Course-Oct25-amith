public class Solution
{
    //brute force approach
    //public bool CanFinish(int numCourses, int[][] prerequisites)
    //{
    //    List<List<int>> adj = new List<List<int>>();

    //    for (int i = 0; i < numCourses; i++)
    //        adj.Add(new List<int>());

    //    foreach (var p in prerequisites)
    //        adj[p[1]].Add(p[0]);

    //    for (int i = 0; i < numCourses; i++)
    //    {
    //        bool[] path = new bool[numCourses];
    //        if (HasCycle(i, adj, path))
    //            return false;
    //    }

    //    return true;
    //}
    //public bool HasCycle(int course, List<List<int>> adj, bool[] path)
    //{
    //    if (path[course])
    //        return true;

    //    path[course] = true;

    //    foreach (var neighbor in adj[course])
    //    {
    //        if (HasCycle(neighbor, adj, path))
    //            return true;
    //    }
    //    path[course] = false;
    //    return false;
    //}

    //topological sort or Kahn's algorithm 
    static bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<List<int>> adj = new List<List<int>>();
        int[] indegree = new int[numCourses];
        List<int> ans = new List<int>();

        for (int i = 0; i < numCourses; i++)
            adj.Add(new List<int>());

        foreach (var pair in prerequisites)
        {
            int course = pair[0];
            int coursePrerequisite = pair[1];

            adj[coursePrerequisite].Add(course);
            indegree[course]++;
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (indegree[i] == 0)
                queue.Enqueue(i);
        }

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            ans.Add(current);

            if (adj[current] != null)
            {
                foreach (var neighbor in adj[current])
                {
                    indegree[neighbor]--;
                    if (indegree[neighbor] == 0)
                        queue.Enqueue(neighbor);
                }
            }
        }

        return ans.Count == numCourses;
    }
}