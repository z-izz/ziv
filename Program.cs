using System;

namespace ziv
{
    public class Program
    {
        public static Random rng = new Random(); // Global random object
        public static string version = "Milestone 1 [Build 230412]"; // Version string
        public static string buffer = ""; // Text buffer
        public static void Main(string[] args) // Runner, sets up the buffer
        {
            try
            {
                if (args.Length == 1) // If one argument is passed
                {
                    if (File.Exists(args[0])) // If the first argument exists as a file
                    {
                        buffer = File.ReadAllText(args[0]); // Setup the buffer
                    }
                    else
                    {
                        if (args[0] == "--version" || args[0] == "-v")
                        {
                            Console.WriteLine($"ziv {version}");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("ziv says: No files? I'll make one then!");
                        }
                    }

                    Editor.Entry(args[0]); // Call the actual ziv editor
                }
                else
                {
                    Console.WriteLine("ziv says: It would be really nice if actually gave me a file to edit.");
                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! ziv has crashed! Sorry for the inconvenience!\n");
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine($"Error type: {e.GetType().Name}");
            }
        }
    }
}