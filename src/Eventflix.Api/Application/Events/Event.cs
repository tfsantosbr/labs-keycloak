namespace Eventflix.Api.Application.Events;

public class Event
{
    private Event() { }

    public int Id { get; private set; }
    public int OrganizationId { get; private set; }
    public string Name { get; private set; } = string.Empty;

    public static Event Create(int organizationId, string name)
    {
        return new Event
        {
            OrganizationId = organizationId,
            Name = name
        };
    }

    public void Update(string name)
    {
        Name = name;
    }
}
