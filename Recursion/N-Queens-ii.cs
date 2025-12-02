public class Solution
{
    public int TotalNQueens(int n)
    {
        int[] board = new int[n];
        List<List<string>> result = new List<List<string>>();
        Helper(board, result, 0, n);
        return result.Count;
    }

    public void Helper(int[] board, List<List<string>> result, int row, int n)
    {
        if (row == n)
        {
            result.Add(GenerateQueenResult(board, n));
        }
        for (int col = 0; col < n; col++)
        {
            if (canIPlace(row, col, board, n))
            {
                board[row] = col;
                Helper(board, result, row + 1, n);
            }
        }
    }

    public bool canIPlace(int row, int col, int[] board, int n)
    {
        //straight check
        for (int i = 0; i < row; i++)
        {
            if (board[i] == col)
            {
                return false;
            }
        }
        //upper left diagonal
        int temp = 1;
        for (int i = row - 1; i >= 0; i--)
        {
            if (col - temp < 0)
            {
                break;
            }
            if (board[i] == col - temp)
            {
                return false;
            }
            temp++;
        }
        //upper right diagonal
        temp = 1;
        for (int i = row - 1; i >= 0; i--)
        {
            if (col + temp > n)
            {
                break;
            }
            if (board[i] == col + temp)
            {
                return false;
            }
            temp++;
        }
        return true;
    }

    public List<string> GenerateQueenResult(int[] board, int n)
    {
        List<string> s = new List<string>();
        char[] arr = new char[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = '.';
        }
        for (int i = 0; i < n; i++)
        {
            arr[board[i]] = 'Q';
        }
        s.Add(arr.ToString());
        return s;
    }
}