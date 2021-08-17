using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneListClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            var responseBodyAsStream = await client.GetStreamAsync("https://one-list-api.herokuapp.com/items?access_token=cohort22");

            var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseBodyAsStream);

            foreach (Item item in items)
            {
                Console.WriteLine($"The task {item.text} was created on {item.created_at} and has a completion of {item.complete}");
            }
        }
    }
}
