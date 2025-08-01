using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            // You can uncomment any method call to test its corresponding question.
            //SolveQuestion1();
            //SolveQuestion2();
            //SolveQuestion3();
            //SolveQuestion4();
            //SolveQuestion5();
            //SolveQuestion6();
            //SolveQuestion7();
            //SolveQuestion8();
            //SolveQuestion9();
            //SolveQuestion10();
            //SolveQuestion11();
            //SolveNotificationSystem(); // This is for the final part of the assignment
        }

        #region Question 1
        // Q1: Find numbers greater than a given value X.
        public static void SolveQuestion1()
        {
            Console.WriteLine("Enter size of array and number of queries (e.g., 3 3):");
            string[] firstLine = Console.ReadLine().Split(' ');
            int n = int.Parse(firstLine[0]);
            int numQueries = int.Parse(firstLine[1]);

            Console.WriteLine("Enter the array elements (e.g., 11 5 3):");
            string[] arrItems = Console.ReadLine().Split(' ');
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(arrItems[i]);
            }

            // Loop to process each query
            for (int q = 0; q < numQueries; q++)
            {
                Console.WriteLine($"Enter query {q + 1}:");
                int x = int.Parse(Console.ReadLine());
                int count = 0;
                // Count elements greater than x
                foreach (var num in numbers)
                {
                    if (num > x)
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
            }
        }
        #endregion

        #region Question 2
        // Q2: Check if an array is a palindrome.
        public static void SolveQuestion2()
        {
            Console.WriteLine("Enter size of the array:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the array elements:");
            string[] arrItems = Console.ReadLine().Split(' ');
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(arrItems[i]);
            }

            bool isPalindrome = true;
            // Compare elements from start and end
            for (int i = 0; i < n / 2; i++)
            {
                if (arr[i] != arr[n - 1 - i])
                {
                    isPalindrome = false;
                    break; // No need to continue
                }
            }

            if (isPalindrome)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        #endregion

        #region Question 3
        // Q3: Reverse a queue using a stack.
        public static void SolveQuestion3()
        {
            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);

            Console.WriteLine("Original queue: " + string.Join(", ", myQueue));

            ReverseQueue(myQueue);

            Console.WriteLine("Reversed queue: " + string.Join(", ", myQueue));
        }

        // Function to reverse the queue
        public static void ReverseQueue<T>(Queue<T> q)
        {
            Stack<T> s = new Stack<T>();
            // Move elements from queue to stack
            while (q.Count > 0)
            {
                s.Push(q.Dequeue());
            }
            // Move elements back from stack to queue (will be reversed)
            while (s.Count > 0)
            {
                q.Enqueue(s.Pop());
            }
        }
        #endregion

        #region Question 4
        // Q4: Check for balanced parentheses.
        public static void SolveQuestion4()
        {
            Console.WriteLine("Enter a string of parentheses:");
            string input = Console.ReadLine(); // e.g., ([{]}) or {[()]}

            if (IsBalanced(input))
            {
                Console.WriteLine("Balanced");
            }
            else
            {
                Console.WriteLine("Not Balanced");
            }
        }

        public static bool IsBalanced(string expression)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in expression)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0) return false; // No matching open bracket

                    char openBracket = stack.Pop();
                    if (!((openBracket == '(' && c == ')') ||
                          (openBracket == '{' && c == '}') ||
                          (openBracket == '[' && c == ']')))
                    {
                        return false; // Mismatched brackets
                    }
                }
            }
            return stack.Count == 0; // Stack must be empty at the end
        }
        #endregion

        #region Question 5
        // Q5: Remove duplicate elements from an array.
        public static void SolveQuestion5()
        {
            int[] arrayWithDuplicates = { 1, 2, 2, 3, 4, 4, 4, 5 };
            Console.WriteLine("Original array: " + string.Join(", ", arrayWithDuplicates));

            int[] uniqueArray = RemoveDuplicates(arrayWithDuplicates);
            Console.WriteLine("Array after removing duplicates: " + string.Join(", ", uniqueArray));
        }

        public static int[] RemoveDuplicates(int[] arr)
        {
            // Using a HashSet ensures uniqueness
            HashSet<int> set = new HashSet<int>(arr);
            return set.ToArray();
        }
        #endregion

        #region Question 6
        // Q6: Remove all odd numbers from an ArrayList.
        public static void SolveQuestion6()
        {
            ArrayList numbersList = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Original ArrayList: ");
            foreach (var item in numbersList) Console.Write(item + " ");
            Console.WriteLine();

            // Iterate backwards when removing to avoid index issues
            for (int i = numbersList.Count - 1; i >= 0; i--)
            {
                if ((int)numbersList[i] % 2 != 0) // If the number is odd
                {
                    numbersList.RemoveAt(i);
                }
            }

            Console.WriteLine("ArrayList after removing odd numbers: ");
            foreach (var item in numbersList) Console.Write(item + " ");
            Console.WriteLine();
        }
        #endregion

        #region Question 7
        // Q7: Implement a queue that can hold different data types.
        public static void SolveQuestion7()
        {
            // A non-generic Queue can hold any object type
            Queue queue = new Queue();

            queue.Enqueue(1);
            queue.Enqueue("Apple");
            queue.Enqueue(5.28);

            Console.WriteLine("Queue with different data types:");
            foreach (var item in queue)
            {
                Console.WriteLine($"Value: {item}, Type: {item.GetType()}");
            }
        }
        #endregion

        #region Question 8
        // Q8: Search for a target integer in a stack.
        public static void SolveQuestion8()
        {
            Stack<int> myStack = new Stack<int>();
            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);
            myStack.Push(40);
            myStack.Push(50);

            Console.WriteLine("Enter the target integer to search for:");
            int target = int.Parse(Console.ReadLine());

            int count = 0;
            bool found = false;
            // Use a temp stack to preserve data, since searching a stack is destructive
            Stack<int> tempStack = new Stack<int>();

            while (myStack.Count > 0)
            {
                int current = myStack.Pop();
                tempStack.Push(current); // Preserve in temp stack
                count++;
                if (current == target)
                {
                    found = true;
                    break; // Target found
                }
            }

            if (found)
            {
                Console.WriteLine($"Target was found successfully and the count = {count}");
            }
            else
            {
                Console.WriteLine("Target was not found");
            }

            // Restore original stack
            while (tempStack.Count > 0)
            {
                myStack.Push(tempStack.Pop());
            }
        }
        #endregion

        #region Question 9
        // Q9: Find the intersection of two arrays, with duplicates.
        public static void SolveQuestion9()
        {
            int[] arr1 = { 1, 2, 3, 4, 4 };
            int[] arr2 = { 10, 4, 4 };

            var intersection = FindIntersection(arr1, arr2);
            Console.WriteLine("Intersection: [" + string.Join(", ", intersection) + "]");
        }

        public static List<int> FindIntersection(int[] nums1, int[] nums2)
        {
            // Use a dictionary to count frequencies in the first array
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int num in nums1)
            {
                if (map.ContainsKey(num))
                    map[num]++;
                else
                    map[num] = 1;
            }

            List<int> result = new List<int>();
            foreach (int num in nums2)
            {
                // If the number exists in the map and its count is > 0
                if (map.ContainsKey(num) && map[num] > 0)
                {
                    result.Add(num);
                    map[num]--; // Decrement count to match frequency
                }
            }
            return result;
        }
        #endregion

        #region Question 10
        // Q10: Find a contiguous sublist that sums up to a target.
        public static void SolveQuestion10()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 7, 5 };
            int targetSum = 12;

            List<int> sublist = FindContiguousSublist(numbers, targetSum);

            if (sublist.Count > 0)
            {
                Console.WriteLine("Sublist found: [" + string.Join(", ", sublist) + "]");
            }
            else
            {
                Console.WriteLine("No sublist found with the target sum.");
            }
        }

        public static List<int> FindContiguousSublist(List<int> list, int target)
        {
            int currentSum = 0;
            int start = 0;
            for (int end = 0; end < list.Count; end++)
            {
                currentSum += list[end];

                // If sum exceeds target, shrink window from the start
                while (currentSum > target && start <= end)
                {
                    currentSum -= list[start];
                    start++;
                }

                if (currentSum == target)
                {
                    // Sublist found
                    List<int> result = new List<int>();
                    for (int i = start; i <= end; i++)
                    {
                        result.Add(list[i]);
                    }
                    return result;
                }
            }
            return new List<int>(); // No sublist found
        }
        #endregion

        #region Question 11
        // Q11: Reverse the first K elements of a queue.
        public static void SolveQuestion11()
        {
            Queue<int> q = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            int k = 3;

            Console.WriteLine("Original queue: " + string.Join(", ", q));
            ReverseFirstK(q, k);
            Console.WriteLine("Queue after reversing first " + k + " elements: " + string.Join(", ", q));
        }

        public static void ReverseFirstK(Queue<int> q, int k)
        {
            if (q == null || k <= 0 || k > q.Count) return;

            Stack<int> s = new Stack<int>();
            // 1. Push first K elements into a stack
            for (int i = 0; i < k; i++)
            {
                s.Push(q.Dequeue());
            }
            // 2. Enqueue the elements from the stack back into the queue
            while (s.Count > 0)
            {
                q.Enqueue(s.Pop());
            }
            // 3. Move the remaining (N-K) elements to the back of the queue
            for (int i = 0; i < q.Count - k; i++)
            {
                q.Enqueue(q.Dequeue());
            }
        }
        #endregion

        #region Notification System
        // Final part of the assignment: Notification System
        public class Notification
        {
            public string Message { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public static void SolveNotificationSystem()
        {
            List<Notification> history = new List<Notification>();
            LinkedList<Notification> liveQueue = new LinkedList<Notification>();

            // Add a new notification
            var newNotif = new Notification { Message = "First notification!", CreatedAt = DateTime.Now };
            history.Add(newNotif);
            liveQueue.AddFirst(newNotif); // Add to the front of the linked list
            Console.WriteLine("Added first notification.");

            var secondNotif = new Notification { Message = "User liked your post.", CreatedAt = DateTime.Now.AddSeconds(1) };
            history.Add(secondNotif);
            liveQueue.AddFirst(secondNotif);
            Console.WriteLine("Added second notification.");

            var thirdNotif = new Notification { Message = "New comment on your photo.", CreatedAt = DateTime.Now.AddSeconds(2) };
            history.Add(thirdNotif);
            liveQueue.AddFirst(thirdNotif);
            Console.WriteLine("Added third notification.");

            var fourthNotif = new Notification { Message = "You have a new follower.", CreatedAt = DateTime.Now.AddSeconds(3) };
            history.Add(fourthNotif);
            liveQueue.AddFirst(fourthNotif);
            Console.WriteLine("Added fourth notification.");

            // Display latest 3 live notifications
            Console.WriteLine("\n--- Latest 3 Live Notifications ---");
            var latestThree = liveQueue.Take(3);
            foreach (var notif in latestThree)
            {
                Console.WriteLine($"- {notif.Message} (at {notif.CreatedAt.ToShortTimeString()})");
            }

            // Remove the oldest live notification (from the end)
            if (liveQueue.Count > 0)
            {
                Console.WriteLine($"\nRemoving oldest live notification: '{liveQueue.Last.Value.Message}'");
                liveQueue.RemoveLast();
            }

            // Display live notifications after removal
            Console.WriteLine("\n--- Live Notifications After Removal ---");
            foreach (var notif in liveQueue)
            {
                Console.WriteLine($"- {notif.Message}");
            }

            // Count total logged notifications
            Console.WriteLine($"\nTotal notifications logged in history: {history.Count}");
        }
        #endregion
    }
}

