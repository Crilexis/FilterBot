using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace BotFilterData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inform file to load");
            string file = Console.ReadLine();

            if (!File.Exists(file))
                Console.WriteLine($"File {file} not found");

            Console.WriteLine($"{Environment.NewLine}Inform operation type: {Environment.NewLine}1. Kibana message dump");

            if (!int.TryParse(Console.ReadLine(), out int option))
                Console.WriteLine("Invalid option");

            try
            {
                string json = File.ReadAllText(file);

                Action<string> action = option switch
                {
                    1 => WriteKibanaMassage,
                    _ => x => Console.WriteLine($"{Environment.NewLine}Invalid option selected"),
                };

                action(json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{Environment.NewLine}Invalid operation: \r\n{e.Message}");
            }

            Console.WriteLine($"{Environment.NewLine}Processing done");
            Console.ReadLine();
        }

        static void WriteKibanaMassage(string json)
        {
            KibanaMessage messageDump = JsonSerializer.Deserialize<KibanaMessage>(json);
            if (messageDump == null)
                throw new Exception("Invalid json");                

            Console.WriteLine($"{Environment.NewLine}Inform RegEx to be applyied to the message surrounded by quotes");

            string pattern = Console.ReadLine().Trim('"');
            Regex regex = new Regex(pattern);

            if (regex == null)
                throw new Exception("Invalid pattern");

            List<string> messages = messageDump.hits.hits.Select(x => regex.Match(x._source.message).Groups[1].Value).ToList();

            if(messages.Count > 0)
            {
                File.WriteAllLines("output.txt", messages);
            }

            Console.WriteLine($"{Environment.NewLine}Data wrote to output.txt");
        }
    }
}
