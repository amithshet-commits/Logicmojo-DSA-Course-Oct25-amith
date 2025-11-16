static void Rotate(int[][] matrix)
{
    int edgeLength = matrix.Length;

    int top = 0;
    int bottom = edgeLength - 1;

    // Swap top and bottom rows
    while (top < bottom)
    {
        for (int col = 0; col < edgeLength; col++)
        {
            int temp = matrix[top][col];
            matrix[top][col] = matrix[bottom][col];
            matrix[bottom][col] = temp;
        }
        top++;
        bottom--;
    }

    // Transpose the matrix
    for (int row = 0; row < edgeLength; row++)
    {
        for (int col = row + 1; col < edgeLength; col++)
        {
            int temp = matrix[row][col];
            matrix[row][col] = matrix[col][row];
            matrix[col][row] = temp;
        }
    }
}
int[][] matrix = new int[][]
{
    new int[]{1,2,3},
    new int[]{4,5,6},
    new int[]{7,8,9}
};
Rotate(matrix);
Console.ReadLine();