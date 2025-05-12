using System;

public class ImportantNote : Note
{
    public override void Display()
    {
        Console.WriteLine($"*** IMPORTANT Note: {Title} - {Content} ***");
    }
}