using CodingTracker;
using Spectre.Console;


AnsiConsole.Markup("[underline red]Hello[/] World!");

CodingSession session = new CodingSession();
session.StartTime = DateTime.Now;
Console.WriteLine("Start: " +  session.StartTime.ToString("hh:mm:ss"));
Console.ReadLine();
session.EndTime = DateTime.Now;
Console.WriteLine("End: " + session.EndTime.ToString("hh:mm:ss"));
Console.WriteLine("Elapsed time: " + session.CalculateDuration());

