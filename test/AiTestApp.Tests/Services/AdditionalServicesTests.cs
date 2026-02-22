using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;
using AiTestApp.Services;
using NSubstitute;

namespace AiTestApp.Tests.Services;

public sealed class AdditionalServicesTests
{
    private readonly ITvShowsRepository tvShowsRepository = Substitute.For<ITvShowsRepository>();
    private readonly IBooksRepository booksRepository = Substitute.For<IBooksRepository>();
    private readonly IAlbumsRepository albumsRepository = Substitute.For<IAlbumsRepository>();
    private readonly IViewModelBuilder builder = Substitute.For<IViewModelBuilder>();

    #region | TESTS: TvShowsService |

    [Fact]
    public void GetRandomTvShow_ShouldReturnShow()
    {
        // Arrange
        var objUt = BuildTvShowsService();
        var shows = new List<TvShow> { new("Show 1", "D", "U", "G", 2024) };
        tvShowsRepository.GetAll().Returns(shows);
        var viewModel = new TvShowViewModel("Show 1", "D", "U", "G", 2024);
        builder.Build(shows[0]).Returns(viewModel);

        // Act
        var result = objUt.GetRandom();

        // Assert
        result.Title.Should().Be("Show 1");
    }

    #endregion

    #region | TESTS: BooksService |

    [Fact]
    public void GetRandomBook_ShouldReturnBookOfGenre()
    {
        // Arrange
        var objUt = BuildBooksService();
        var books = new List<Book>
        {
            new("Book 1", "A", "Genre A", "D", 2024),
            new("Book 2", "A", "Genre B", "D", 2024)
        };
        booksRepository.GetAll().Returns(books);
        var viewModel = new BookViewModel("Book 1", "A", "Genre A", "D", 2024);
        builder.Build(books[0]).Returns(viewModel);

        // Act
        var result = objUt.GetRandom("Genre A");

        // Assert
        result.Title.Should().Be("Book 1");
        result.Genre.Should().Be("Genre A");
    }

    #endregion

    #region | TESTS: AlbumsService |

    [Fact]
    public void GetRandomAlbum_ShouldFilterByGenre_WhenGenreProvided()
    {
        // Arrange
        var objUt = BuildAlbumsService();
        var albums = new List<Album>
        {
            new("Album 1", "A", "Genre A", "D", 2024),
            new("Album 2", "A", "Genre B", "D", 2024)
        };
        albumsRepository.GetAll().Returns(albums);
        var viewModel = new AlbumViewModel("Album 2", "A", "Genre B", "D", 2024);
        builder.Build(albums[1]).Returns(viewModel);

        // Act
        var result = objUt.GetRandom("Genre B");

        // Assert
        result.Title.Should().Be("Album 2");
        result.Genre.Should().Be("Genre B");
    }

    #endregion

    #region | TESTS: DiceService |

    [Theory]
    [InlineData("d4", 1, 4)]
    [InlineData("d20", 1, 20)]
    [InlineData("d100", 1, 100)]
    public void Roll_ShouldReturnNumberInRange(string dieType, int min, int max)
    {
        // Arrange
        var objUt = BuildDiceService();

        // Act
        var result = objUt.Roll(dieType);

        // Assert
        result.DieType.Should().Be(dieType);
        result.Result.Should().BeInRange(min, max);
    }

    #endregion

    #region | Supporting Methods |

    private TvShowsService BuildTvShowsService() => new(tvShowsRepository, builder);
    private BooksService BuildBooksService() => new(booksRepository, builder);
    private AlbumsService BuildAlbumsService() => new(albumsRepository, builder);
    private static DiceService BuildDiceService() => new();

    #endregion
}
