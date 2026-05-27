namespace TheOnlyRightProject;

public class Selection
{
    private List<string> possibleDecisions = new List<string>();

    public Selection(string[] items)
    {
        possibleDecisions.AddRange(items);
    }

    public string Select()
    {
        ConsoleKey key  = ConsoleKey.None;
        int selected = 0;
        do
        {
            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow && selected >0)
            {
                selected--;
            }
            else if(key == ConsoleKey.UpArrow&& selected >0)
            {
                selected = possibleDecisions.Count -1;
            }
            
            if (key == ConsoleKey.DownArrow&& selected < possibleDecisions.Count)
            {
                 selected ++;
            }
            else if(key == ConsoleKey.DownArrow && selected == possibleDecisions.Count -1)
            {
                selected = 0;
            }
        }while(key != ConsoleKey.Enter);

        
     return "";   
    }

    private void DrawMenu(int selected)
    {
        for(int i = 0; i< possibleDecisions.Count; i++)
        {
            if(i == selected)
                DrawSelected(possibleDecisions[i]);
            else 
                DrawUnselected(possibleDecisions[i]);
        }
    }

    private void DrawSelected(string item)
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(item);
        Console.ResetColor();
    }

    private void DrawUnselected(string item)
    {
        Console.BackgroundColor = ConsoleColor.White;
        System.Console.WriteLine(item);
        Console.ResetColor();
    }
   
}