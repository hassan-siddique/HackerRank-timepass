using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AngryAnimalsWorking
{
    class Result
    {

        public class AngryComboDict
        {
           // SortedDictionary<int, List<int>> dictionary;
            SortedDictionary<int, List<int>> dictionaryReversed;

            public AngryComboDict(List<int> a, List<int> b)
            {
                dictionaryReversed = new SortedDictionary<int, List<int>>();
               //  dictionary = new SortedDictionary<int, List<int>>();

                for (int i = 0; i < a.Count; i++)
                {
                    int key = Math.Min(a[i], b[i]);
                    int val = Math.Max(a[i], b[i]);

                    //{

                    //    List<int> lstValues;
                    //    if (!dictionary.TryGetValue(key, out lstValues))
                    //    {
                    //        lstValues = new List<int>();
                    //        dictionary.Add(key, lstValues);
                    //    }

                    //    dictionary[key].Add(val);
                    //}
                    {
                          key = Math.Max(a[i], b[i]);
                          val = Math.Min(a[i], b[i]);

                        List<int> lstValues;
                        if (!dictionaryReversed.TryGetValue(key, out lstValues))
                        {
                            lstValues = new List<int>();
                            dictionaryReversed.Add(key, lstValues);
                        }

                        dictionaryReversed[key].Add(val);
                    }
                }
            }


            public bool KeyExists(int key)
            {
                List<int> lstValues;
                //                if (dictionary.TryGetValue(key, out lstValues))
                if (dictionaryReversed.TryGetValue(key, out lstValues))
                {
                    return true;
                }
                return false;
            }

            public int GetMinValueAgainstKey(int key)
            {
                List<int> lstValues;
                //                if (dictionary.TryGetValue(key, out lstValues))
                if (dictionaryReversed.TryGetValue(key, out lstValues))
                {
                    
                     return lstValues.Min();
                    //                    return true;
                }
                return -1;
            }


            //public bool KeyValuePairExists(int key,int val)
            //{
            //    List<int> lstValues;
            //    if (!dictionary.TryGetValue(key, out lstValues))
            //    {
            //        return false;
            //    }
            //    else if(lstValues.Exists(item => item == val))
            //    {
            //        return true;
            //    }
            //    return false;
            //}

            public bool KeyValuePairExistsMinMax(int key, int min)
            {
                List<int> lstValues;
                if (!dictionaryReversed.TryGetValue(key, out lstValues))
                    return false;
                else if (lstValues.Exists(item => item >= min && item < key ))
                    return true;

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
           // List<List<string>> lstSafeCombinations = new List<List<string>>();
            AngryComboDict dict = new AngryComboDict(a, b);
            long count = n;
             

            Parallel.For(1, n, new ParallelOptions { MaxDegreeOfParallelism = 1 }, (i, state) => {
                //lock (dict)
                //{
                //    lstSafeCombinations.Add(new List<string>());
                //}
                long localCount = 0;
                for (int j = i + 1; j <= n; j++)
                {
                    Console.WriteLine("(i:{0},j:{1})->>", i, j);
                    if (dict.KeyExists(j))
                    {
                        Console.WriteLine("(i:{0},j:{1})   KeyExists for {0} -> with Min Value {2}", i,j,dict.GetMinValueAgainstKey(j));

                    }
                    //find limit between i and j so that it can be verified and loop is skipped
                    if (dict.KeyValuePairExistsMinMax(j, i)) 
                    {
                        Console.WriteLine("(i:{0},j:{1})::Break",  i,j);
                        break;
                    }

                    localCount = localCount + 1;
                    //lock (dict)
                    //{ lstSafeCombinations[i - 1].Add("--" + j.ToString()); }
                }
                lock (dict)
                {
                    count = count + localCount;
                }
            });
            return count;
        }

      
    }
    class Program
    {
        static void MainWorking(string[] args)
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
