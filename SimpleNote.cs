using System;

public class SimpleNote : Note
{
    public override void Display()
    {
        Console.WriteLine($"Simple Note: {Title} - {Content}");
    }
}
