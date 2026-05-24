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
                    Console.WriteLine(Question);
                    input = Console.ReadLine().ToLower();
                    if (input == "")
                    {
                        Console.WriteLine("You have to write something.");
                    }
                    if (input == Answer)
                    {
                        Console.WriteLine("Amazing!");
                        return 1;
                    }
                    Console.WriteLine("Your answer was incorrect.");
                    Console.WriteLine("If you want:");
                    Console.WriteLine("1) A hint press H");
                    Console.WriteLine("2) To resign press R");
                    Console.WriteLine("3) To proceed press enter");
                    string choice = Console.ReadLine().ToLower().Trim();
                    switch (choice)
                    {
                        case "h":
                            Console.WriteLine(Hint);
                            break;
                        case "r":
                            return 0;
                        default:
                            continue;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was a mistake somewhere.");
                }
            }

            return 0;
        }
}