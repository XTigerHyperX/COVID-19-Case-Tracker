using System;
using System.Net;
using Newtonsoft;
using RestSharp;
using Newtonsoft.Json;

namespace Corona_Virus_Cases_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "COVID-19 Case tracker";
            Start:
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Enter Country Name ");
            string a = Console.ReadLine();
            try
            {
                RestClient Client = new RestClient("https://coronavirus-19-api.herokuapp.com/countries/");
                IRestRequest JSONRequest = new RestRequest(a);
                IRestResponse JSONResponse = Client.Execute(JSONRequest);
                JSONResponse.Content = "[" + JSONResponse.Content + "]";

                dynamic Data = JsonConvert.DeserializeObject(JSONResponse.Content);

                foreach (dynamic ItemData in Data)
                {

                    Console.ForegroundColor = ConsoleColor.Magenta;

                    Console.WriteLine("cases  " + ItemData.cases);
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("Cases Today : " + ItemData.todayCases);

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Deaths : " + ItemData.deaths);
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.WriteLine("Deaths Today :" + ItemData.todayDeaths);
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Recovered  : " + ItemData.recovered);

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;

                    Console.WriteLine("Critical  : " + ItemData.critical);
                    Console.WriteLine("Total Tests  : " + ItemData.totalTests);


                    Console.ForegroundColor = ConsoleColor.DarkYellow;


                    Console.WriteLine("Active Cases: " + ItemData.active);

                }
                goto Start;
            }
            catch
            {
                Console.WriteLine("An Error Happened Make sure you entered a right country name ( starts with high case ) else Please contact @XTigerHyperX");
                Console.ReadKey();
            }
        }
    }
}