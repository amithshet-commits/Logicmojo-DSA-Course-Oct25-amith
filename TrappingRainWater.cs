//Trapping Rain Water problem solved using the two-pointer technique in C#
//TC: O(n) and SC: O(1)
static int Trap(int[] height)
{
    int l = 0; int r = height.Length - 1;
    int maxL = height[l]; int maxR = height[r];
    int trappedWater = 0;
    while (l < r)
    {
        if (maxL < maxR)
        {
            l++;
            maxL = Math.Max(maxL, height[l]);
            trappedWater += maxL - height[l];
        }
        else
        {
            r--;
            maxR = Math.Max(maxR, height[r]);
            trappedWater += maxR - height[r];
        }
    }
    return trappedWater;
}
int[] height = { 0, 2, 0, 3, 1, 0, 1, 3, 2, 1 };
int trappedWater = Trap(height);
Console.ReadLine();

//Intuition
//To trap water at a position i, you need:
//water_at_i = min(max_left, max_right) - height[i]
//max_left → tallest bar on the left of i
//max_right → tallest bar on the right of i
//Water can only exist if both sides have taller boundaries.

//Example Walkthrough
//Let’s dry-run for clarity.
//Input: [4,2,0,3,2,5]
//Step	l	r	maxL	maxR	Water Added	Total
//Init	0	5	4	5	0	0
//1	1	5	4	5	4-2 = 2	2
//2	2	5	4	5	4-0 = 4	6
//3	3	5	4	5	4-3 = 1	7
//4	4	5	4	5	4-2 = 2	9
//5	5	5	—	—	stop	9
//✅ Total trapped water = 9 units