using System;
using System.Net;
using System.Text.Json;

namespace Corona_Virus_Cases_2
{
    class Program
    {
        static void Main()
        {
            Console.Title = "COVID-19 Case tracker";
            Utf8JsonReader jsonReader;

        Start:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter Country Name ");
            string country = Console.ReadLine();
            byte[] response;
            try
            {
                WebClient client = new();
                response = client.DownloadData($"https://coronavirus-19-api.herokuapp.com/countries/{country}");
            }
            catch (WebException)
            {
                Console.WriteLine("The API is down. Try again later.");
                return;
            }

            jsonReader = new(response);
            try
            {
                jsonReader.Read();
            }
            catch (JsonException)
            {
                Console.WriteLine("An error has happened. Make sure you entered a right country name, else please contact @XTigerHyperX.");
                goto Start;
            }

            jsonReader.Read();
            jsonReader.Read();
            jsonReader.Read();
            jsonReader.Read();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Cases: {jsonReader.GetInt32()}");
            jsonReader.Read();
            jsonReader.Read();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Cases Today: {jsonReader.GetInt32()}");
            jsonReader.Read();
            jsonReader.Read();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Deaths: {jsonReader.GetInt32()}");
            jsonReader.Read();
            jsonReader.Read();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Deaths Today: {jsonReader.GetInt32()}");
            jsonReader.Read();
            jsonReader.Read();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Recovered : {jsonReader.GetInt32()}");
            jsonReader.Read();
            jsonReader.Read();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Active Cases: {jsonReader.GetInt32()}");
            jsonReader.Read();
            jsonReader.Read();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Critical Cases: {jsonReader.GetInt32()}");
            jsonReader.Read();
            jsonReader.Read();
            jsonReader.Read();
            jsonReader.Read();
            jsonReader.Read();
            jsonReader.Read();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Total tests: {jsonReader.GetInt32()}");
            goto Start;
        }
    }
}
