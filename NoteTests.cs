using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class NoteFactoryTests
{
    [TestMethod]
    public void CreateNote_ShouldCreateSimpleNote_WhenTypeIsSimple()
    {
        string type = "Simple";
        string title = "Test Note";
        string content = "Test Content";

        var note = NoteFactory.CreateNote(type, title, content);

        Assert.IsInstanceOfType(note, typeof(SimpleNote));
        Assert.AreEqual(title, note.Title);
        Assert.AreEqual(content, note.Content);
    }
}

[TestClass]
public class NoteManagerTests
{
    [TestMethod]
    public void AddNote_ShouldAddAndFindNoteByTitle()
    {
        var manager = new NoteManager();
        var note = new SimpleNote { Title = "Test Find Note", Content = "Some Content" };

        manager.AddNote(note);
        var foundNote = manager.FindNoteByTitle("Test Find Note");

        Assert.IsNotNull(foundNote);
        Assert.AreEqual(note.Title, foundNote.Title);
        Assert.AreEqual(note.Content, foundNote.Content);
    }
}
