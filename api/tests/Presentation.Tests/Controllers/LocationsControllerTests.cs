using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Presentation.Controllers;
using Xunit;

namespace Presentation.Tests.Controllers;

public class LocationsControllerTests
{
    [Fact]
    public async Task GetLocations_CalledWithValidParameters_ReturnsDataFromLocationService()
    {
        // Arrange
        var sut = this.GetSystemUnderTest();
        var data = new LocationResponse(new List<Location>(), 5, 0, 0);

        this.LocationService.GetLocations(Arg.Any<Pagination>(), Arg.Any<Sorting>(), Arg.Any<Filter>()).Returns(data);

        // Act
        var result = await sut.GetLocations();

        // Assert
        result.Should().BeOfType(typeof(OkObjectResult));
        ((OkObjectResult)result).Value.Should().BeEquivalentTo(data);
    }

    #region Setup

    private LocationsController GetSystemUnderTest() => new LocationsController(this.LocationService);

    private ILocationService LocationService { get; } = Substitute.For<ILocationService>();

    #endregion
}