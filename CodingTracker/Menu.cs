using Spectre.Console;

namespace CodingTracker
{
    internal class Menu
    {
        private static SelectionPrompt<string> mainMenuOptions = new SelectionPrompt<string>()
                        .Title("Main Menu")
                        .PageSize(7)
                        .AddChoices(new[]
                        {
                            "New Entry",
                            "Edit Entry",
                            "View All Entries",
                            "Display Graph",
                            "Delete Entry",
                            "[red]Delete Database[/]",
                            "Exit Program"
                        });

        private static SelectionPrompt<string> newEntryOptions = new SelectionPrompt<string>()
                        .Title("Entry Methods")
                        .PageSize(3)
                        .AddChoices(new[]
                        {
                            "Manual",
                            "Timer",
                            "Return to menu"
                        });

        public static void MainMenu(bool clearScreen = false)
        {
            
            
            
            if (clearScreen)
            {
                Console.Clear();
                Console.WriteLine("\nCoding Tracker");
            }
            string selectedOption;
            do
            {
                selectedOption = AnsiConsole.Prompt(mainMenuOptions);

                switch (selectedOption)
                {
                    case "New Entry":
                        NewEntryMenu();
                        break;
                    case "Edit Entry":
                        EditMenu();
                        break;
                    case "View All Entries":
                        ViewAll();
                        break;
                    case "Display Graph":
                        GraphMenu();
                        break;
                    case "Delete Entry":
                        DeleteMenu();
                        break;
                    case "Delete Database":
                        DeleteDatabase();
                        break;
                }
            } while (selectedOption != "Exit Program");
            Console.Clear();
            Console.WriteLine("Goodbye!");

        }

        private static void NewEntryMenu()
        {
            Console.Clear();

            string selectedOption = AnsiConsole.Prompt(newEntryOptions);

            switch(selectedOption)
            {
                case "Manual":
                    ManualEntry();
                    break;
                case "Timer":
                    TimerEntry();
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

        private static void TimerEntry()
        {
            Console.Clear();
            Console.WriteLine("Press enter to begin timer...");
            Console.ReadLine();
            DateTime startTime = DateTime.Now;

            Console.Clear();
            Console.WriteLine($"Timer started at {startTime}, press Enter to end");
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
                    Console.WriteLine($"{i + 1}:");
                    Console.WriteLine($"\tid: {sessions[i].id}; StartTime: {sessions[i].StartTime}; EndTime: {sessions[i].EndTime}");
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
            if(sessions.Count > 0)
            {
                foreach (var session in sessions)
                {
                    Console.WriteLine($"ID: {session.id}");
                    Console.WriteLine($"\tCoded on {session.StartTime.ToString("yyyy-MM-dd")} for {session.CalculateDuration()}");
                }
            } else
            {
                Console.WriteLine("No sessions to display");
            }
            
        }

        private static void GraphMenu()
        {
            Console.Clear();
            Console.WriteLine("Select view option:");// Fix this 
            Console.WriteLine("\t1: Hours per day");
            Console.WriteLine("\t2: Hours per month");
            Console.WriteLine("\t3: Hours per year");
            Console.WriteLine("\t4: Return to menu");

            int response = UserInput.GetMenuOption(1, 4);

            switch(response)
            {
                case 1:
                    Graph.DisplayGraph(Database.GetHoursPerDay(), "day");
                    break;
                case 2:
                    Graph.DisplayGraph(Database.GetHoursPerMonth(), "month");
                    break;
                case 3:
                    Graph.DisplayGraph(Database.GetHoursPerYear(), "year");
                    break;
            }
        }

        private static void DeleteMenu()
        {
            Console.Clear();
            List<CodingSession> sessions = Database.ViewAll();
            if(sessions.Count > 0 )
            {
                Console.WriteLine("Please select an entry to delete: ");
                for (int i = 0; i < sessions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}:");
                    Console.WriteLine($"\tid: {sessions[i].id}; StartTime: {sessions[i].StartTime}; EndTime: {sessions[i].EndTime}");
                }
                int response = UserInput.GetMenuOption(1, sessions.Count);

                CodingSession sessionToDelete = sessions[response - 1];
                Database.DeleteRow(sessionToDelete);
                Console.WriteLine($"Session ID:{sessionToDelete.id} successfully updated");
            } else
            {
                Console.WriteLine("No sessions to delete");
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
