using Dev.Freela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Dev.Freela.Infrastructure.Persistence.Mappings
{
    [ExcludeFromCodeCoverage]
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Skills)
                .WithOne()
                .HasForeignKey(x => x.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
