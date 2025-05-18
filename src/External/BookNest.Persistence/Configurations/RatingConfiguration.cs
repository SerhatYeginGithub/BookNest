using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookNest.Persistence.Configurations;

internal sealed class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("Ratings");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Value)
               .IsRequired();
    }
}
