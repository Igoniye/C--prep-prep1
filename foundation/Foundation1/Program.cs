using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation1 World!");
    }
}
using System;
using System.Collections.Generic;

// Define a class for a Comment
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}

// Define a class for a Video
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public override string ToString()
    {
        return $"Title: {Title}\nAuthor: {Author}\nLength: {Length} seconds\nNumber of Comments: {GetNumberOfComments()}\nComments:\n{string.Join("\n", Comments)}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create 3-4 videos
        Video video1 = new Video("Video 1", "Author 1", 300);
        Video video2 = new Video("Video 2", "Author 2", 240);
        Video video3 = new Video("Video 3", "Author 3", 180);
        Video video4 = new Video("Video 4", "Author 4", 360);

        // Add comments to each video
        video1.AddComment(new Comment("Commenter 1", "This is a great video!"));
        video1.AddComment(new Comment("Commenter 2", "I agree, it's very informative."));
        video1.AddComment(new Comment("Commenter 3", "I didn't like it."));
        video1.AddComment(new Comment("Commenter 4", "It's okay, I guess."));

        video2.AddComment(new Comment("Commenter 1", "This video is so boring!"));
        video2.AddComment(new Comment("Commenter 2", "I know, right?"));
        video2.AddComment(new Comment("Commenter 3", "I liked it, though."));
        video2.AddComment(new Comment("Commenter 4", "It's not that bad."));

        video3.AddComment(new Comment("Commenter 1", "This is my favorite video!"));
        video3.AddComment(new Comment("Commenter 2", "Mine too!"));
        video3.AddComment(new Comment("Commenter 3", "I'm not a fan."));
        video3.AddComment(new Comment("Commenter 4", "It's alright, I guess."));

        video4.AddComment(new Comment("Commenter 1", "This video is so long!"));
        video4.AddComment(new Comment("Commenter 2", "I know, it's crazy!"));
        video4.AddComment(new Comment("Commenter 3", "I liked it, though."));
        video4.AddComment(new Comment("Commenter 4", "It's not that bad."));

        // Put each video in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Iterate through the list of videos and display each one
        foreach (Video video in videos)
        {
            Console.WriteLine(video.ToString());
            Console.WriteLine();
        }
    }
}
