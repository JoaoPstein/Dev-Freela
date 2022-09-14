using Dev.Freela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Dev.Freela.Infrastructure.Persistence.Mappings
{
    [ExcludeFromCodeCoverage]
    public class SkillMapping : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
