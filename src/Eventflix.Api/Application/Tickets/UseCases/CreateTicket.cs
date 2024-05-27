using Eventflix.Api.Application.Abstractions;
using Eventflix.Api.Database;

namespace Eventflix.Api.Application.Tickets.UseCases;

public static class CreateTicket
{
    public static void AddCreateTicket(this IServiceCollection services)
    {
        services.AddTransient<IHandler<Command, Response>, Handler>();
    }

    public static void UseCreateTicket(this WebApplication app)
    {
        app.MapPost("events/{eventId:int}/tickets", 
            async (IHandler<Command, Response> handler, int eventId) =>
        {
            var customerId = new Guid("4d841bc0-3c1c-4633-8b88-7bb4ad92ef0c");

            var command = new Command(eventId, customerId);

            return await handler.Handle(command);
        });
    }

    public class Handler(ApplicationDbContext dbContext) : IHandler<Command, Response>
    {
        public async Task<Response> Handle(Command command)
        {
            var ticket = Ticket.Create(command.EventId, command.CustomerId);
            
            await dbContext.Tickets.AddAsync(ticket);
            await dbContext.SaveChangesAsync();

            return new Response(ticket.Id, ticket.EventId, ticket.CustomerId);
        }
    }

    public record Command(int EventId, Guid CustomerId) : IRequest<Response>;

    public record Response(int Id, int EventId, Guid CustomerId);
}
