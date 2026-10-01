using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {     
        Video video1 = new Video("Learning C# Classes", "Mercy Ani", 600);
        Video video2 = new Video("How to bake cake", "Jane Mary", 480);
        Video video3 = new Video("How to Build a Website", "Uzochukwu Ilobinso", 720);
      
        video1.Comments.Add(new Comment("Blessing", "This video was very insightful."));
        video1.Comments.Add(new Comment("Chekwube", "wow! I learned a lot from this."));
        video1.Comments.Add(new Comment("Johnson", "Great explanation!"));
        video1.Comments.Add(new Comment("Joshua", "I will watch this again."));
    
        video2.Comments.Add(new Comment("Mercy", "I really enjoyed this video."));
        video2.Comments.Add(new Comment("James", "Very easy to understand."));
        video2.Comments.Add(new Comment("Grace", "I will surely bake this weekened."));
        video2.Comments.Add(new Comment("Pauline", "This helped me really."));
      
        video3.Comments.Add(new Comment("Michael", "The website looks great."));
        video3.Comments.Add(new Comment("Ebube", "Very useful tutorial."));
        video3.Comments.Add(new Comment("John", "I learned something new."));
        video3.Comments.Add(new Comment("Okechukwu", "Nice video!"));

       
        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3
        };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"{comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}