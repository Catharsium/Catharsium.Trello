using System.Threading.Tasks;
using Catharsium.Trello.Core;

namespace Catharsium.Trello.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            var board = await new Downloader().Json();
            System.Console.WriteLine(board.Name);
        }
    }
}