using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditing_LargestMatrix
{
    class Program
    {

        public static int largestMatrix(List<List<int>> arr)
        {
            int largestMatrixSize = 0;
                 List<List<int>> result = new List<List<int>>();
                foreach (List<int> lst in arr)
                {
                    List<int> row = lst.Select(item => (int)item).ToList();
                    result.Add(row);
                }

       
                for(int row = 1; row < arr.Count; row++)
                {
                    for (int col = 1; col < arr[row].Count; col++)
                    {
                        if (arr[row][col] == 1) {
                            result[row][col] = Math.Min(result[row-1][col-1], Math.Min(result[row - 1][col], result[row][col - 1])) + 1;
                            largestMatrixSize = Math.Max(result[row][col], largestMatrixSize);
                        }
                        else {
                            result[row][col] = 0;
                        }
 
                    }
                }


             return largestMatrixSize;
        }

        static void Main(string[] args)
        {

            

            //  TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int arrRows = Convert.ToInt32(Console.ReadLine().Trim());

            int arrColumns = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> arr = new List<List<int>>();
            for(int i = 0; i < arrRows; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp=> Convert.ToInt32(arrTemp)).ToList());
            }

            int result = largestMatrix(arr);
            Console.WriteLine(result);
            //    textWriter.WriteLine(result);

            //  textWriter.Flush();
            //textWriter.Close();
            Console.ReadLine();

        }
    }
}
