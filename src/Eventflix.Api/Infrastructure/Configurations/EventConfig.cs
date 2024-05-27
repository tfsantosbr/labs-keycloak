using Eventflix.Api.Application.Events;
using Eventflix.Api.Application.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventflix.Api.Infrastructure.Configurations;

public class EventConfig : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(o => o.Id);
        builder.HasOne<Organization>().WithMany().HasForeignKey(o => o.OrganizationId);
    }
}
