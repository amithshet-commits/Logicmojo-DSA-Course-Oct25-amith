public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        List<IList<string>> ans = new List<IList<string>>();
        int[] board = new int[n];
        HelperPlaceQueen(0, n, board, ans);
        return ans;
    }
    public static void HelperPlaceQueen(int row, int n, int[] board, IList<IList<string>> ans)
    {
        if (row == n)
        {
            ans.Add(GenerateQueenResult(board, n));
        }

        for (int col = 0; col < n; col++)
        {
            if (canIPlace(row, col, board, n))
            {
                board[row] = col;
                HelperPlaceQueen(row + 1, n, board, ans);
            }
        }
    }
    public static bool canIPlace(int row, int col, int[] board, int n)
    {
        //check for same column
        for (int i = 0; i < row; i++)
        {
            if (board[i] == col)
            { //Q already placed
                return false;
            }
        }

        //check for left upper diagonal
        int temp = 1;
        for (int i = row - 1; i >= 0; i--)
        {
            if (col - temp < 0)
            {
                break;
            }
            if (board[i] == col - temp)
            {//Q already placed
                return false;
            }
            temp++;
        }

        //check for right upper diagonal
        temp = 1;
        for (int i = row - 1; i >= 0; i--)
        {
            if (col + temp >= n)
            {
                break;
            }
            if (board[i] == col + temp)
            {//Q already placed
                return false;
            }
            temp++;
        }
        return true;
    }

    public static IList<string> GenerateQueenResult(int[] board, int n)
    {
        List<string> gen = new List<string>();
        for (int i = 0; i < n; i++)
        {
            char[] arr = new string('.', n).ToCharArray();
            arr[board[i]] = 'Q';
            gen.Add(new string(arr));
        }
        return gen;
    }
}