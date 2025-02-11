using ComicGeek.Domain.Comics;
using ComicGeek.Domain.Common;
using Shouldly;

namespace ComicGeek.Domain.Tests.Comics;

public class Comic_Should
{
    private Comic _comic;

    public Comic_Should()
    {
        const string name = "Absolute Batman #001";
        const string synopsis = "BATMAN LEGEND SCOTT SNYDER AND ICONIC ARTIST NICK DRAGOTTA TRANSFORM THE DARK KNIGHT'S TALE FOR THE MODERN AGE! Without the mansion... without the money... without the butler... what's left is the Absolute Dark Knight!";
        const string coverUrl = "https://s3.amazonaws.com/comicgeeks/comics/covers/large-2463692.jpg?1734976960";

        _comic = Comic.Create(name, synopsis, coverUrl)
            .Value;
    }

    [Fact]
    public void Be_created_when_valid()
    {
        const string name = "Absolute Batman #001";
        const string synopsis = "BATMAN LEGEND SCOTT SNYDER AND ICONIC ARTIST NICK DRAGOTTA TRANSFORM THE DARK KNIGHT'S TALE FOR THE MODERN AGE! Without the mansion... without the money... without the butler... what's left is the Absolute Dark Knight!";
        const string coverUrl = "https://s3.amazonaws.com/comicgeeks/comics/covers/large-2463692.jpg?1734976960";

        Result<Comic> result = Comic.Create(name, synopsis, coverUrl);

        result.IsSuccess
            .ShouldBeTrue();

        Comic comic = result.Value;

        comic.Name
            .ShouldBe(name);

        comic.Synopsis
            .ShouldBe(synopsis);

        comic.CoverUrl
            .ShouldBe(coverUrl);
    }

    [Theory]
    [InlineData(null, "BATMAN LEGEND SCOTT SNYDER AND ICONIC ARTIST NICK DRAGOTTA TRANSFORM THE DARK KNIGHT'S TALE FOR THE MODERN AGE! Without the mansion... without the money... without the butler... what's left is the Absolute Dark Knight!", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-2463692.jpg?1734976960")]
    [InlineData("", "BATMAN LEGEND SCOTT SNYDER AND ICONIC ARTIST NICK DRAGOTTA TRANSFORM THE DARK KNIGHT'S TALE FOR THE MODERN AGE! Without the mansion... without the money... without the butler... what's left is the Absolute Dark Knight!", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-2463692.jpg?1734976960")]
    [InlineData(" ", "BATMAN LEGEND SCOTT SNYDER AND ICONIC ARTIST NICK DRAGOTTA TRANSFORM THE DARK KNIGHT'S TALE FOR THE MODERN AGE! Without the mansion... without the money... without the butler... what's left is the Absolute Dark Knight!", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-2463692.jpg?1734976960")]
    [InlineData("  ", "BATMAN LEGEND SCOTT SNYDER AND ICONIC ARTIST NICK DRAGOTTA TRANSFORM THE DARK KNIGHT'S TALE FOR THE MODERN AGE! Without the mansion... without the money... without the butler... what's left is the Absolute Dark Knight!", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-2463692.jpg?1734976960")]
    public void Not_be_created_when_invalid_name(string name, string synopsis, string coverUrl)
    {
        Result<Comic> result = Comic.Create(name, synopsis, coverUrl);

        result.IsFailure
            .ShouldBeTrue();

        result.Error
            .ShouldNotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData("Absolute Batman #001", null, "https://s3.amazonaws.com/comicgeeks/comics/covers/large-2463692.jpg?1734976960")]
    [InlineData("Absolute Batman #001", "", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-2463692.jpg?1734976960")]
    [InlineData("Absolute Batman #001", " ", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-2463692.jpg?1734976960")]
    [InlineData("Absolute Batman #001", "  ", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-2463692.jpg?1734976960")]
    public void Not_be_created_when_invalid_synopsis(string name, string synopsis, string coverUrl)
    {
        Result<Comic> result = Comic.Create(name, synopsis, coverUrl);

        result.IsFailure
            .ShouldBeTrue();

        result.Error
            .ShouldNotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData("Absolute Batman #001", "BATMAN LEGEND SCOTT SNYDER AND ICONIC ARTIST NICK DRAGOTTA TRANSFORM THE DARK KNIGHT'S TALE FOR THE MODERN AGE! Without the mansion... without the money... without the butler... what's left is the Absolute Dark Knight!", null)]
    [InlineData("Absolute Batman #001", "BATMAN LEGEND SCOTT SNYDER AND ICONIC ARTIST NICK DRAGOTTA TRANSFORM THE DARK KNIGHT'S TALE FOR THE MODERN AGE! Without the mansion... without the money... without the butler... what's left is the Absolute Dark Knight!", "")]
    [InlineData("Absolute Batman #001", "BATMAN LEGEND SCOTT SNYDER AND ICONIC ARTIST NICK DRAGOTTA TRANSFORM THE DARK KNIGHT'S TALE FOR THE MODERN AGE! Without the mansion... without the money... without the butler... what's left is the Absolute Dark Knight!", " ")]
    [InlineData("Absolute Batman #001", "BATMAN LEGEND SCOTT SNYDER AND ICONIC ARTIST NICK DRAGOTTA TRANSFORM THE DARK KNIGHT'S TALE FOR THE MODERN AGE! Without the mansion... without the money... without the butler... what's left is the Absolute Dark Knight!", "  ")]
    public void Not_be_created_when_invalid_coverurl(string name, string synopsis, string coverUrl)
    {
        Result<Comic> result = Comic.Create(name, synopsis, coverUrl);

        result.IsFailure
            .ShouldBeTrue();
    }

    [Fact]
    public void Be_updated()
    {
        const string updatedName = "Absolute Batman #002";
        const string updatedSynopsis = "Batman was born out of violence — a horrible tragedy that shaped the trajectory of his future. But when a vigilant MI6 agent starts tracking the lonely life of Bruce Wayne, he discovers the interconnectivity between a hero’s shell life and the many layers of the Black Mask Gang. It’s Batman versus Alfred Pennyworth!";
        const string updatedCoverUrl = "https://s3.amazonaws.com/comicgeeks/comics/covers/large-8081353.jpg?1734976828";

        _comic.Update(updatedName, updatedSynopsis, updatedCoverUrl);

        _comic.Name
            .ShouldBe(updatedName);

        _comic.Synopsis
            .ShouldBe(updatedSynopsis);

        _comic.CoverUrl
            .ShouldBe(updatedCoverUrl);
    }

    [Theory]
    [InlineData(null, "Batman was born out of violence — a horrible tragedy that shaped the trajectory of his future. But when a vigilant MI6 agent starts tracking the lonely life of Bruce Wayne, he discovers the interconnectivity between a hero’s shell life and the many layers of the Black Mask Gang. It’s Batman versus Alfred Pennyworth!", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-8081353.jpg?1734976828")]
    [InlineData("", "Batman was born out of violence — a horrible tragedy that shaped the trajectory of his future. But when a vigilant MI6 agent starts tracking the lonely life of Bruce Wayne, he discovers the interconnectivity between a hero’s shell life and the many layers of the Black Mask Gang. It’s Batman versus Alfred Pennyworth!", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-8081353.jpg?1734976828")]
    [InlineData(" ", "Batman was born out of violence — a horrible tragedy that shaped the trajectory of his future. But when a vigilant MI6 agent starts tracking the lonely life of Bruce Wayne, he discovers the interconnectivity between a hero’s shell life and the many layers of the Black Mask Gang. It’s Batman versus Alfred Pennyworth!", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-8081353.jpg?1734976828")]
    [InlineData("  ", "Batman was born out of violence — a horrible tragedy that shaped the trajectory of his future. But when a vigilant MI6 agent starts tracking the lonely life of Bruce Wayne, he discovers the interconnectivity between a hero’s shell life and the many layers of the Black Mask Gang. It’s Batman versus Alfred Pennyworth!", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-8081353.jpg?1734976828")]
    [InlineData("Absolute Batman #002", null, "https://s3.amazonaws.com/comicgeeks/comics/covers/large-8081353.jpg?1734976828")]
    [InlineData("Absolute Batman #002", "", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-8081353.jpg?1734976828")]
    [InlineData("Absolute Batman #002", " ", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-8081353.jpg?1734976828")]
    [InlineData("Absolute Batman #002", "  ", "https://s3.amazonaws.com/comicgeeks/comics/covers/large-8081353.jpg?1734976828")]
    [InlineData("Absolute Batman #002", "Batman was born out of violence — a horrible tragedy that shaped the trajectory of his future. But when a vigilant MI6 agent starts tracking the lonely life of Bruce Wayne, he discovers the interconnectivity between a hero’s shell life and the many layers of the Black Mask Gang. It’s Batman versus Alfred Pennyworth!", null)]
    [InlineData("Absolute Batman #002", "Batman was born out of violence — a horrible tragedy that shaped the trajectory of his future. But when a vigilant MI6 agent starts tracking the lonely life of Bruce Wayne, he discovers the interconnectivity between a hero’s shell life and the many layers of the Black Mask Gang. It’s Batman versus Alfred Pennyworth!", "")]
    [InlineData("Absolute Batman #002", "Batman was born out of violence — a horrible tragedy that shaped the trajectory of his future. But when a vigilant MI6 agent starts tracking the lonely life of Bruce Wayne, he discovers the interconnectivity between a hero’s shell life and the many layers of the Black Mask Gang. It’s Batman versus Alfred Pennyworth!", " ")]
    [InlineData("Absolute Batman #002", "Batman was born out of violence — a horrible tragedy that shaped the trajectory of his future. But when a vigilant MI6 agent starts tracking the lonely life of Bruce Wayne, he discovers the interconnectivity between a hero’s shell life and the many layers of the Black Mask Gang. It’s Batman versus Alfred Pennyworth!", "  ")]
    public void Not_be_updated_when_invalid(string name, string synopsis, string coverUrl)
    {
        Result result = _comic.Update(name, synopsis, coverUrl);

        result.IsFailure
            .ShouldBeTrue();
    }
}
