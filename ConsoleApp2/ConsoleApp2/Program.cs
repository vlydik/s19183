using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string URL = @"https://www.pja.edu.pl";

            using var httpclient = new HttpClient();
            try
            {
                var response = await httpclient.GetAsync(URL);
                if (response.IsSuccessStatusCode)
                {
                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var responseContent = await response.Content.ReadAsStringAsync();

                    var matches = regex.Matches(responseContent);


                    if (!matches.Equals(null))
                    {
                        foreach (var match in matches)
                        {
                            Console.WriteLine("Email found: " + match);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No email addresses found.");
                    }
                }
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Error while downloading the page.");
            }
        }

    }
}