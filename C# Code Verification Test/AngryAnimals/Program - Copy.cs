using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryAnimals
{
    class Result1
    {



        public  class Index
        {
            public int x_axis { get; set; }
            public int y_axis { get; set; }
        }

        public static List<Index> generateCombinations(string input){
            List<Index> lst = new List<Index>();

            List<int> array = input.Split(',').Select(item => Convert.ToInt32(item)).ToList();

            for(int i =0; i < array.Count;i++)
            {
                for(int j =i+1;j < array.Count; j++)
                {
                    lst.Add(new Index() { x_axis = array[i],y_axis=array[j] });
                }
            }

            return lst;
        }
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
            long result=0;
             
            int[,] matrix = new int[n,n];
            List<List<string>> lstSafeCombinations = new List<List<string>>();


            for(int i=0;i < n; i++){
                lstSafeCombinations.Add(new List<string>());
            }


            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 1;
                        lstSafeCombinations[i].Add(i.ToString());
                        //lstAngryCombinations.Add(new AngryCombo(i, j));
                    }else
                        matrix[i, j] = 0;
                }
            }

            for (int i=0; i < a.Count;i++)
            {
                matrix[a[i]-1, b[i]-1] = 1;
                matrix[b[i]-1, a[i]-1] = 1;
            }




            for(int i = 0; i < n;i++)
            {
                bool loopAhead = false;
                bool itemAdded = false;
                string items = "";

                for (int j = i+1; j < n; j++)
                {
                    if(!loopAhead)
                    {

                        if (matrix[i, j] == 0)
                        {
                            itemAdded = true;
                            items = (items.Contains(",") ? items + "," + j.ToString() : i.ToString() + "," + j.ToString());
                            if (items.Contains(",")){
                                List<Index> lstCombinations = generateCombinations(items);
                                foreach (Index ind in lstCombinations)
                                {
                                    if (matrix[ind.x_axis, ind.y_axis] == 1)
                                    {
                                        loopAhead = true;
                                        break;
                                    }
                                }
                                if (!loopAhead) lstSafeCombinations[i].Add(items);
                                else break;

                            }
                            else {
                                lstSafeCombinations[i].Add(items);
                               // matrix[i, j] = 1;
                               // matrix[j, i] = 1;
                            }

                        }
                        else {
                            loopAhead = true;
                            break;
                        }
                    }
                    else if(itemAdded)
                    {
                        loopAhead = true;
                        break;
                      //  matrix[i, j] = 1;
                       // matrix[j, i] = 1;
                    }

                }
            }


            int count = 0;
            foreach(List<string> lst in lstSafeCombinations)
            {
                count = count + lst.Count;
            }

            return count;
        }

    }
    class Program1
    {
        static void MainOld(string[] args)
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

            long result = Result1.angryAnimals(n, a, b);

            Console.WriteLine(result);
            //    textWriter.WriteLine(result);

            //  textWriter.Flush();
            //textWriter.Close();
            Console.ReadLine();

        }
    }
}
