using Eventflix.Api.Application.Events;
using Eventflix.Api.Application.Organizations;
using Eventflix.Api.Application.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Eventflix.Api.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
}
