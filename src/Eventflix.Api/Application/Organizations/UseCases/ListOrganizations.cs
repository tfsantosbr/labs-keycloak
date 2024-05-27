using Eventflix.Api.Application.Abstractions;
using Eventflix.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Eventflix.Api.Application.Organizations.UseCases;

public static class ListOrganizations
{
    public static void AddListOrganizations(this IServiceCollection services)
    {
        services.AddScoped<IHandler<Request, IEnumerable<Response>>, Handler>();
    }

    public static void UseListOrganizations(this WebApplication app)
    {
        app.MapGet("/organizations", async (IHandler<Request, IEnumerable<Response>> handler) =>
        {
            return await handler.Handle(new Request());
        });
    }

    public class Handler(ApplicationDbContext context) : IHandler<Request, IEnumerable<Response>>
    {
        public async Task<IEnumerable<Response>> Handle(Request command)
        {
            return await context.Organizations
                .Select(o => new Response(o.Id, o.Name, o.ManagerId))
                .ToListAsync();
        }
    }

    public record Request : IRequest<IEnumerable<Response>> { }

    public record Response(int Id, string Name, Guid ManagerId);
}
