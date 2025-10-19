//Brute force approach using two nested loops and determining the maximum area
//TC: O(n^2) and SC: O(1)
//static int MaxArea(int[] height)
//{
//    int maxArea = 0;
//    for (int i = 0; i < height.Length; i++)
//    {
//        for (int j=i+1;j<height.Length;j++)
//        {
//            maxArea = Math.Max(maxArea, Math.Min(height[i], height[j]) * (j - i));
//        }
//    }
//    return maxArea;
//}
//Two pointer approach
// TC: O(n) and SC: O(1)
static int MaxArea(int[] height)
{
    int maxArea = 0;
    int i = 0; int j = height.Length - 1;
    while (i < j)
    {
        maxArea = Math.Max(maxArea, Math.Min(height[i], height[j]) * (j - i));
        if (height[i] < height[j])
        {
            i++;
        }
        else if (height[i] > height[j])
        {
            j--;
        }
        else
        {
            i++;
            j--;
        }
    }
    return maxArea;
}

int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
int maxArea = MaxArea(height);
Console.ReadLine();