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
            int result;
            while(!int.TryParse(response, out result) || result < start || result > end)
            {
                Console.WriteLine("Invalid response");
                response = Console.ReadLine();
            }

            return result;
        }

        public static DateTime GetDay()
        {
            Console.WriteLine("\nPlease input a date in YYYY-MM-DD format or leave blank for today");
            string? response = Console.ReadLine();
            DateTime day = new();
            while(!string.IsNullOrEmpty(response) && DateTime.TryParse(response, out day))
            {
                Console.WriteLine("Invalid response");
            }
            if (string.IsNullOrEmpty(response)) day = DateTime.Today;
            return day;
        }

        public static DateTime GetTimeManually(DateTime day)
        {
            string? response = Console.ReadLine();
            TimeOnly time = new();
            while (string.IsNullOrEmpty(response) || !TimeOnly.TryParse(response, out time))
            {
                Console.WriteLine("Invalid response, must be HH:MM (AM/PM) or (24-hour)HH:MM");
                response = Console.ReadLine();
            }

            ;
            return day + time.ToTimeSpan();
        }
    }
}
