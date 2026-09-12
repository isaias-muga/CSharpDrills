using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string> { "ana", "beto", "caro" };
            string search = "beto";

            Console.WriteLine(set.Contains(search) != null ? $"{search}" : "beto not registered");
        }
    }
}  