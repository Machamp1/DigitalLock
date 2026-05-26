namespace TheOnlyRightProject;
/// <summary>
/// Game class
/// </summary>
public class Game
{
    public List<Riddle> riddles = new List<Riddle>();
    private ILogger _logger;
    private DigitalCode digitalCode = new DigitalCode(4);

    public Game(ILogger logger)
    {
        _logger = logger;
        GetRiddle();        
    }
    /// <summary>
    /// Makes a folder that will store all riddles, answers and hints, which i can than use individually
    /// </summary>
    public void GetRiddle()
    {
        try
        {
            using(StreamReader reader = new StreamReader("text.txt"))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] field = line.Split(";"); 
                    riddles.Add(new Riddle(field[0].ToLower().Trim(), field[1].ToLower().Trim(), field[2].ToLower().Trim()));
                }
                reader.Close();  
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
            _logger.WriteInformation("error");
        
        }
    }
    /// <summary>
    /// Writes the starting message
    /// </summary>
    private void WriteStartMessage()
    {
        try
        {
            using(StreamReader s = new StreamReader("StartingMessage.txt"))
            {
                string line = "";
                while ((line = s.ReadLine()) != null)
                {
                    _logger.WriteInformation(line); 
                }
                s.Close();  
            }
        }
        catch (FileNotFoundException)
        {
            _logger.WriteInputMistake("file wasnt found");
        }
        catch (IOException)
        {
            _logger.WriteInputMistake("problem with file");
        }
        catch (Exception)
        {
            _logger.WriteInputMistake("error");
            
        } 
        
        Console.ReadLine();
    }
    /// <summary>
    /// picks 3 random riddles from
    /// </summary>
    private List<Riddle> GetRandomRiddles()
    {
        Random random = new Random();
        return riddles.OrderBy(x => random.Next(0, 100)).ToList();
    }
    public void Play() 
    {
        var riddles = GetRandomRiddles();
        int amountOfAnswers = 0;
        string digits = "";
        foreach (Riddle riddle in riddles)
        {
        
            int  result = riddle.RiddleExecute();
            if (result == 1)
            {
                byte randomDigit = digitalCode.NextDigit();
                digits += randomDigit;
                _logger.WriteInformation($"Your unlocked digit is: {randomDigit}");
                amountOfAnswers++;
            }

            if (amountOfAnswers == 4)
            {
                break;
            }
        }
        Console.WriteLine($"Your all random digits are: {digits}");
    }
    public void GuessCode()
    {
        string input = "";
        while (digitalCode.CorrectCode() != input)
        {
            try
            {
                _logger.WriteInformation("Guess correct code, with the digits given above");
                input = Console.ReadLine().ToLower();
                if (input == "")
                {
                    _logger.WriteInputMistake("You have to write something.");
                }
                if (input.Length != 4)
                {
                    _logger.WriteInputMistake("Code must contain exactly 4 digits.");
                }

                int number;
                if (!int.TryParse(input, out number))
                {
                    _logger.WriteInputMistake("Only numbers possible.");
                    continue;
                }

                if (digitalCode.CorrectCode() != input)
                {
                    _logger.WriteWrongAnswer("Wrong code, try again.");
                    _logger.WriteInformation(digitalCode.GetCountOfCorrectDigits(input));
                }

                if (digitalCode.CorrectCode() == input)
                {
                    _logger.WriteRightAnswer("You have finally escaped, congrats.");
                }
            }
            catch (Exception e)
            {
                _logger.WriteInputMistake("Something went wrong");
            }
        }
    }
    /// <summary>
    /// starts the program
    /// </summary>
    public void Start()
    {
        WriteStartMessage();
        Play();
        GuessCode();
    }
}