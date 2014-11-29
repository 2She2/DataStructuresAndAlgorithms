using System;
using System.Collections.Generic;

namespace _10.ShortestSequenceOfOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int m = 16;
            List<int> path = new List<int>();

            Queue<List<int>> numsSequences = new Queue<List<int>>();
            List<int> nums = new List<int>() { n };
            numsSequences.Enqueue(nums);

            while (true)
            {
                // Process plus 1
                List<int> currList = numsSequences.Dequeue();
                int currNum = currList[currList.Count - 1];

                int plus1 = currNum + 1;
                List<int> plusOneList = new List<int>(currList);
                plusOneList.Add(plus1);

                if (plus1 == m)
                {
                    path = plusOneList;
                    break;
                }
                else
                {
                    numsSequences.Enqueue(plusOneList);
                }

                // Process plus 2
                int plus2 = currNum + 2;
                List<int> plusTwoList = new List<int>(currList);
                plusTwoList.Add(plus2);

                if (plus2 == m)
                {
                    path = plusTwoList;
                    break;
                }
                else
                {
                    numsSequences.Enqueue(plusTwoList);
                }

                // Process multiply by 2
                int multiplyBy2 = currNum * 2;
                List<int> multiplyBy2List = new List<int>(currList);
                multiplyBy2List.Add(multiplyBy2);

                if (multiplyBy2 == m)
                {
                    path = multiplyBy2List;
                    break;
                }
                else
                {
                    numsSequences.Enqueue(multiplyBy2List);
                }
            }

            Console.WriteLine("Shortest path: " + string.Join(" -> ", path));
        }
    }
}
