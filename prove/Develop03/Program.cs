using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

// Class 1: Scripture Reference
public class ScriptureReference
{
    public string Book { get; set; }
    public int StartVerse { get; set; }
    public int? EndVerse { get; set; }

    public ScriptureReference(string book, int startVerse)
    {
        Book = book;
        StartVerse = startVerse;
    }

    public ScriptureReference(string book, int startVerse, int endVerse)
    {
        Book = book;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndVerse.HasValue)
        {
            return $"{Book} {StartVerse}-{EndVerse}";
        }
        else
        {
            return $"{Book} {StartVerse}";
        }
    }
}

// Class 2: Scripture
public class Scripture
{
    public ScriptureReference Reference { get; set; }
    public string Text { get; set; }
    public List<Word> Words { get; set; }

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Text = text;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void DisplayScripture()
    {
        Console.WriteLine(Reference.ToString());
        Console.WriteLine(string.Join(" ", Words.Select(word => word.Display())));
    }

    public void HideRandomWords()
    {
        var random = new Random();
        var visibleWords = Words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count > 0)
        {
            var wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }
}

// Class 3: Word
public class Word
{
    public string Text { get; set; }
    private bool isHidden;

    public Word(string text)
    {
        Text = text;
    }

    public string Display()
    {
        if (isHidden)
        {
            return "___";
        }
        else
        {
            return Text;
        }
    }

    public void Hide()
    {
        isHidden = true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var reference = new ScriptureReference("John", 3, 16);
        var scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (true)
        {
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            var input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HideRandomWords();
        }
    }
}
