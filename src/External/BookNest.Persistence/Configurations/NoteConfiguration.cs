using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookNest.Persistence.Configurations;

internal sealed class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("Notes");
        builder.HasKey(t => t.Id);
        builder.Property(n => n.Content)
               .HasMaxLength(2000);
    }
}
