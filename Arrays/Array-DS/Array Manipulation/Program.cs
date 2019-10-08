using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Manipulation
{
    class Program
    {

        static long arrayManipulation(int n, int[][] queries)
        {
            long []arr= new long[n + 1];
           

            // Start performing 'm' operations 
            for (int i = 0; i < queries.Length; i++)
            {
                // Store lower and upper index i.e. range 
                int lowerbound = queries[i][0]-1;
                int upperbound = queries[i][1]-1;

                // Add k to the lower_bound 
                arr[lowerbound] += queries[i][2];

                // Reduce upper_bound+1 indexed value by k 
                arr[upperbound + 1] -= queries[i][2];
            }

            // Find maximum sum possible from all values 
            long sum = 0, res = 0;
            for (int i = 0; i < n; ++i)
            {
                sum += arr[i];
                res = Math.Max(res, sum);
            }

            // return maximum value 
            return res;
        }

        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            int m = Convert.ToInt32(nm[1]);

            int[][] queries = new int[m][];

            for (int i = 0; i < m; i++)
            {
                queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            }

            long result = arrayManipulation(n, queries);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
