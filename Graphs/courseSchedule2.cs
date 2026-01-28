using System;

class GfG
{

    static int[] CanFinish(int numCourses, int[][] prerequisites)
    {
        List<List<int>> adj = new List<List<int>>();
        List<int> ans = new List<int>();
        int[] indegree = new int[numCourses];

        for (int i = 0; i < numCourses; i++)
            adj.Add(new List<int>());

        foreach (var pair in prerequisites)
        {
            int course = pair[0];
            int preCourse = pair[1];

            adj[preCourse].Add(course);
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

        if (ans.Count != numCourses)
            return new int[0];

        return ans.ToArray();
    }


    static void Main()
    {
        int[][] prerequisites = new int[][]
{
    new int[] {1, 0},
    new int[] {1, 2},
    new int[] {0, 1}
};
        int[] result = CanFinish(3, prerequisites);
        Console.ReadLine();
    }
}