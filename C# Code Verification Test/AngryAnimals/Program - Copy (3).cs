using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AngryAnimals
{
    class Result4
    {
             

        public class AngryComboDict
        {
            //SortedDictionary<int, List<int>> dictionary;
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

                        List<int> lstValues;
                        if (!dictionaryReversed.TryGetValue(val, out lstValues))
                        {
                            lstValues = new List<int>();
                            dictionaryReversed.Add(val, lstValues);
                        }

                        dictionaryReversed[val].Add(key);
                    }
                }
            }


            //public bool KeyExists(int key)
            //{
            //    List<int> lstValues;
            //    if (dictionary.TryGetValue(key, out lstValues))
            //    {
            //        return true;
            //    }
            //    return false;
            //}

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
                {
                    return false;
                }
                else if (lstValues.Exists(item => item >= min && item < key ))
                {
                    return true;
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
             
              
 //List<List<string>> lstSafeCombinations = new List<List<string>>();
            AngryComboDict dict = new AngryComboDict(a, b);
            long count = n;
            List<long> lstResultCounts = new List<long>();



            
            



                
            for(int i = 1; i <= n;i++)
            {
                //  lstSafeCombinations.Add(new List<string>());
                bool skipAhead = false;
//                string items = "";
                for (int j = i+1; j <= n; j++)
                {

                    //for(int k=i; k < j; k++)
                    //{
                    //if (!dict.KeyExists(k))
                    //{
                    //    break;
                    //}

                    //find limit between i and j so that it can be verified and loop is skipped

                    if (dict.KeyValuePairExistsMinMax(j,i))
                    {
                            skipAhead = true;
                            break;
                    }
                    //}

                    if (!skipAhead)
                    {
                        count = count + 1;
                 //       lstSafeCombinations[i - 1].Add("--"+j.ToString());
                    }
                    else {
                        break;
                    }
                }
            }


            //int count = n;
            //foreach(List<string> lst in lstSafeCombinations)
            //{
            //    count = count + lst.Count;
            //}

            return count;
        }

        private static void CalculatePartitionResult()
        {
            throw new NotImplementedException();
        }
    }
    class Program4
    {
        static void Main4(string[] args)
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
