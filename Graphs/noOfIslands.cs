public class Solution
{
    public int NumIslands(char[][] grid)
    {
        int row = grid.Length;
        int col = grid[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int[][] directions = new int[][] {
            new int[]{1,0},
            new int[]{-1,0},
            new int[]{0,1},
            new int[]{0,-1}
        };
        int noOfIslands = 0;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (grid[i][j] == '1')
                {
                    queue.Enqueue((i, j));
                    grid[i][j] = '0';
                    while (queue.Count > 0)
                    {
                        var (r, c) = queue.Dequeue();
                        foreach (var dir in directions)
                        {
                            int nr = r + dir[0];
                            int nc = c + dir[1];
                            if (nr >= 0 && nc >= 0 && nr < row && nc < col && grid[nr][nc] == '1')
                            {
                                queue.Enqueue((nr, nc));
                                grid[nr][nc] = '0';
                            }
                        }
                    }
                    noOfIslands++;
                }
            }
        }
        return noOfIslands;
    }
}
