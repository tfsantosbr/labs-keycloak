namespace Eventflix.Api.Application.Tickets;

public class Ticket
{
    public int Id { get; private set; }
    public int EventId { get; private set; }
    public Guid CustomerId { get; private set; }
    public string Code { get; private set; } = string.Empty;

    public static Ticket Create(int eventId, Guid customerId)
    {
        return new Ticket
        {
            EventId = eventId,
            CustomerId = customerId,
            Code = Guid.NewGuid().ToString()[..8]
        };
    }
}
