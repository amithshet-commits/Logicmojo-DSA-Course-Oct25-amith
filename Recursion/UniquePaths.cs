static int UniquePaths(int m, int n)
{
    return helperUniquePaths(0, 0, m, n);
}
static int helperUniquePaths(int r, int d, int m, int n)
{
    if (r == m - 1 || d == n - 1)
    {
        return 1;
    }
    if (r >= m || d >= n)
    {
        return 0;
    }
    int right = helperUniquePaths(r + 1, d, m, n);
    int down = helperUniquePaths(r, d + 1, m, n);
    return right + down;
}