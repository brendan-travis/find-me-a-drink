using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Core.Services;
using FluentAssertions;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Xunit;

namespace Infrastructure.Tests.Services;

public class LocationServiceTests
{
    [Fact]
    public async Task GetLocations_MockDataEnabled_ReturnsFromMockRepository()
    {
        // Arrange
        var configFile = new Dictionary<string, string>
        {
            { "MockData", "true" }
        };
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configFile)
            .Build();

        var sut = this.GetSystemUnderTest(configuration);
        var pagination = new Pagination();
        var expected = new LocationResponse(new List<Location>(), 25, 0, 0);

        this.MockLocationRepository.GetLocations(pagination).Returns(expected);

        // Act
        var result = await sut.GetLocations(pagination);

        //Assert
        this.MockLocationRepository.Received(1).GetLocations(pagination);
        await this.LocationRepository.Received(0).GetLocations(pagination);
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetLocations_MockDataDisabled_ReturnsFromRealRepository()
    {
        // Arrange
        var configFile = new Dictionary<string, string>
        {
            { "MockData", "false" }
        };
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configFile)
            .Build();

        var sut = this.GetSystemUnderTest(configuration);
        var pagination = new Pagination();
        var expected = new LocationResponse(new List<Location>(), 25, 0, 0);

        this.LocationRepository.GetLocations(pagination).Returns(expected);

        // Act
        var result = await sut.GetLocations(pagination);

        //Assert
        this.MockLocationRepository.Received(0).GetLocations(pagination);
        await this.LocationRepository.Received(1).GetLocations(pagination);
        result.Should().BeEquivalentTo(expected);
    }

    #region Setup

    private LocationService GetSystemUnderTest(IConfiguration configuration) =>
        new LocationService(this.LocationRepository, this.MockLocationRepository, configuration, this.FilteringService);

    private ILocationRepository LocationRepository { get; } = Substitute.For<ILocationRepository>();

    private IMockLocationRepository MockLocationRepository { get; } = Substitute.For<IMockLocationRepository>();

    private IFilteringService FilteringService { get; } = Substitute.For<IFilteringService>();

    #endregion
}