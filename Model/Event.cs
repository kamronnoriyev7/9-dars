namespace Post_CRUD.Model;

public class Event
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Location { get; set; }
    
    public DateTime Date { get; set; }
    
    public string Description{ get; set; }

    public List<string> Attendees { get; set; } = new List<string>();

    public List<string> Tags { get; set; } = new List<string>();
    public int NumberOfPeopleAttending { get; set; }

    public Event()
    {
        Id = Guid.NewGuid();
        Title = Title;
        Location = Location;
        Date = DateTime.Now;
        Description = Description;
        Attendees = Attendees;
        Tags = Tags;
        NumberOfPeopleAttending = NumberOfPeopleAttending;

        
    }


}