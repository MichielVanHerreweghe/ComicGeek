using ComicGeek.Domain.Comics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicGeek.Persistence.Configurations.Comics;

internal sealed class ComicSeriesConfiguration : EntityConfiguration<ComicSeries>
{
    public override void Configure(EntityTypeBuilder<ComicSeries> builder)
    {
        base.Configure(builder);

        builder.HasMany(x => x.Comics)
            .WithOne();
    }
}
