using ComicGeek.Domain.Comics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicGeek.Persistence.Configurations.Comics;

internal sealed class ComicConfiguration : EntityConfiguration<Comic>
{
    public override void Configure(EntityTypeBuilder<Comic> builder)
    {
        base.Configure(builder);
    }
}
