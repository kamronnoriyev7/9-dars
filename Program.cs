using System;
using System.Net;
using Post_CRUD.Model;
using Post_CRUD.Service;

namespace _9_dars;

internal class Program
{
     static void Main(string[] args)
    {
        RunFrontEndEvent();
    }
    
    public static void RunFrontEndEvent()
    {
        EventService eventService ;
        eventService = new EventService();
        while (true)
        {
            Console.WriteLine("1.Add new event");
            Console.WriteLine("2.Delete event");
            Console.WriteLine("3.Update event");
            Console.WriteLine("4.Get All event");
            Console.WriteLine("5.GetEventsByLocation");
            Console.WriteLine("6.GetMaxTaggedEvent");
            Console.WriteLine("7.Number of people attending");
            Console.Write("Enter choice: ");
            var input = Console.ReadLine();

            if (input == "1")
            {
                var newEvent = new Event();
                Console.Write("Enter Event title: ");
                newEvent.Title = Console.ReadLine();
                Console.Write("Enter Event location: ");
                newEvent.Location = Console.ReadLine();
                Console.Write("Enter Event date: ");
                newEvent.Date = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Event Description: ");
                Console.WriteLine("Enter number of people attending: ");
                newEvent.NumberOfPeopleAttending = int.Parse(Console.ReadLine());
                newEvent.Description = Console.ReadLine();
                Console.Write("Enter event Attendees count: ");
                var attendeesCount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Event Tags count: ");
                var tagsCount = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < attendeesCount; i++)
                {
                    Console.Write($"Enter Event attendee {i + 1}: ");
                    newEvent.Attendees.Add(Console.ReadLine());
                }

                for (int i = 0; i < tagsCount; i++)
                {
                    Console.Write($"Enter Event tag {i + 1}: ");
                    newEvent.Tags.Add(Console.ReadLine());
                }

                eventService.AddEvent(newEvent);
                Console.WriteLine("Event successfully added!");
            }

            if (input == "2")
            {
                Console.Write("Enter deleted EventId: ");
                var result = eventService.DeleteEvent(Guid.Parse(Console.ReadLine()));
                Console.WriteLine("successful deleted event!");
            }

            if (input == "3")
            {
                var result = eventService.UpdateEvent(Guid.Parse(Console.ReadLine()));
                if (result is true)
                {
                    var newEvent = new Event();
                    Console.Write("Enter Event title: ");
                    newEvent.Title = Console.ReadLine();
                    Console.Write("Enter Event location: ");
                    newEvent.Location = Console.ReadLine();
                    Console.Write("Enter Event date: ");
                    newEvent.Date = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Event Description: ");
                    newEvent.Description = Console.ReadLine();
                    Console.Write("Enter event Attendees count: ");
                    var attendeesCount = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Event Tags count: ");
                    var tagsCount = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < attendeesCount; i++)
                    {
                        Console.Write($"Enter Event attendee {i + 1}: ");
                        var  console = Console.ReadLine();
                        newEvent.Attendees.Add(console);
                    }

                    for (int i = 0; i < tagsCount; i++)
                    {
                        Console.Write($"Enter Event tag {i + 1}: ");
                        var console = Console.ReadLine();
                        newEvent.Tags.Add(console);
                    }

                    eventService.AddEvent(newEvent);
                }

                Console.WriteLine("Event successfully updated!");
            }

            if (input == "4")
            {
                foreach (var element in eventService.GetByAllEvent())
                {
                    Console.WriteLine(element.Title);
                    Console.WriteLine(element.Location);
                    Console.WriteLine(element.Date);
                    Console.WriteLine(element.Description);
                    Console.WriteLine(element.Attendees.Count);
                    Console.WriteLine(element.Tags.Count);
                    Console.WriteLine();
                }
            }

            if (input=="5")
            {
                Console.WriteLine("Enter location: ");
                var location = Console.ReadLine();
                var result = eventService.GetEventsByLocation(location);
                foreach (var element in result)
                {
                    Console.WriteLine(element.Title);
                }
            }

            if (input == "6")
            {
                var result =eventService.GetMaxTaggedEvent();
                Console.WriteLine(result);
            }

            if (input=="7")
            {
               var result= eventService.NumberOfPeopleAttending();
               Console.WriteLine(result);
            }
            
            

            Console.ReadKey();
            Console.Clear();
        }
    }
    //  public static void RunFrontEndPost()
    // {
    //     var postServis = new PostService();
    //
    //     while (true)
    //     {
    //         Console.WriteLine("1. Add a post");
    //         Console.WriteLine("2. Update a post");
    //         Console.WriteLine("3. Delete a post");
    //         Console.WriteLine("4. Get a post");
    //         Console.WriteLine("5. Get All posts");
    //         Console.Write("Enter: ");
    //         var input = Console.ReadLine();
    //
    //         if (input == "1")
    //         {
    //             var post = new Post();
    //             Console.Write("Enter post name: ");
    //             post.OwnerName = Console.ReadLine();
    //             Console.Write("Enter post description: ");
    //             post.Description = Console.ReadLine();
    //             Console.Write("Enter type: ");
    //             post.Type = Console.ReadLine();
    //             Console.Write("Enter PostedTime: ");
    //             post.PostedTime = DateTime.Parse(Console.ReadLine());
    //             Console.Write("Enter QuantityLikes: ");
    //             post.QuantityLikes = int.Parse(Console.ReadLine());
    //             Console.Write("Enter Comments count: ");
    //             var commentCount = int.Parse(Console.ReadLine());
    //             Console.Write("Enter Viewer count: ");
    //             var viewerCount = int.Parse(Console.ReadLine());
    //             for (var i = 0; i < commentCount; i++)
    //             {
    //                 Console.Write($"Enter comment {i + 1} : ");
    //                 post.Comments.Add(Console.ReadLine());
    //             }
    //
    //             for (var j = 0; j < viewerCount; j++)
    //             {
    //                 Console.Write($"Enter viewr {j + 1} : ");
    //                 post.ViewerNames.Add(Console.ReadLine());
    //             }
    //
    //             postServis.AddPost(post);
    //         }
    //         else if (input == "2")
    //         {
    //             var posts = new Post();
    //             Console.WriteLine("Enter Post ID: ");
    //             var postId = Guid.Parse(Console.ReadLine());
    //             var post = postServis.GetById(postId);
    //             var result = postServis.AddPost(post);
    //         }
    //
    //         else if (input == "3")
    //         {
    //             Console.WriteLine("Enter delete Post ID: ");
    //             var id = Guid.Parse(Console.ReadLine());
    //             var post = postServis.GetById(id);
    //             var result = postServis.DeletePost(post);
    //         }
    //         else if (input == "4")
    //         {
    //             Console.WriteLine("Enter  Post ID: ");
    //             var id = Guid.Parse(Console.ReadLine());
    //             var post = postServis.GetById(id);
    //             Console.WriteLine(post);
    //         }
    //         else if (input == "5")
    //         {
    //             var result = postServis.GetAllPosts();
    //             foreach (var element in result)
    //             {
    //                 Console.WriteLine(element);
    //             }
    //         }
    //
    //         Console.ReadKey();
    //         Console.Clear();
    //     }
    // }
}