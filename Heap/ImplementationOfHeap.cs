public class HeapNode
{
    public int Num;
    public int Priority;

    public HeapNode(int num, int priority)
    {
        Num = num;
        Priority = priority;
    }
}
public class MaxHeap
{
    private List<HeapNode> arr = new List<HeapNode>();

    public void Add(HeapNode item)
    {
        arr.Add(item);
        int curr = arr.Count - 1;
        while (curr > 0)
        {
            int parent = (curr - 1) / 2;
            if (arr[curr].Priority <= arr[parent].Priority)
                break;

            Swap(curr, parent);
            curr = parent;
        }
    }
    public HeapNode Remove()
    {
        HeapNode root = arr[0];
        arr[0] = arr[arr.Count - 1];
        arr.RemoveAt(arr.Count - 1);

        int parent = 0;
        while (true)
        {
            int left = 2 * parent + 1;
            int right = 2 * parent + 2;
            int largest = parent;

            if (left < arr.Count && arr[left].Priority >= arr[parent].Priority)
                largest = left;

            if (right < arr.Count && arr[right].Priority >= arr[parent].Priority)
                largest = right;

            if (largest == parent)
                break;

            Swap(parent, largest);
            parent = largest;
        }
        return root;
    }
    public HeapNode Peek()
    {
        return arr[0];
    }
    private void Swap(int i, int j)
    {
        HeapNode temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        MaxHeap maxHeap = new MaxHeap();
        maxHeap.Add(new HeapNode(1, 10));
        maxHeap.Add(new HeapNode(2, 20));
        maxHeap.Add(new HeapNode(3, 15));

        HeapNode root = maxHeap.Remove(); // Removes node with priority 20
    }
}