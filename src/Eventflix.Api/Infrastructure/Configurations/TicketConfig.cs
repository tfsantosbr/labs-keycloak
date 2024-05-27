using Eventflix.Api.Application.Events;
using Eventflix.Api.Application.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventflix.Api.Infrastructure.Configurations;

public class TicketConfig : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(o => o.Id);
        builder.HasOne<Event>().WithMany().HasForeignKey(o => o.EventId);
    }
}