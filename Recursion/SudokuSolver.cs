static void SolveSudoku(char[][] board)
{
    solveSudoku(board);
}

static bool solveSudoku(char[][] board)
{
    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            if (board[i][j] == '.')
            {
                for (char num = '1'; num <= '9'; num++)
                {
                    if (canIPlace(board, i, j, num))
                    {
                        board[i][j] = num;
                        if (solveSudoku(board))
                        {
                            return true;
                        }
                        else
                        {
                            board[i][j] = '.';
                        }
                    }
                }
                return false;
            }
        }
    }
    return true;
}

static bool canIPlace(char[][] board, int row, int col, char num)
{
    for (int i = 0; i < 9; i++)
    {
        if (board[i][col] == num || board[row][i] == num)
        {
            return false;
        }
    }
    int startRow = (row / 3) * 3;
    int startCol = (col / 3) * 3;
    for (int i = startRow; i < startRow + 3; i++)
    {
        for (int j = startCol; j < startCol + 3; j++)
        {
            if (board[i][j] == num)
            {
                return false;
            }
        }
    }
    return true;
}
char[][] board = new char[9][]
{
    new char[]{'5','3','.','.','7','.','.','.','.'},
    new char[]{'6','.','.','1','9','5','.','.','.'},
    new char[]{'.','9','8','.','.','.','.','6','.'},
    new char[]{'8','.','.','.','6','.','.','.','3'},
    new char[]{'4','.','.','8','.','3','.','.','1'},
    new char[]{'7','.','.','.','2','.','.','.','6'},
    new char[]{'.','6','.','.','.','.','2','8','.'},
    new char[]{'.','.','.','4','1','9','.','.','5'},
    new char[]{'.','.','.','.','8','.','.','7','9'}
};
SolveSudoku(board);
for (int i = 0; i < 9; i++)
{
    for (int j = 0; j < 9; j++)
    {
        Console.Write(board[i][j] + " ");
    }
    Console.WriteLine();
}
Console.ReadLine();