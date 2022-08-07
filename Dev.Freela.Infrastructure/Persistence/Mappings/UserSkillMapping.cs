using Dev.Freela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Dev.Freela.Infrastructure.Persistence.Mappings
{
    [ExcludeFromCodeCoverage]
    public class UserSkillMapping : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt);
        }
    }
}
