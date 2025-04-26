using System;

public static class NoteFactory
{
    public static Note CreateNote(string type, string title, string content)
    {
        if (type == "Simple")
            return new SimpleNote { Title = title, Content = content };
        else if (type == "Important")
            return new ImportantNote { Title = title, Content = content };
        else
            throw new ArgumentException("Tip de notă invalid.");
    }
}
