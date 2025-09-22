using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        Console.WriteLine();

        // Create videos
        var video1 = new Video("C# Basics", "Alice", 300);
        var video2 = new Video("Advanced C#", "Bob", 600);
        var video3 = new Video("YouTube API Tutorial", "Charlie", 450);

        // Add comments to videos
        video1.AddComment(new Comment("John", "Great explanation!"));
        video1.AddComment(new Comment("Emma", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Liam", "I learned a lot."));

        video2.AddComment(new Comment("Olivia", "This is too advanced for me."));
        video2.AddComment(new Comment("Noah", "Excellent content!"));
        video2.AddComment(new Comment("Sophia", "Loved the examples."));
        video2.AddComment(new Comment("Mason", "Can you make more videos like this?"));

        video3.AddComment(new Comment("Ava", "I was looking for this tutorial!"));
        video3.AddComment(new Comment("Ethan", "Awesome guide."));
        video3.AddComment(new Comment("Isabella", "Thanks for sharing!"));

        // Put videos in a list
        var videos = new List<Video> { video1, video2, video3 };

        // Display info for each video
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
