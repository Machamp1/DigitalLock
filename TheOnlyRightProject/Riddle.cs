namespace TheOnlyRightProject;
/// <summary>
/// class for one single riddle
/// </summary>
public class Riddle
{
        public string Question { get; set; }
        public string Hint { get; set; }
        public string Answer { get; set; }
        private ILogger _logger;
        public Riddle(string question, string hint, string answer)
        {
            Question = question;
            Hint = hint;
            Answer = answer;
        }
        /// <summary>
        /// the stage of player answering on riddles
        /// </summary>
        /// <returns></returns>
        public int RiddleExecute()
        {
            string input = "";
            while (input != Answer)
            {
                try
                {
                    _logger.WriteInformation(Question);
                    input = Console.ReadLine().ToLower().Trim();
                    if (input == "")
                    {
                        _logger.WriteInputMistake("You have to write something.");
                    }
                    if (input == Answer)
                    {
                        _logger.WriteRightAnswer("Amazing!");
                        return 1;
                    }
                    _logger.WriteWrongAnswer("Your answer was incorrect.");
                    _logger.WriteInformation("If you want:");
                    _logger.WriteInformation("1) A hint press H");
                    _logger.WriteInformation("2) To resign press R");
                    _logger.WriteInformation("3) To proceed press enter");
                    string choice = Console.ReadLine().ToLower().Trim();
                    switch (choice)
                    {
                        case "h":
                            _logger.WriteInformation(Hint);
                            break;
                        case "r":
                            return 0;
                        default:
                            continue;
                    }
                }
                catch (FileNotFoundException)
                {
                    _logger.WriteInformation("file wasnt found");
                }
                catch (IOException)
                {
                    _logger.WriteInformation("problem with file");
                }
                catch (Exception)
                {
                    _logger.WriteInputMistake("There was a mistake somewhere.");
                }
            }
            return 0;
        }
}