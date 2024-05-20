﻿using System;
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
                Console.WriteLine("\t3: Exit Program");

                selectedOption = UserInput.GetMenuOption(1, 3);

                switch (selectedOption)
                {
                    case 1:
                        NewEntryMenu(true);
                        break;
                }
            } while (selectedOption != 3);
            

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
            Console.WriteLine($"Coded on {startTime.ToString("yyyy-MM-dd")} for {session.CalculateDuration()}"); // for debugging purposes
        }
    }
}
