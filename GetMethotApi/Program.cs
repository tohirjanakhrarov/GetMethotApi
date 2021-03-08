using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace GetMethotApi
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
           link1:
            Console.WriteLine("Davlat nomini ingiliz tilida kiriting: ");
            string country = Console.ReadLine();
            var client = new HttpClient();
       		
     var request = new HttpRequestMessage
            
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://world-population.p.rapidapi.com/population?country_name="+country),
                Headers =
    {
        { "x-rapidapi-key", "7d2f5569ebmshe1f90a801d84a41p1a757djsn0ff6193a1d4a" },
        { "x-rapidapi-host", "world-population.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {   if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
                    goto link1;
                }
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(body);
                JObject json2 = (JObject) json["body"];
                /*Console.WriteLine(json);*/
                Console.WriteLine("Davlat nomi: "+ json2["country_name"] );
                Console.WriteLine("Aholi soni: " + json2["population"]);
                Console.WriteLine("Soni jihatdan dunyodagi o'rni: " + json2["ranking"]);
                Console.WriteLine("Dunyodagi ulushi: " + json2["world_share"]+" %");
                Console.Read();
                goto link1;
                
            }
        }
    }
}
