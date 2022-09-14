using Dev.Freela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Dev.Freela.Infrastructure.Persistence.Mappings
{
    [ExcludeFromCodeCoverage]
    public class ProjectMapping : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Freelancer)
                .WithMany(x => x.FreelanceProjects)
                .HasForeignKey(x => x.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Client)
                .WithMany(x => x.OwnedProjects)
                .HasForeignKey(x => x.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
