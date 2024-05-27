using Eventflix.Api.Application.Abstractions;
using Eventflix.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Eventflix.Api.Application.Events.UseCases;

public static class ListEvents
{
    public static void AddListEvents(this IServiceCollection services)
    {
        services.AddScoped<IHandler<Request, IEnumerable<Response>>, Handler>();
    }

    public static void UseListEvents(this WebApplication app)
    {
        app.MapGet("events", async (IHandler<Request, IEnumerable<Response>> handler) =>
        {
            return await handler.Handle(new Request());
        })
        .RequireAuthorization();
    }

    public class Handler(ApplicationDbContext dbContext) : IHandler<Request, IEnumerable<Response>>
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Response>> Handle(Request request)
        {
            return await _dbContext.Events
                .Select(e => new Response(e.Id, e.OrganizationId, e.Name))
                .ToListAsync();
        }
    }

    public record Request() : IRequest<IEnumerable<Response>>;
    public record Response(int Id, int OrganizationId, string Name);
}
