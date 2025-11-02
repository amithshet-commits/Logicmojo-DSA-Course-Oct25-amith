static IList<int> SpiralOrder(int[][] matrix)
{
    int top = 0;
    int left = 0;
    int right = matrix[0].Length - 1;
    int bottom = matrix.Length - 1;
    IList<int> result = new List<int>();
    while (top <= bottom && left <= right)
    {
        for (int i = top; i <= right; i++)
        {
            result.Add(matrix[top][i]);
        }
        top++;
        for (int j = top; j <= bottom; j++)
        {
            result.Add(matrix[j][right]);
        }
        right--;
        if (top <= bottom)
        {
            for (int k = right; k >= left; k--)
            {
                result.Add(matrix[bottom][k]);
            }
            bottom--;
        }
        if (left <= right)
        {
            for (int i = bottom; i >= top; i--)
            {
                result.Add(matrix[i][left]);
            }
            left++;
        }
    }
    return result;
}
int[][] matrix = new int[][]
{
    new int[]{1,2,3},
    new int[]{4,5,6},
    new int[]{7,8,9}
};
IList<int> result = SpiralOrder(matrix);
Console.ReadLine();