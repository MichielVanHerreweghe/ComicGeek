using ComicGeek.Domain.Comics;
using ComicGeek.Domain.Common;
using Shouldly;

namespace ComicGeek.Domain.Tests.Comics;

public class ComicSeries_Should
{
    private ComicSeries _comicSeries;
    private Comic _comic;

    public ComicSeries_Should()
    {
        const string comicSeriesName = "Absolute Batman Vol. 1";
        const string comicName = "Absolute Batman #001";
        const string comicSynopsis = "BATMAN LEGEND SCOTT SNYDER AND ICONIC ARTIST NICK DRAGOTTA TRANSFORM THE DARK KNIGHT'S TALE FOR THE MODERN AGE! Without the mansion... without the money... without the butler... what's left is the Absolute Dark Knight!";
        const string comicCoverUrl = "https://s3.amazonaws.com/comicgeeks/comics/covers/large-2463692.jpg?1734976960";

        _comicSeries = ComicSeries.Create(comicSeriesName)
            .Value;

        _comic = Comic.Create(comicName, comicSynopsis, comicCoverUrl)
            .Value;

        _comicSeries.AddComic(_comic);

    }

    [Fact]
    public void Be_created_when_valid()
    {
        const string name = "Absolute Batman Vol. 1";

        Result<ComicSeries> result = ComicSeries.Create(name);

        result.IsSuccess
            .ShouldBeTrue();

        result.Value.Name
            .ShouldBe(name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("  ")]
    public void Not_be_created_when_name_invalid(string name)
    {
        Result<ComicSeries> result = ComicSeries.Create(name);

        result.IsFailure
            .ShouldBeTrue();
    }

    [Fact]
    public void Add_comic_when_valid()
    {
        const string comicName = "Absolute Batman #002";
        const string comicSynopsis = "Batman was born out of violence — a horrible tragedy that shaped the trajectory of his future. But when a vigilant MI6 agent starts tracking the lonely life of Bruce Wayne, he discovers the interconnectivity between a hero’s shell life and the many layers of the Black Mask Gang. It’s Batman versus Alfred Pennyworth!";
        const string comicCoverUrl = "https://s3.amazonaws.com/comicgeeks/comics/covers/large-8081353.jpg?1734976828";

        Comic comic = Comic.Create(comicName, comicSynopsis, comicCoverUrl)
            .Value;

        Result result = _comicSeries.AddComic(comic);

        result.IsSuccess
            .ShouldBeTrue();
    }

    [Fact]
    public void Not_add_comic_when_comic_already_exists()
    {
        Result result = _comicSeries.AddComic(_comic);

        result.IsFailure
            .ShouldBeTrue();
    }

    [Fact]
    public void Remove_comic_when_valid()
    {
        Result result = _comicSeries.RemoveComic(_comic);

        result.IsSuccess
            .ShouldBeTrue();
    }

    [Fact]
    public void Not_remove_comic_when_not_exists()
    {
        const string comicName = "Absolute Batman #002";
        const string comicSynopsis = "Batman was born out of violence — a horrible tragedy that shaped the trajectory of his future. But when a vigilant MI6 agent starts tracking the lonely life of Bruce Wayne, he discovers the interconnectivity between a hero’s shell life and the many layers of the Black Mask Gang. It’s Batman versus Alfred Pennyworth!";
        const string comicCoverUrl = "https://s3.amazonaws.com/comicgeeks/comics/covers/large-8081353.jpg?1734976828";

        Comic comic = Comic.Create(comicName, comicSynopsis, comicCoverUrl)
            .Value;

        Result result = _comicSeries.RemoveComic(comic);

        result.IsFailure
            .ShouldBeTrue();
    }

    [Fact]
    public void Update_when_valid()
    {
        const string name = "Absolute Batman Vol. 2";

        Result result = _comicSeries.Update(name);

        result.IsSuccess
            .ShouldBeTrue();

        _comicSeries.Name
            .ShouldBe(name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("  ")]
    public void Not_update_when_invalid(string name)
    {
        Result result = _comicSeries.Update(name);

        result.IsFailure
            .ShouldBeTrue();
    }
}
