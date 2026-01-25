using System;

class GfG
{

    // Function to perform the Bellman-Ford algorithm
    static int[] bellmanFord(int V, int[,] edges, int src)
    {

        // Initialize distances from source to all
        // vertices as "infinity" (represented by 1e8)
        int[] dist = new int[V];
        for (int i = 0; i < V; i++)
            dist[i] = int.MaxValue;

        // Distance to the source is always 0
        dist[src] = 0;

        // Get the number of edges from the 2D edge array
        int E = edges.GetLength(0);

        // Relax all edges V times
        // The extra iteration (V-th) is used to detect a 
        // negative weight cycle
        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < E; j++)
            {

                // Extract edge info: from u to v with weight wt
                int u = edges[j, 0];
                int v = edges[j, 1];
                int wt = edges[j, 2];

                // Only proceed if u has already been reached 
                // (i.e., not infinity)
                if (dist[u] != int.MaxValue && dist[u] + wt < dist[v])
                {

                    // If this is the V-th iteration and relaxation is still
                    // possible, it means there is a negative weight cycle
                    if (i == V - 1)
                        // Indicate presence of negative cycle
                        return new int[] { -1 };

                    // Update the distance to vertex v through vertex u
                    dist[v] = dist[u] + wt;
                }
            }
        }

        // Return the final shortest distances
        return dist;
    }

    static void Main()
    {

        // Number of vertices in the graph
        int V = 5;

        // Edge list: each row represents {source, destination, weight}
        int[,] edges = {
            { 1, 3, 2 },
            { 4, 3, -1 },
            { 2, 4, 1 },
            { 1, 2, 1 },
            { 0, 1, 5 }
        };

        // Source vertex
        int src = 0;

        // Call Bellman-Ford and store the result
        int[] ans = bellmanFord(V, edges, src);

        // Print the shortest distances from source to all vertices
        foreach (int d in ans)
            Console.Write(d + " ");
    }
}
//https://www.geeksforgeeks.org/dsa/bellman-ford-algorithm-dp-23/