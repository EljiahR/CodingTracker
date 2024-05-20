using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class Menu
    {
        public static void MainMenu(bool clearScreen = false)
        {
            if (clearScreen)
            {
                Console.Clear();
                Console.WriteLine("\nCoding Tracker");
            }
            int selectedOption;
            do
            {
                Console.WriteLine("\n\tMain Menu\n");
                Console.WriteLine("Select from the following:");
                Console.WriteLine("\t1: New Entry");
                Console.WriteLine("\t2: Edit Entry");
                Console.WriteLine("\t3: View All Entries");
                Console.WriteLine("\n\t4: Delete Database");
                Console.WriteLine("\t5: Exit Program");

                selectedOption = UserInput.GetMenuOption(1, 5);

                switch (selectedOption)
                {
                    case 1:
                        NewEntryMenu(true);
                        break;
                    case 2:
                        break;
                    case 3:
                        ViewAll();
                        break;
                    case 4:
                        DeleteDatabase();
                        break;
                }
            } while (selectedOption != 5);
            Console.WriteLine("Goodbye!");

        }

        private static void NewEntryMenu(bool clearScreen = false)
        {
            if(clearScreen) Console.Clear();

            Console.WriteLine("Select from the follwing:");
            Console.WriteLine("\t1: Manual Entry");
            Console.WriteLine("\t2: Timer");

            int selectedOption = UserInput.GetMenuOption(1, 2);

            switch(selectedOption)
            {
                case 1:
                    ManualEntry();
                    break;
                case 2:
                    Timer();
                    break;
            }

        }

        private static void ManualEntry()
        {
            DateTime day = UserInput.GetDay();

            Console.WriteLine("Please enter a start time as HH:MM (AM/PM) or (24-hour)HH:MM");
            DateTime startTime = UserInput.GetTimeManually(day);

            Console.WriteLine("Please enter an end time as HH:MM (AM/PM) or (24-hour)HH:MM");
            DateTime endTime = UserInput.GetTimeManually(day);

            CodingSession session = new CodingSession();
            session.StartTime = startTime;
            session.EndTime = endTime;

            Database.InsertRow(session);
            Console.WriteLine($"Coded on {day.ToString("yyyy-MM-dd")} for {session.CalculateDuration()}"); // for debugging purposes

        }

        private static void Timer()
        {
            Console.Clear();
            Console.WriteLine("Press enter to begin timer...");
            Console.ReadLine();
            DateTime startTime = DateTime.Now;

            Console.Clear();
            Console.WriteLine("Timer started, press enter to end");
            Console.ReadLine();
            DateTime endTime = DateTime.Now;

            Console.Clear();
            CodingSession session = new CodingSession();
            session.StartTime = startTime;
            session.EndTime = endTime;

            Database.InsertRow(session);
            Console.WriteLine($"Coded on {startTime.ToString("yyyy-MM-dd")} for {session.CalculateDuration()}"); // for debugging purposes
        }

        private static void ViewAll()
        {
            List<CodingSession> sessions = Database.ViewAll();
            foreach(var session in sessions)
            {
                Console.WriteLine($"ID: {session.id}");
                Console.WriteLine($"\tCoded on {session.StartTime.ToString("yyyy-MM-dd")} for {session.CalculateDuration()}");
            }
        }

        private static void DeleteDatabase()
        {
            //Add confirmation
            Console.Clear();
            Database.DeleteAll();
            Console.WriteLine("Table Deleted");
        }
    }
}
