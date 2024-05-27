using Eventflix.Api.Application.Abstractions;
using Eventflix.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Eventflix.Api.Application.Events.UseCases;

public static class ListOrganizationEvents
{
    public static void AddListOrganizationEvents(this IServiceCollection services)
    {
        services.AddScoped<IHandler<Request, IEnumerable<Response>>, Handler>();
    }

    public static void UseListOrganizationEvents(this WebApplication app)
    {
        app.MapGet("organizations/{organizationId:int}/events", 
            async (int organizationId, IHandler<Request, IEnumerable<Response>> handler) =>
        {
            return await handler.Handle(new Request(organizationId));
        });
    }

    public class Handler(ApplicationDbContext dbContext) : IHandler<Request, IEnumerable<Response>>
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Response>> Handle(Request request)
        {
            return await _dbContext.Events
                .Where(e => e.OrganizationId == request.OrganizationId)
                .Select(e => new Response(e.Id, e.OrganizationId, e.Name))
                .ToListAsync();
        }
    }

    public record Request(int OrganizationId) : IRequest<IEnumerable<Response>>;
    public record Response(int Id, int OrganizationId, string Name);
}
