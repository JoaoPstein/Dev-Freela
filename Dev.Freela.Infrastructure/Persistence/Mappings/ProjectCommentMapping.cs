using Dev.Freela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Freela.Infrastructure.Persistence.Mappings
{
    public class ProjectCommentMapping : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Project)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.IdProject)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
