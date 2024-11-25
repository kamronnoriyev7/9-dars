using Post_CRUD.Model;

namespace Post_CRUD.Service;

public class EventService
{
    public List<Event> eventList;

    public EventService()
    {
        eventList = new List<Event>();
    }

    public Event AddEvent(Event newEvent)
    {
        newEvent.Id = Guid.NewGuid();
        eventList.Add(newEvent);

        return newEvent;
    }

    public bool UpdateEvent(Guid idEvent)
    {
        var eventGet = GetByEvent(idEvent);
        var eventRemove = eventList.Remove(eventGet);
        return eventRemove;

    }

    public bool DeleteEvent(Guid idEvent)
    {
        var eventGet = GetByEvent(idEvent);
        var eventRemove = eventList.Remove(eventGet);
        return eventRemove;
    }

    public List<Event> GetByAllEvent()
    {
        return eventList;
    }
    
    public Event GetByEvent(Guid eventId)
    {
        foreach (var element in eventList)
        {
            if (element.Id == eventId)
            {
                return element;
            }
        }
        return null;
    }

    public List<Event> GetEventsByLocation(string location)
    {
        var list = new List<Event>();
        foreach (var element in eventList)
        {
            if (element.Location==location)
            {
                list.Add(element);
            }
        }

        return list;
    }

    
    
}