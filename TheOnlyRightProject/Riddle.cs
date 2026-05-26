namespace TheOnlyRightProject;

public class Riddle
{
        public string Question { get; set; }
        public string Hint { get; set; }
        public string Answer { get; set; }
        public Riddle(string question, string hint, string answer)
        {
            Question = question;
            Hint = hint;
            Answer = answer;
        }
    
        public int RiddleExecute()
        {
            string input = "";
            while (input != Answer)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(Question);
                    Console.ResetColor();
                    input = Console.ReadLine().ToLower();
                    if (input == "")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You have to write something.");
                        Console.ResetColor();
                    }
                    if (input == Answer)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Amazing!");
                        Console.ResetColor();
                        return 1;
                    }
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Your answer was incorrect.");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("If you want:");
                    Console.WriteLine("1) A hint press H");
                    Console.WriteLine("2) To resign press R");
                    Console.WriteLine("3) To proceed press enter");
                    Console.ResetColor();
                    string choice = Console.ReadLine().ToLower().Trim();
                    switch (choice)
                    {
                        case "h":
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine(Hint);
                            Console.ResetColor();
                            break;
                        case "r":
                            return 0;
                        default:
                            continue;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("There was a mistake somewhere.");
                    Console.ResetColor();
                
                }
            }

            return 0;
        }
}