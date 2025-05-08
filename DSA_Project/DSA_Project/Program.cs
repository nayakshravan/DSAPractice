using DSA_Project;
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 15, 3, -1, 40, 25, 11 };
        Random rand = new Random();
        //int[] numbers = Enumerable.Range(1, 150000).OrderBy(x => rand.Next()).ToArray();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        //BubbleSort(numbers);
        QuickSort(numbers,0, numbers.Length-1);
        //MergeSort(numbers, 0, numbers.Length - 1);
        int target = 11;
        int elementIndex = BinarySearch(numbers, target);
        stopwatch.Stop();

        Console.WriteLine("Elapsed time: "+stopwatch.ElapsedMilliseconds+ " ms");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        if (elementIndex != -1)
        {
            Console.WriteLine("Element "+target+" found at index : " + elementIndex);
        }
        else
        {
            Console.WriteLine("Element " + target + " not found!");
        }

        BinaryTree tree = new BinaryTree();

        // Insert nodes into the tree
        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(70);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(60);
        tree.Insert(80);

        Console.WriteLine("In-order traversal of the binary tree:");
        tree.InOrderTraversal(tree.Root);
    }

    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
        }
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right);
            QuickSort(arr, left, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, right);
        }
    }

    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right]; // choosing the last element as pivot
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
        (arr[i + 1], arr[right]) = (arr[right], arr[i + 1]);
        return i + 1;
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int[] leftArr = new int[mid - left + 1];
        int[] rightArr = new int[right - mid];

        Array.Copy(arr, left, leftArr, 0, leftArr.Length);
        Array.Copy(arr, mid + 1, rightArr, 0, rightArr.Length);

        int i = 0, j = 0, k = left;
        while (i < leftArr.Length && j < rightArr.Length)
        {
            if (leftArr[i] <= rightArr[j])
                arr[k++] = leftArr[i++];
            else
                arr[k++] = rightArr[j++];
        }

        while (i < leftArr.Length)
            arr[k++] = leftArr[i++];
        while (j < rightArr.Length)
            arr[k++] = rightArr[j++];
    }

    static int BinarySearch(int[] arr, int target)
    {
        if (arr.Length == 0)
        {
            return -1;
        }

        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                return mid;
            }
            if (target < arr[mid])
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return -1;
    }
}