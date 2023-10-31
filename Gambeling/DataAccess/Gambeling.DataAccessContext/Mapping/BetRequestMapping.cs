using Gambeling.DomainModels.Participants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gambeling.DataAccessContext.Mapping;

public class BetRequestMapping : IEntityTypeConfiguration<BetRequest>
{
    public void Configure(EntityTypeBuilder<BetRequest> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Account)
            .IsRequired();
        builder.Property(c => c.Points)
            .IsRequired();
        builder.Property(c => c.Number)
            .IsRequired();
        builder.Property(or => or.Status)
            .HasConversion<string>()
            .HasMaxLength(4)
            .IsUnicode(false)
            .IsRequired();
        builder.Property(c => c.RequestDate)
            .IsRequired();
    }
}
