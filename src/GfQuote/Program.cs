using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace GfQuotes {
    class Program {
        static async Task Main(string[] args) {
            var quoteUrl = "https://greatfriends06.azurewebsites.net/api/quotes";
            using (var client = new HttpClient()) {
                var quote = await client.GetAsync(quoteUrl);
                var message = await quote.Content.ReadAsStringAsync();
                var lines = message
                    .Split(new string[] { "\\n" }, StringSplitOptions.None)
                    .Select(x => x.Trim('"')).ToList();
                lines.ForEach(Console.WriteLine);
            }
        }
    }
}
