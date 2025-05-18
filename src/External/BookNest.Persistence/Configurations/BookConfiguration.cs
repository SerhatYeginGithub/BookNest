using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookNest.Persistence.Configurations;

internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(b => b.Author)
               .HasMaxLength(100);

        builder.Property(b => b.Description)
               .HasMaxLength(1000);

        builder.HasOne(b => b.Note)
               .WithOne(n => n.Book)
               .HasForeignKey<Note>(n => n.BookId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(b => b.Rating)
               .WithOne(r => r.Book)
               .HasForeignKey<Rating>(r => r.BookId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
