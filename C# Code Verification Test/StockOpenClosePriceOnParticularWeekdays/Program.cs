using System;
using System.Collections; 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StockOpenClosePriceOnParticularWeekdays
{

    class Solution
    {
        public class Stock
        {
            public string date { get; set; }
            public float open { get; set; }
            public float close { get; set; }
            public float high { get; set; }
            public float low { get; set; }
            public DateTime DateCheck { get { return Convert.ToDateTime(date); } }
            public override string ToString()
            {
                return string.Format("{0} {1} {2}",date,open,close);
            }
        }

        public class StockDetails
        {
           public int page { get; set; }
           public int per_page { get; set; }
           public int total { get; set; }
           public int total_pages { get; set; }
           public List<Stock> data { get; set; } 
        }

        public class URL
        { 
           
            public static string MainUrl
            {
                get{return "https://jsonmock.hackerrank.com/api/stocks"; }
            }

            public static string PageNoUrl(int pageNo)
            {
                 return String.Format("https://jsonmock.hackerrank.com/api/stocks/?page={0}",pageNo);  
            }

            public static string KeyValuePageNoUrl(string key,string value,int pageNo)
            {
                return String.Format("https://jsonmock.hackerrank.com/api/stocks/?{0}={1}&page={2}",key,value, pageNo);
            }
            public static string KeyValueSearchPageNoUrl(string key, string value, int pageNo)
            {
                return String.Format("https://jsonmock.hackerrank.com/api/stocks/search?{0}={1}&page={2}", key, value, pageNo);
            }
            public static string KeyValueSearchUrl(string key, string value)
            {
                return String.Format("https://jsonmock.hackerrank.com/api/stocks/search?{0}={1}", key, value);
            }


            public static string GetJsonResponse(string url)
            {



                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                //   Console.WriteLine("Content length is {0}", response.ContentLength);
                // Console.WriteLine("Content type is {0}", response.ContentType);

                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8);

                //Console.WriteLine("Response stream received.");
                //Console.WriteLine(readStream.ReadToEnd());
                string result = readStream.ReadToEnd();

                response.Close();
                readStream.Close();

                return result;

                //string json = "";
                // System.Data.DataSet data = JsonConvert.DeserializeObject<System.Data.DataSet>(json);
            }
        }

        /*
         * Complete the function below.
         */
        static void openAndClosePrices(string firstDate, string lastDate, string weekDay)
        {
            const string dateTimeFormat = "d-MMMM-yyyy";
            //            string nowCheck = DateTime.Now.ToString(); 

            DateTime startDate = Convert.ToDateTime(firstDate);
            DateTime endDate = Convert.ToDateTime(lastDate);
            DayOfWeek toCheckDay; 
            Enum.TryParse(weekDay, out toCheckDay);
            DayOfWeek startDayofWeek = startDate.DayOfWeek;

           

            int difference = 0;
            if(toCheckDay > startDayofWeek)
            {
                difference = toCheckDay - startDayofWeek;
            }
            else if(toCheckDay < startDayofWeek)
            { 
                difference = 7 - (startDayofWeek - toCheckDay);
            }

            DateTime calcBegin= startDate.AddDays(difference);

            List<DateTime> cbDateTime = new List<DateTime>();
            while (calcBegin<= endDate)
            {
                cbDateTime.Add(calcBegin);
                calcBegin= calcBegin.AddDays(7);
            }

            List<Stock> cbResponse = new List<Stock>();

            foreach(DateTime dt in cbDateTime)
            {
                string json = URL.GetJsonResponse(URL.KeyValueSearchUrl("date", dt.ToString(dateTimeFormat)));

                StockDetails objects = JsonConvert.DeserializeObject<StockDetails>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    // $type no longer needs to be first
                    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
                });


                for (int i = 0; i < objects.total; i++)
                {
                    Stock stk = objects.data[i];
                    if (stk.DateCheck == dt)
                    {
                        cbResponse.Add(stk);
                        break;
                    }
                }
            }

            //            System.Threading.Tasks.Parallel.ForEach(cbDateTime, queryDate=> {
            //                string json = URL.GetJsonResponse(URL.KeyValueSearchUrl("date", queryDate.ToString(dateTimeFormat)));

            //                StockDetails objects = JsonConvert.DeserializeObject<StockDetails>(json, new JsonSerializerSettings
            //                {
            //                    TypeNameHandling = TypeNameHandling.All,
            //                    // $type no longer needs to be first
            //                    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
            //                });


            //                for (int i = 0; i < objects.total; i++)
            //                {
            //                    Stock stk = objects.data[i];
            //                    if (stk.DateCheck == queryDate)
            //                    {
            //                        cbResponse.Add(stk);
            //                        break;
            //                    }
            //                }


            ////scbResponse.Add(json);



            //            });


            for (int i =0; i < cbResponse.Count; i++)
            {
                Stock stk = cbResponse.ToList()[i];
                Console.WriteLine(stk.ToString());
            }


       //     Console.ReadLine();



        }

        static void Main(String[] args)
        { 


            bool basecase = true;
            string _firstDate;
            _firstDate = Console.ReadLine();
            if (basecase) _firstDate = "1-January-2000";

            string _lastDate;
            _lastDate = Console.ReadLine();
            if (basecase) _lastDate = "22-February-2000";

            string _weekDay;
            _weekDay = Console.ReadLine();
            if (basecase) _weekDay = "Monday";

            openAndClosePrices(_firstDate, _lastDate, _weekDay);

        }
    }
}
