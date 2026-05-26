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
        
    }

    private void DrawUnselected(string item)
    {
        System.Console.WriteLine(item);
    }
   
}