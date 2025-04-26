public abstract class Note
{
    public string Title { get; set; }
    public string Content { get; set; }

    public abstract void Display();
}