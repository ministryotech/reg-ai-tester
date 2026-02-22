using AiTestApp.Repositories;
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
    private readonly ITvShowModelBuilder tvShowBuilder = Substitute.For<ITvShowModelBuilder>();
    private readonly IBookModelBuilder bookBuilder = Substitute.For<IBookModelBuilder>();
    private readonly IAlbumModelBuilder albumBuilder = Substitute.For<IAlbumModelBuilder>();

    #region | TESTS: TvShowsService |

    [Fact]
    public void GetRandomTvShow_ShouldReturnShow()
    {
        // Arrange
        var objUt = BuildTvShowsService();
        var shows = new List<TvShow> { new("Show 1", "D", "U", "G", 2024) };
        tvShowsRepository.GetAll().Returns(shows);
        var viewModel = new TvShowViewModel("Show 1", "D", "U", "G", 2024);
        tvShowBuilder.Build(shows[0]).Returns(viewModel);

        // Act
        var result = objUt.GetRandom();

        // Assert
        result.Title.Should().Be("Show 1");
    }

    [Fact]
    public void GetRandomTvShow_ShouldExcludeLastTitle_WhenPoolIsNotEmpty()
    {
        // Arrange
        var objUt = BuildTvShowsService();
        var shows = new List<TvShow>
        {
            new("Show 1", "D1", "U1", "G1", 2021),
            new("Show 2", "D2", "U2", "G2", 2022)
        };
        tvShowsRepository.GetAll().Returns(shows);
        tvShowBuilder.Build(Arg.Any<TvShow>()).Returns(callInfo =>
        {
            var s = callInfo.Arg<TvShow>();
            return new TvShowViewModel(s.Title, s.Description, s.PosterUrl, s.Genre, s.Year);
        });

        // Act
        var result = objUt.GetRandom("Show 1");

        // Assert
        result.Title.Should().Be("Show 2");
    }

    [Fact]
    public void GetRandomTvShow_ShouldThrowException_WhenRepositoryIsEmpty()
    {
        // Arrange
        var objUt = BuildTvShowsService();
        tvShowsRepository.GetAll().Returns([]);

        // Act
        var act = () => objUt.GetRandom();

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("No TV shows found.");
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
        bookBuilder.Build(books[0]).Returns(viewModel);

        // Act
        var result = objUt.GetRandom("Genre A");

        // Assert
        result.Title.Should().Be("Book 1");
        result.Genre.Should().Be("Genre A");
    }

    [Fact]
    public void GetRandomBook_ShouldThrowException_WhenNoBooksInGenre()
    {
        // Arrange
        var objUt = BuildBooksService();
        var books = new List<Book> { new("Book 1", "A", "Genre A", "D", 2024) };
        booksRepository.GetAll().Returns(books);

        // Act
        var act = () => objUt.GetRandom("Genre B");

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("No books found for genre: Genre B");
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
        albumBuilder.Build(albums[1]).Returns(viewModel);

        // Act
        var result = objUt.GetRandom("Genre B");

        // Assert
        result.Title.Should().Be("Album 2");
        result.Genre.Should().Be("Genre B");
    }

    [Fact]
    public void GetRandomAlbum_ShouldThrowException_WhenNoAlbumsFound()
    {
        // Arrange
        var objUt = BuildAlbumsService();
        albumsRepository.GetAll().Returns([]);

        // Act
        var act = () => objUt.GetRandom();

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("No albums found.");
    }

    #endregion

    #region | TESTS: DiceService |

    [Theory]
    [InlineData("d4", 1, 4)]
    [InlineData("d6", 1, 6)]
    [InlineData("d8", 1, 8)]
    [InlineData("d10", 1, 10)]
    [InlineData("d12", 1, 12)]
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

    [Fact]
    public void Roll_ShouldThrowException_WhenDieTypeIsInvalid()
    {
        // Arrange
        var objUt = BuildDiceService();

        // Act
        var act = () => objUt.Roll("d7");

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid die type*");
    }

    #endregion

    #region | Supporting Methods |

    private ITvShowsService BuildTvShowsService() => new TvShowsService(tvShowsRepository, tvShowBuilder);
    private IBooksService BuildBooksService() => new BooksService(booksRepository, bookBuilder);
    private IAlbumsService BuildAlbumsService() => new AlbumsService(albumsRepository, albumBuilder);
    private static IDiceService BuildDiceService() => new DiceService();

    #endregion
}
