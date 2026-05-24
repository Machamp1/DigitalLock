namespace TheOnlyRightProject;

public class DigitalCode
{
    
    /*int[] digits = null;
    int length = 4;
    public DigitalCode(int length)
    {
        digits = new int[length];
        GenerateRandom();
    }*/

    private byte[] Numbers;
    private List<byte> UnshownDigits = new List<byte>();
    
    /// <summary>
    /// Generates 4 random numbers and adds them field to the list
    /// </summary>
    public DigitalCode(int length = 4)
    {
        Numbers = new byte[length];
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            // Console.WriteLine(Numbers[i]);
            Numbers[i] = (byte)random.Next(0, 10);
        }
        
        UnshownDigits.AddRange(Numbers);
    }

    /// <summary>
    /// Next random digit in the code
    /// </summary>
    /// <returns></returns>
    public byte NextDigit()
    {
        if (UnshownDigits.Count == 0)
        {
            throw new ArgumentException("All digits were shown");
        }
        Random random = new Random();
        byte index = (byte)random.Next(0, UnshownDigits.Count - 1);
        byte number = UnshownDigits[index];
        UnshownDigits.RemoveAt(index);
        return number;
    }

    public string CorrectCode()
    {
        return string.Join("", Numbers);
    }

    public string GetCountOfCorrectDigits(string input)
    {
        int countOfCorrectDigits = 0;
        for (int i = 0; i < Numbers.Length; i++)
        {
            byte thisDigit = byte.Parse(input[i].ToString());
            if (thisDigit == Numbers[i])
            {
                countOfCorrectDigits++;
            }
        }

        return $"Amount of Digits on right place is: {countOfCorrectDigits}";
    }
}

