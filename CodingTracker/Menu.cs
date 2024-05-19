using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class Menu
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\tMain Menu\n");
            Console.WriteLine("Select from the following:");
            Console.WriteLine("\t1: New Entry");
            Console.WriteLine("\t2: Edit Entry");

            int selectedOption = UserInput.GetMenuOption(1, 2);


        }
    }
}
