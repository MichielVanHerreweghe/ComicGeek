using ComicGeek.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicGeek.Persistence.Configurations;

internal class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(typeof(T).Name);

        builder.Property(x => x.IsEnabled)
            .IsRequired()
            .HasDefaultValue(true)
            .ValueGeneratedNever();

        builder.Property(x => x.CreatedAt)
            .HasDefaultValue("GETUTCDATE()");

        builder.Property(x => x.UpdatedAt)
            .HasDefaultValue("GETUTCDATE()")
            .IsConcurrencyToken();
    }
}
