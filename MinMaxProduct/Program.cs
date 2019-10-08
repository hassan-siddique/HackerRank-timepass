
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



namespace MinMaxProduct
{


    class Result
    {

        /*
         * Complete the 'maxMin' function below.
         *
         * The function is expected to return a LONG_INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. STRING_ARRAY operations
         *  2. INTEGER_ARRAY x
         */

        public static List<long> maxMin(List<string> operations, List<int> x)
        {
            //1<= x[i] <= 10 ^ 9;
            //1 <= n <= 10 ^ 5;

            if (x.Count > Math.Pow(10, 5))
                throw new OverflowException("Custom Message :: n is above limit");

            else if (x.Any(n => n > Math.Pow(10, 9)))
                throw new OverflowException("Custom Message :: x contains above limit value");

            var lst_to_return = new List<long>();

            long min = 0;
            long max = 0;

            var y = new List<int>();

            //try
            //{

                if (operations.Count != x.Count)

                //case 01: return if size of both arrays is mismatch
                if (operations.Count != x.Count)
                    throw new Exception("Custom Message :: Mismatch counts");

            //case 02: 
            //there could possibility of a typo i.e. push or pop could be typed wrong
            //just to avoid the failure
            //we are going to take wrong words as PUSH (as it is 4 character letter)
            //and has more feasibility of typo as compare to POP -- just a thought

            for (int i = 0; i < operations.Count; i++)
            {
                if (operations[i].ToLower() == "push")
                {
                    y.Add(x[i]);
                    if (i == 0 || y.Count ==1) max = min = x[i];
                    else
                        if (x[i] < min)   min = x[i];
                        else if (x[i] > max) max = x[i];
                }
                else if (operations[i].ToLower() == "pop")
                {
                    y.Remove(x[i]);
                    if (y.Count == 0)  min = max = 0;
                    else
                        if (x[i] == min) min = y.Min();
                        else if (x[i] == max) max = y.Max();
                }


                lst_to_return.Add(min*max);

            }

            //}
            //catch (Exception ex)
            //{
            //    //throw ex;
            //    lst_to_return = new List<long>();
            //}

            return lst_to_return;

        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
           

            int operationsCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> operations = new List<string>();

            for (int i = 0; i < operationsCount; i++)
            {
                string operationsItem = Console.ReadLine();
                operations.Add(operationsItem);
            }

            int xCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> x = new List<int>();

            for (int i = 0; i < xCount; i++)
            {
                int xItem = Convert.ToInt32(Console.ReadLine().Trim());
                x.Add(xItem);
            }

            List<long> result = Result.maxMin(operations, x);

            Console.WriteLine(String.Join("\n", result));
            Console.ReadKey();

            //textWriter.WriteLine(String.Join("\n", result));

            ///textWriter.Flush();
            //textWriter.Close();
        }
    }
}
