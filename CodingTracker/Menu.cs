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
                        EditMenu();
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

            Console.WriteLine("Start Time:");
            DateTime startTime = UserInput.GetTimeManually(day);

            Console.WriteLine("End Time:");
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

        private static void EditMenu()
        {
            Console.Clear();
            List<CodingSession> sessions = Database.ViewAll();
            if(sessions.Count > 0)
            {
                Console.WriteLine("Select a session to edit from the following:\n");
                for (int i = 0; i < sessions.Count; i++)
                {
                    Console.WriteLine($"\t{i + 1}: id: {sessions[i].id}; StartTime: {sessions[i].StartTime}; EndTime: {sessions[i].EndTime}"); 
                }
                int response = UserInput.GetMenuOption(1, sessions.Count);
                CodingSession sessionToUpdate = sessions[response - 1];
                int option;
                do
                {
                    Console.Clear();
                    Console.WriteLine($"id: {sessionToUpdate.id}; StartTime: {sessionToUpdate.StartTime}; EndTime: {sessionToUpdate.EndTime}\n");
                    Console.WriteLine("Please select from the following:\n");
                    Console.WriteLine("\t1: Edit start time");
                    Console.WriteLine("\t2: Edit end time");
                    Console.WriteLine("\t3: Finish");

                    option = UserInput.GetMenuOption(1, 3);
                    switch(option)
                    {
                        case 1:
                            sessionToUpdate.StartTime = UserInput.GetNewSessionTime(sessionToUpdate.StartTime);
                            break;
                        case 2:
                            sessionToUpdate.EndTime = UserInput.GetNewSessionTime(sessionToUpdate.EndTime);
                            break;
                    }

                } while (option != 3);

                Database.UpdateRow(sessionToUpdate);
                Console.WriteLine($"Session ID:{sessionToUpdate.id} successfully updated");

            } else
            {
                Console.WriteLine("No session available to edit");
            }
            


        }
        private static void ViewAll()
        {
            Console.Clear();
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
