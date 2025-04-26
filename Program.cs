using System;

class Program
{
    static void Main()
    {
        var manager = new NoteManager();
        manager.AddNotifier(new ConsoleNotifier());

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Note Manager ===");
            Console.WriteLine("1. Adauga Nota");
            Console.WriteLine("2. Afiseaza Note");
            Console.WriteLine("3. Sterge Nota");
            Console.WriteLine("4. Iesire");
            Console.Write("Alege o optiune: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddNoteFromUser(manager);
                    break;
                case "2":
                    manager.DisplayNotes();
                    break;
                case "3":
                    DeleteNoteFromUser(manager);
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Optiune invalida. Incearca din nou.");
                    break;
            }
        }
    }

    static void AddNoteFromUser(NoteManager manager)
    {
        Console.WriteLine("\nAlege tipul notei:");
        Console.WriteLine("1. Simple Note");
        Console.WriteLine("2. Important Note");
        Console.Write("Introdu alegerea ta (1 sau 2): ");
        string choice = Console.ReadLine();

        string type = null;
        if (choice == "1")
            type = "Simple";
        else if (choice == "2")
            type = "Important";

        if (type == null)
        {
            Console.WriteLine("Tip de nota invalid. Incearca din nou.");
            return;
        }

        Console.Write("Introdu titlul notei: ");
        string title = Console.ReadLine();

        Console.Write("Introdu continutul notei: ");
        string content = Console.ReadLine();

        try
        {
            var note = NoteFactory.CreateNote(type, title, content);
            manager.AddNote(note);
            Console.WriteLine("Nota a fost adaugata cu succes!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la adaugarea notei: {ex.Message}");
        }
    }

    static void DeleteNoteFromUser(NoteManager manager)
    {
        Console.Write("Introdu titlul notei de sters: ");
        string title = Console.ReadLine();

        var note = manager.FindNoteByTitle(title);

        if (note != null)
        {
            manager.RemoveNote(note);
            Console.WriteLine("Nota a fost stearsa cu succes!");
        }
        else
        {
            Console.WriteLine("Nota nu a fost gasita.");
        }
    }
}
