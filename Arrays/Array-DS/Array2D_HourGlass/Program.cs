using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Threading.Tasks;

namespace Array2D_HourGlass
{
    class Program
    {

        public class Point
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        // Complete the hourglassSum function below.
        static int hourglassSum(int[][] arr)
        {
            List<Point> lstpoints = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    lstpoints.Add(new Point() { x = i, y = j });
                }
            }

            int maxSum = -999;

            Parallel.For(0, lstpoints.Count, new ParallelOptions { MaxDegreeOfParallelism = 1 }, (i, state) => {

                Point pt = lstpoints[i];

                int localSum = arr[pt.x][pt.y] + arr[pt.x][pt.y + 1] + arr[pt.x][pt.y + 2]
                                                 + arr[pt.x + 1][pt.y + 1]
                             + arr[pt.x + 2][pt.y] + arr[pt.x + 2][pt.y + 1] + arr[pt.x + 2][pt.y + 2];

                lock (lstpoints)
                {
                    maxSum = Math.Max(maxSum, localSum);
                }
            });

            return maxSum;
        }



        static void Main(string[] args)
        {
            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = hourglassSum(arr);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
