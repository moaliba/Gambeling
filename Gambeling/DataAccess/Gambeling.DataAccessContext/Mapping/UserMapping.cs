using Gambeling.DomainModels.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gambeling.DataAccessContext.Mapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.UserName).HasMaxLength(30).IsRequired();
        builder.Property(c => c.Password).HasMaxLength(30).IsRequired();
        builder.Property(c => c.CreatedDate).IsRequired();
    }
}
