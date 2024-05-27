using Eventflix.Api.Application.Abstractions;
using Eventflix.Api.Database;

namespace Eventflix.Api.Application.Events.UseCases;

public static class CreateEvent
{
    public static void AddCreateEvent(this IServiceCollection services)
    {
        services.AddScoped<IHandler<Command, Response>, Handler>();
    }

    public static void UseCreateEvent(this WebApplication app)
    {
        app.MapPost("organizatons/{organizationId:int}/events", 
            async (IHandler<Command, Response> handler, int organizationId, Request request) =>
        {
            var command = new Command(organizationId, request.Name);

            return await handler.Handle(command);
        });
    }

    public class Handler(ApplicationDbContext dbContext) : IHandler<Command, Response>
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<Response> Handle(Command command)
        {
            var @event = Event.Create(command.OrganizationId, command.Name);

            await _dbContext.Events.AddAsync(@event);

            await _dbContext.SaveChangesAsync();

            return new Response(@event.Id, @event.OrganizationId, @event.Name);
        }
    }

    public record Request(string Name);
    public record Command(int OrganizationId, string Name) : IRequest<Response>;
    public record Response(int Id, int OrganizationId, string Name);

}
