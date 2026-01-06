public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        int row = grid.Length;
        int col = grid[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int freshOranges = 0;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (grid[i][j] == 2)
                {
                    queue.Enqueue((i, j));
                }
                else if (grid[i][j] == 1)
                {
                    freshOranges++;
                }
            }
        }
        int minutes = 0;
        if (freshOranges == 0) return 0;
        int[][] dirs = new int[][]
        {
            new int[]{1,0},
            new int[]{-1,0},
            new int[]{0,1},
            new int[]{0,-1}
        };
        while (queue.Count > 0)
        {
            int size = queue.Count;
            bool rotted = false;
            for (int i = 0; i < size; i++)
            {
                var (r, c) = queue.Dequeue();
                foreach (var d in dirs)
                {
                    int nr = r + d[0];
                    int nc = c + d[1];
                    if (nr >= 0 && nc >= 0 && nr < row && nc < col && grid[nr][nc] == 1)
                    {
                        grid[nr][nc] = 2;
                        freshOranges--;
                        queue.Enqueue((nr, nc));
                        rotted = true;
                    }
                }
            }
            if (rotted) minutes++;
        }
        if (freshOranges == 0) return minutes;
        else return -1;
    }
}
