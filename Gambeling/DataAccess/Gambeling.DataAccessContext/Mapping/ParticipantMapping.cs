using Gambeling.DomainModels.Participants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gambeling.DataAccessContext.Mapping;

public class ParticipantMapping : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(30).IsRequired();
        builder.Property(c => c.SurName).HasMaxLength(30).IsRequired();
        builder.Property(c => c.SocialSecurityNumber).HasMaxLength(20).IsRequired();
        builder.OwnsOne(c => c.Account);
        builder.HasMany(c => c.BetRequests).WithOne();
    }
}
