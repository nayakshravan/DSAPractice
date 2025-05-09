using DSA_Project;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 15, 3, -1, 40, 25, 11 };
        Random rand = new Random();
        //int[] numbers = Enumerable.Range(1, 150000).OrderBy(x => rand.Next()).ToArray();
        Stopwatch stopwatch = new Stopwatch();

        #region Sorting and Search algorithm calls
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
        #endregion

        #region Binary tree implementation
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
        #endregion

        #region Priority based Task Scheduler
        Console.WriteLine("\n");
        DSA_Project.TaskScheduler scheduler = new DSA_Project.TaskScheduler();

        // Sample tasks
        scheduler.AddTask(new TaskItem("Task A", priority: 3, executionTime: 300));
        scheduler.AddTask(new TaskItem("Task B", priority: 1, executionTime: 100));
        scheduler.AddTask(new TaskItem("Task C", priority: 2, executionTime: 200));
        scheduler.AddTask(new TaskItem("Task D", priority: 4, executionTime: 150));

        scheduler.ExecuteAllTasks();
        #endregion

        #region Debugged Task Execution
        Console.WriteLine("\n *** Task Execution Started...\n");

        List<TaskItem> tasks = new List<TaskItem>
            {
                new TaskItem("Task A", 1, 500),
                new TaskItem("Task B", 2, 700),
                new TaskItem("Task C", 3, 300),
                new TaskItem("Task D", 2, 400)
            };

        // Sort by priority (lower = higher priority)
        tasks.Sort((a, b) => a.Priority.CompareTo(b.Priority));

        foreach (var task in tasks)
        {
            try
            {
                ExecuteTask(task);
                LogInfo($"Task '{task.Name}' completed successfully.");
            }
            catch (Exception ex)
            {
                LogError($"Task '{task.Name}' failed. Error: {ex.Message}");
            }
        }

        Console.WriteLine("\n *** All tasks processed.");
        #endregion
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

    static void ExecuteTask(TaskItem task)
    {
        LogInfo($"Executing '{task.Name}' (Priority: {task.Priority}, Time: {task.ExecutionTime}ms)");

        // Simulate task execution time
        Thread.Sleep(task.ExecutionTime);

        // Randomly simulate a failure
        if (new Random().Next(0, 4) == 0) // ~25% chance to fail
            throw new Exception("Simulated runtime failure.");
    }

    static void LogInfo(string message)
    {
        Console.WriteLine($"[INFO {DateTime.Now:HH:mm:ss}] {message}");
    }

    static void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR {DateTime.Now:HH:mm:ss}] {message}");
        Console.ResetColor();
    }
}