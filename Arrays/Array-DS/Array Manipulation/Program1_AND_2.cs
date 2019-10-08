using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Manipulation
{
    class Program1
    {
        // Complete the arrayManipulation function below.
        static long arrayManipulation1(int n, int[][] queries)
        {
           
            long[] arr = new long[n];
            for(int i=0; i < n; i++)
            {
                arr[i] = 0;
            }


            Parallel.For(0, queries.Length, new ParallelOptions { MaxDegreeOfParallelism = queries.Length }, (i, state) =>
                {
                    int a = queries[i][0];
                    int b = queries[i][1];
                    int k = queries[i][2];

                    int minIndex = Math.Min(a, b) - 1;
                    int maxIndex = Math.Max(a, b);



                    Parallel.For(minIndex, maxIndex, new ParallelOptions { MaxDegreeOfParallelism = (maxIndex - minIndex) / 2 }, (x, state2) =>
                        {
                            lock (queries)
                            {
                                arr[x] = arr[x] + k;
                            }
                        });
                }
            );

            //for (int i=0;i<queries.Length;i++)
            //{
            //    int a = queries[i][0];
            //    int b = queries[i][1];
            //    int k = queries[i][2];

            //    int minIndex = Math.Min(a, b) -1;
            //    int maxIndex = Math.Max(a, b) ;
            //    for (int x=minIndex; x <= maxIndex; x++)
            //    {
            //        arr[x] = arr[x] + k;
            //    }

            //}
            
            return arr.Max();
        }

        static void Main1(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            int m = Convert.ToInt32(nm[1]);

            int[][] queries = new int[m][];

            for (int i = 0; i < m; i++)
            {
                queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            }

            long result = arrayManipulation1(n, queries);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
