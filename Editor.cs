using System;

namespace ziv
{
    public class Editor
    {
        // If ziv ended yet.
        private static bool Ended = false;
        
        // A list of colors that are hard to see if the white text is in front of it
        private static ConsoleColor[] LightColors = { ConsoleColor.White, ConsoleColor.DarkCyan,ConsoleColor.DarkYellow,ConsoleColor.Cyan,ConsoleColor.Yellow,ConsoleColor.Gray,ConsoleColor.Green,ConsoleColor.Blue,ConsoleColor.Magenta };
        public static void Entry(string file)
        {
            Console.Clear();
            ConsoleColor back = (ConsoleColor)Program.rng.Next(0,15); // Random color
            //Console.WriteLine(back);
            ConsoleColor fore = ConsoleColor.White; 
            if (LightColors.Contains(back))
            {
                fore = ConsoleColor.Black;
            }
            Bar(back, $"ziv - {file} - Type $-wq on 1 line to save and quit.", fore);
            MainLoop(file);
        }

        public static void MainLoop(string file)
        {
            Console.Write(Program.buffer);
            while (true)
            {
                string Buffer2 = Console.ReadLine();
                if (Buffer2 == "$-wq")
                {
                    Console.Clear();
                    Console.WriteLine("Saving file to disk...");
                    File.WriteAllText(file,Program.buffer);
                    Environment.Exit(0);
                } else if (Buffer2 == "$-q")
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                else
                {
                    Program.buffer += $"{Buffer2}\n";
                }
            }
        }

        public static void Bar(ConsoleColor barcolor, string Ltext, ConsoleColor LtextColor)
        {
            ConsoleColor oldc = Console.BackgroundColor; // Make an archive of the old background color
            Console.BackgroundColor = barcolor; // Change background color to desired one
            Console.SetCursorPosition(0, Console.CursorTop); // Go the the beginning of the current console line
            Console.Write(new string(' ', Console.BufferWidth)); // Draw a white space, as many times as it takes to fill the terminal.
            Console.SetCursorPosition(0, Console.CursorTop-1); // Go back to the beginning of the line that we drew the white spaces in
            ConsoleColor oldlc = Console.ForegroundColor; // Make an archive of the old foreground color
            Console.ForegroundColor = LtextColor; // Change foreground color to desired one
            Console.Write(Ltext); // Draw the bar text
            Console.ForegroundColor = oldlc; // Restore foreground color
            Console.BackgroundColor = oldc; // Restore background color
            Console.SetCursorPosition(0, Console.CursorTop + 1); // Go to the beginning of the line after the line that we drew the white spaces in
        }
    }
}