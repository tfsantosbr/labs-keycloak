using Eventflix.Api.Application.Abstractions;
using Eventflix.Api.Database;

namespace Eventflix.Api.Application.Organizations.UseCases;

public static class CreateOrganization
{
    public static void AddCreateOrganization(this IServiceCollection services)
    {
        services.AddScoped<IHandler<Request, Response>, Handler>();
    }

    public static void UseCreateOrganization(this WebApplication app)
    {
        app.MapPost("/organizations", async (IHandler<Request, Response> handler, Request command) =>
        {
            return await handler.Handle(command);
        });
    }

    public class Handler(ApplicationDbContext dbContext) : IHandler<Request, Response>
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<Response> Handle(Request command)
        {
            var organization = Organization.Create(command.Name, command.ManagerId);

            await _dbContext.Organizations.AddAsync(organization);

            await _dbContext.SaveChangesAsync();

            return new Response(organization.Id, organization.Name, organization.ManagerId);
        }
    }

    public record Request(string Name, Guid ManagerId) : IRequest<Response>;

    public record Response(int Id, string Name, Guid ManagerId);
}
