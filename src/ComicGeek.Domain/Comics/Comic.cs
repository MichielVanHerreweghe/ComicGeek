using ComicGeek.Domain.Common;

namespace ComicGeek.Domain.Comics;

public sealed class Comic : Entity
{
    public string Name { get; set; } = default!;
    public string Synopsis { get; set; } = default!;
    public string CoverUrl { get; set; } = default!;

    private Comic() { }

    private Comic(string name, string synopsis, string coverUrl)
    {
        Name = Guard.Against
            .NullOrWhiteSpace(name, nameof(name));

        Synopsis = Guard.Against
            .NullOrWhiteSpace(synopsis, nameof(synopsis));

        CoverUrl = Guard.Against
            .NullOrWhiteSpace(coverUrl, nameof(coverUrl));
    }

    public static Result<Comic> Create(string name, string synopsis, string coverUrl)
    {
        try
        {
            Comic comic = new(name, synopsis, coverUrl);

            return Result.Succeed(comic);
        }
        catch (Exception ex)
        {
            return Result.Fail<Comic>(ex.Message);
        }
    }

    public Result Update(string name, string synopsis, string coverUrl)
    {
        Result updateNameResult = UpdateName(name);

        if (updateNameResult.IsFailure)
            return updateNameResult;

        Result updateSynopsisResult = UpdateSynopsis(synopsis);

        if (updateSynopsisResult.IsFailure)
            return updateSynopsisResult;

        Result updateCoverUrlResult = UpdateCoverUrl(coverUrl);

        if (updateCoverUrlResult.IsFailure)
            return updateCoverUrlResult;

        return Result.Succeed();
    }

    private Result UpdateName(string name)
    {
        try
        {
            Name = Guard.Against
                .NullOrWhiteSpace(name, nameof(name));

            return Result.Succeed();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }

    private Result UpdateSynopsis(string synopsis)
    {
        try
        {
            Synopsis = Guard.Against
                .NullOrWhiteSpace(synopsis, nameof(synopsis));

            return Result.Succeed();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }

    private Result UpdateCoverUrl(string coverUrl)
    {
        try
        {
            CoverUrl = Guard.Against
                .NullOrWhiteSpace(coverUrl, nameof(coverUrl));

            return Result.Succeed();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}
