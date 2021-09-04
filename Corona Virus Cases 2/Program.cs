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
                            Console.WriteLine("Cases: " +((decimal)itemData.cases).FormatValue());

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Cases Today : " +((decimal)itemData.todayCases).FormatValue());

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Active Cases: " + ((decimal)itemData.active).FormatValue());

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nDeaths : " + ((decimal)itemData.deaths).FormatValue());

                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Deaths Today :" + ((decimal)itemData.todayDeaths).FormatValue());

                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("Critical  : " + ((decimal)itemData.critical).FormatValue());

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nRecovered  : " + ((decimal)itemData.recovered).FormatValue());

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Total Tests  : " + ((decimal)itemData.totalTests).FormatValue());

                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\nCases Per One Million : " + ((decimal)itemData.casesPerOneMillion).FormatValue());

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Deaths Per One Million : " + ((decimal)itemData.deathsPerOneMillion).FormatValue());

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Tests Per One Million : " + ((decimal)itemData.testsPerOneMillion).FormatValue() + "\n");

                        }

                    goto Start;
                }
                catch
                {
                    Console.WriteLine(
                        "Smth went wrong , endpoint might be down or an error with ur internet connection or maybe wrong country name");
                    goto Start;
                }
            }
        }
    }
}