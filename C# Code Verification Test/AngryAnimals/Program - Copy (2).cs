using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryAnimals
{
    class Result3
    {


        public class AngryCombo
        {
            public AngryCombo(int ani1,int ani2)
            {
                animal_1 = Math.Min(ani1, ani2);
                animal_2 = Math.Max(ani1, ani2);
            }
            public int animal_1 { get; set; }
            public int animal_2 { get; set; }
        }

        public class AngryComboList
        {

            public List<AngryCombo> ListofAngryAnimals = new List<AngryCombo>();

            public AngryComboList(List<int> a, List<int> b)
            {
                for(int i = 0; i < a.Count; i++)
                {
                    ListofAngryAnimals.Add(new AngryCombo(a[i], b[i]));
                }
            }

            private class Index
            {
                public int ani1 { get; set; }
                public int ani2 { get; set; }
            }
            private List<Index> generateCombinations(string input)
            {
                List<Index> lst = new List<Index>();

                List<int> array = input.Split(',').Select(item => Convert.ToInt32(item)).ToList();

                for (int i = 0; i < array.Count; i++)
                {
                    for (int j = i + 1; j < array.Count; j++)
                    {
                        lst.Add(new Index() { ani1 = array[i], ani2 = array[j] });
                    }
                }

                return lst;
            }

            public bool checkIfComboExists(string input)
            {
                List<Index> lstAllCombinations = generateCombinations(input);
                foreach(Index ind in lstAllCombinations)
                {
                    if (ListofAngryAnimals.Exists(item => item.animal_1 == ind.ani1 && item.animal_2 == ind.ani2))
                    {
                        return true;
                    }
                }
                return false;
            }
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
             
            List<List<string>> lstSafeCombinations = new List<List<string>>();

            AngryComboList lstAngryCombinations = new AngryComboList(a,b);



//            for(int i=1;i <= n; i++){
//                lstSafeCombinations.Add(new List<string>() {i.ToString()});
////                lstSafeCombinations[i].Add(i.ToString());
//            }
                       

            for(int i = 1; i <= n;i++)
            {
                lstSafeCombinations.Add(new List<string>());
                bool skipAhead = false;
                string items = "";
                for (int j = i+1; j <= n; j++)
                {
                    items = (items.Contains(",") ? items + "," + j.ToString() : i.ToString() + "," + j.ToString());
                    if (lstAngryCombinations.checkIfComboExists(items))
                    {
                        break;
                    }
                    else
                    {
                        lstSafeCombinations[i-1].Add(items);
                    }
                }
            }


            int count = n;
            foreach(List<string> lst in lstSafeCombinations)
            {
                count = count + lst.Count;
            }

            return count;
        }

    }
    class Program3
    {
        static void Main3(string[] args)
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
