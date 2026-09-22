using System.Diagnostics;

namespace AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            async Task<string> FetchDataAsync()
            {
                await Task.Delay(2000);
                return "Data loaded";
            }
            async Task<string> FetchWeatherAsync()
            {
                await Task.Delay(3000);
                return "Wheater loaded";
            }
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine("Fetching...");
            string data = await FetchDataAsync();
            string data2 = await FetchWeatherAsync();
            Console.WriteLine($"Done. {data}");
            Console.WriteLine($"Done. {data2}");
            stopwatch.Stop();
            Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            Console.WriteLine("Fetching...");
            Task<string> data3 = FetchDataAsync();
            Task<string> data4 = FetchWeatherAsync();
            await Task.WhenAll(data3, data4);
            stopwatch2.Stop();
            Console.WriteLine($"Time taken: {stopwatch2.ElapsedMilliseconds} ms");
        }
    }
}