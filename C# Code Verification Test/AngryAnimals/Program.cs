using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AngryAnimals
{
    class Result
    {
 

        /*
         * Complete the 'angryAnimals' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER_ARRAY a
         *  3. INTEGER_ARRAY b
         */

        public static long angryAnimals(int n, List<int> a, List<int> b)
        {
            List<SortedSet<int>> lst = new List<SortedSet<int>>();
            for (int i = 0; i < a.Count; i++)
            {
                lst.Add(new SortedSet<int>());
            }
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] < b[i])
                {
                    lst[b[i]].Add(a[i]);
                }
                else
                {
                    lst[a[i]].Add(b[i]);
                }
            }

            long count = 0;

            Queue<int> qu = new Queue<int>();

            for (int i = 1; i <= n; i++)
            {

                if (lst[i].Count==0)
                {
                    count++;
                    qu.Enqueue(i);
                }
                else
                {

                    while (qu.Count!=0 && lst[i].Count!=0 && qu.Peek() <= lst[i].First() && qu.Last() >= lst[i].First())
                    {
                        if (qu.Peek() >= lst[i].First())
                        {
                            lst[i].Remove(lst[i].First());
                        }
                        qu.Dequeue();
                        count += qu.Count;
                    }
                    qu.Enqueue(i);
                    count++;
                }
            }
            int size = qu.Count;
            //number of ways for remaining elements
            count += size * (size - 1) / 2;
            return count;



        }

      
    }
    class Program
    {
        static void Main(string[] args)
        {

            //  TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int aCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> a = new List<int>();

            for (int i = 0; i < aCount; i++)
            {
                int aItem = Convert.ToInt32(Console.ReadLine().Trim());
                a.Add(aItem);
            }

            int bCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> b = new List<int>();

            for (int i = 0; i < bCount; i++)
            {
                int bItem = Convert.ToInt32(Console.ReadLine().Trim());
                b.Add(bItem);
            }

            long result = Result.angryAnimals(n, a, b);

            Console.WriteLine(result);
            //    textWriter.WriteLine(result);

            //  textWriter.Flush();
            //textWriter.Close();
            Console.ReadLine();

        }
    }
}
