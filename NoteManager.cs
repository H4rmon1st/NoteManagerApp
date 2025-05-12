using System;
using System.Collections.Generic;
using System.IO;

public class NoteManager
{
    private readonly List<Note> _notes = new List<Note>();
    private readonly List<INotifier> _notifiers = new List<INotifier>();
    private const string FilePath = "notes.txt";

    public NoteManager()
    {
        LoadNotesFromFile();
    }

    public void AddNotifier(INotifier notifier)
    {
        _notifiers.Add(notifier);
    }

    public void AddNote(Note note)
    {
        _notes.Add(note);
        SaveNotesToFile();
        NotifyAll($"Nota adaugata: {note.Title}");
    }

    public void RemoveNote(Note note)
    {
        _notes.Remove(note);
        SaveNotesToFile();
        NotifyAll($"Nota stearsa: {note.Title}");
    }

    public void DisplayNotes()
    {
        if (_notes.Count == 0)
        {
            Console.WriteLine("Nu exista note salvate.");
            return;
        }

        Console.WriteLine("\n=== Lista de Note ===");
        foreach (var note in _notes)
        {
            note.Display();
        }
    }

    private void NotifyAll(string message)
    {
        foreach (var notifier in _notifiers)
        {
            notifier.Notify(message);
        }
    }

    private void SaveNotesToFile()
    {
        try
        {
            List<string> lines = new List<string>();
            foreach (var note in _notes)
            {
                string type = (note is ImportantNote) ? "Important" : "Simple";
                lines.Add(type + "|" + note.Title + "|" + note.Content);
            }

            File.WriteAllLines(FilePath, lines.ToArray());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la salvarea notelor: {ex.Message}");
        }
    }

    private void LoadNotesFromFile()
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                return;
            }

            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    var type = parts[0];
                    var title = parts[1];
                    var content = parts[2];

                    try
                    {
                        var note = NoteFactory.CreateNote(type, title, content);
                        _notes.Add(note);
                    }
                    catch
                    {
                        // Ignoram notele corupte
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la incarcarea notelor: {ex.Message}");
        }
    }

    public Note FindNoteByTitle(string title)
    {
        foreach (var note in _notes)
        {
            if (note.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                return note;
        }
        return null;
    }
}
