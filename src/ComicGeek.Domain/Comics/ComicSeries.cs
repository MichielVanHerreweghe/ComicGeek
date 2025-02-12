using ComicGeek.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace ComicGeek.Domain.Comics;

public sealed class ComicSeries : Entity
{
    private List<Comic> _comics = new();

    public string Name { get; set; } = default!;

    public IReadOnlyCollection<Comic> Comics => _comics;

    /// <summary>
    /// Entity Framework Constructor
    /// </summary>
    [ExcludeFromCodeCoverage]
    private ComicSeries() { }

    private ComicSeries(string name)
    {
        Name = Guard.Against
            .NullOrWhiteSpace(name, nameof(name));
    }

    public static Result<ComicSeries> Create(string name)
    {
        try
        {
            ComicSeries comicSeries = new(name);

            return Result.Succeed(comicSeries);
        }
        catch (Exception ex)
        {
            return Result.Fail<ComicSeries>(ex.Message);
        }
    }

    public Result AddComic(Comic comic)
    {
        if (_comics.Contains(comic))
            return Result.Fail("Comic already exists in series.");

        _comics.Add(comic);

        return Result.Succeed();
    }

    public Result RemoveComic(Comic comic)
    {
        if (!_comics.Contains(comic))
            return Result.Fail("Comic not found in series.");

        _comics.Remove(comic);

        return Result.Succeed();
    }

    public Result Update(string name)
    {
        Result updateNameResult = UpdateName(name);

        if (updateNameResult.IsFailure)
            return updateNameResult;

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
}
