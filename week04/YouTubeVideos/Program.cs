using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating video objects
        Video video1 = new Video("Introduction to C#", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great introduction!"));
        video1.AddComment(new Comment("Bob", "Very informative, thanks!"));
        video1.AddComment(new Comment("Charlie", "Looking forward to more videos!"));

        Video video2 = new Video("OOP in C#", "Jane Smith", 900);
        video2.AddComment(new Comment("David", "Nice explanation of OOP concepts."));
        video2.AddComment(new Comment("Eve", "Can you cover inheritance in detail?"));
        video2.AddComment(new Comment("Frank", "Helped me a lot, thanks!"));

        Video video3 = new Video("LINQ Tutorial", "Robert Brown", 750);
        video3.AddComment(new Comment("Grace", "LINQ looks powerful!"));
        video3.AddComment(new Comment("Hannah", "Can you show more examples?"));
        video3.AddComment(new Comment("Ian", "This will save me so much time!"));

        // Storing videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Displaying video details
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}