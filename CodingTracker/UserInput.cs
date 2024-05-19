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
    }
}
