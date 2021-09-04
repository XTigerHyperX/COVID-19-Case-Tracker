using System;
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
            if (a!.ToUpper() == "CLEAR")
            {
                Console.Clear();
                goto Start;
            }
            else
            {
                try
                {
                    RestClient client = new RestClient("https://coronavirus-19-api.herokuapp.com/countries/");
                    IRestRequest jsonRequest = new RestRequest(a);
                    IRestResponse jsonResponse = client.Execute(jsonRequest);
                    jsonResponse.Content = "[" + jsonResponse.Content + "]";

                    dynamic data = JsonConvert.DeserializeObject(jsonResponse.Content);

                    if (data != null)
                        foreach (dynamic itemData in data)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Cases: " + itemData.cases);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Cases Today : " + itemData.todayCases);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Active Cases: " + itemData.active);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nDeaths : " + itemData.deaths);

                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Deaths Today :" + itemData.todayDeaths);

                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("Critical  : " + itemData.critical);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nRecovered  : " + itemData.recovered);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Total Tests  : " + itemData.totalTests);

                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\nCases Per One Million : " + itemData.casesPerOneMillion);

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Deaths Per One Million : " + itemData.deathsPerOneMillion);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Tests Per One Million : " + itemData.testsPerOneMillion);

                        }

                    goto Start;
                }
                catch
                {
                    Console.WriteLine(
                        "Smth went wrong , endpoint might be down or an error with ur internet connection");
                    Console.ReadKey();
                }
            }
        }
    }
}