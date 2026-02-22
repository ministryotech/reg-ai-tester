using AiTestApp.Repositories;
using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;
using AiTestApp.Services;
using NSubstitute;

namespace AiTestApp.Tests.Services;

public sealed class AlbumsServiceTests
{
    private readonly IAlbumsRepository albumsRepository = Substitute.For<IAlbumsRepository>();
    private readonly IAlbumModelBuilder albumBuilder = Substitute.For<IAlbumModelBuilder>();

    #region | TESTS: GetRandom |

    [Fact]
    public void GetRandom_ShouldFilterByGenre_WhenGenreProvided()
    {
        // Arrange
        var objUt = BuildObjUt(albumsRepository, albumBuilder);
        var albums = new List<Album>
        {
            new("Album 1", "A", "Genre A", "D", 2024),
            new("Album 2", "A", "Genre B", "D", 2024)
        };
        albumsRepository.GetAll().Returns(albums);
        var viewModel = new AlbumViewModel("Album 2", "A", "Genre B", "D", 2024);
        albumBuilder.Build(albums[1]).Returns(viewModel);

        // Act
        var result = objUt.GetRandom("Genre B");

        // Assert
        result.Title.Should().Be("Album 2");
        result.Genre.Should().Be("Genre B");
    }

    [Fact]
    public void GetRandom_ShouldThrowException_WhenNoAlbumsFound()
    {
        // Arrange
        var objUt = BuildObjUt(albumsRepository, albumBuilder);
        albumsRepository.GetAll().Returns([]);

        // Act
        var act = () => objUt.GetRandom();

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("No albums found.");
    }

    #endregion

    #region | Supporting Methods |

    private static IAlbumsService BuildObjUt(IAlbumsRepository albumsRepository, IAlbumModelBuilder albumBuilder) =>
        new AlbumsService(albumsRepository, albumBuilder);

    #endregion
}
