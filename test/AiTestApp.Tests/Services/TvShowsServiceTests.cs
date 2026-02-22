using AiTestApp.Repositories;
using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;
using AiTestApp.Services;
using NSubstitute;

namespace AiTestApp.Tests.Services;

public sealed class TvShowsServiceTests
{
    private readonly ITvShowsRepository tvShowsRepository = Substitute.For<ITvShowsRepository>();
    private readonly ITvShowModelBuilder tvShowBuilder = Substitute.For<ITvShowModelBuilder>();

    #region | TESTS: GetRandom |

    [Fact]
    public void GetRandom_ShouldReturnShow()
    {
        // Arrange
        var objUt = BuildObjUt(tvShowsRepository, tvShowBuilder);
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
    public void GetRandom_ShouldExcludeLastTitle_WhenPoolIsNotEmpty()
    {
        // Arrange
        var objUt = BuildObjUt(tvShowsRepository, tvShowBuilder);
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
    public void GetRandom_ShouldThrowException_WhenRepositoryIsEmpty()
    {
        // Arrange
        var objUt = BuildObjUt(tvShowsRepository, tvShowBuilder);
        tvShowsRepository.GetAll().Returns([]);

        // Act
        var act = () => objUt.GetRandom();

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("No TV shows found.");
    }

    #endregion

    #region | Supporting Methods |

    private static ITvShowsService BuildObjUt(ITvShowsRepository tvShowsRepository, ITvShowModelBuilder tvShowBuilder) =>
        new TvShowsService(tvShowsRepository, tvShowBuilder);

    #endregion
}
