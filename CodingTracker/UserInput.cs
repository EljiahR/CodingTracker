using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class UserInput
    {
        public static int GetMenuOption(int start, int end)
        {
            string? response = Console.ReadLine();
            while(!InputValidation.ValidateMenuOption(start, end, response))
            {
                Console.WriteLine("Invalid response");
                response = Console.ReadLine();
            }

            return int.Parse(response!);
        }

        public static DateTime GetDay()
        {
            Console.WriteLine("\nPlease input a date in YYYY-MM-DD format or leave blank for today");
            string? response = Console.ReadLine();
            while(!InputValidation.ValidateDate(response))
            {
                Console.WriteLine("Invalid response");
                response = Console.ReadLine();
            }
            return string.IsNullOrEmpty(response) ? DateTime.Today : DateTime.Parse(response);
        }

        public static DateTime GetTimeManually(DateTime day)
        {
            Console.WriteLine("Please enter a time as HH:MM (AM/PM) or (24-hour)HH:MM");
            string? response = Console.ReadLine();
            while (InputValidation.ValidateTime(response))
            {
                Console.WriteLine("Invalid response, must be HH:MM (AM/PM) or (24-hour)HH:MM");
                response = Console.ReadLine();
            }

            
            return day + TimeOnly.Parse(response!).ToTimeSpan();
        }

        public static DateTime GetNewSessionTime(DateTime time)
        {
            DateTime timeToUpdate = time;
            if(AnsiConsole.Confirm("Would you like to change the day? y/n"))
            {
                timeToUpdate = GetDay();
            }
            timeToUpdate = GetTimeManually(DateTime.Parse(timeToUpdate.ToString("yyyy-MM-dd")));

            return timeToUpdate;
        }
    }
}
