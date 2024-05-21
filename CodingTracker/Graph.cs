using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class Graph
    {
        public static void DisplayGraph(List<SessionData> sessions, string label)
        {

            AnsiConsole.Write(new BarChart()
                .Width(60)
                .Label($"[green bold underline]Hours studied per {label}[/]")
                .CenterLabel()
                .AddItems(sessions)
            );
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
