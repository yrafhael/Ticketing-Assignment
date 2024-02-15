using System;
using System.IO;

namespace Ticketing
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string userChoice;

            do
            {
                // Ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");

                // Input response
                userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    // Read data from file
                    if (File.Exists(file))
                    {
                        // Read and display data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (userChoice == "2")
                {
                    // Create file from data
                    StreamWriter sw = new StreamWriter(file);

                    do
                    {
                        // Ask questions for Ticket data
                        Console.WriteLine("Enter TicketID:");
                        int ticketID = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Summary of the Movies:");
                        string summary = Console.ReadLine();

                        Console.WriteLine("Enter Ticket Status (Available/ Sold Out):");
                        string status = Console.ReadLine();

                        Console.WriteLine("Enter Priority (High/ Low):");
                        string priority = Console.ReadLine();

                        Console.WriteLine("Enter Submitter:");
                        string submitter = Console.ReadLine();

                        Console.WriteLine("Enter Assigned Person:");
                        string assigned = Console.ReadLine();

                        Console.WriteLine("Enter Watching (use commas between names):");
                        string watching = Console.ReadLine();

                        // Write Ticket data to file
                        sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned | Watching");
                        sw.WriteLine($"{ticketID},{summary},{status},{priority},{submitter},{assigned}|{watching}");

                        // Ask if user wants to add another ticket
                        Console.WriteLine("Do you want to add another ticket? (Y/N)");
                        userChoice = Console.ReadLine().ToUpper();

                    } while (userChoice == "Y");

                    sw.Close();
                }

            } while (userChoice == "1" || userChoice == "2");
        }
    }
}
