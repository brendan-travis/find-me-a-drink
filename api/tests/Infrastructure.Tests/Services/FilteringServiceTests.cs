using System.Collections.Generic;
using Core.Models;
using FluentAssertions;
using Infrastructure.Services;
using Xunit;

namespace Infrastructure.Tests.Services;

public class FilteringServiceTests
{
    [Fact]
    public void FilterByAggregatedRatings_FilterOnBeerAndAmenities_GivesExpectedResults()
    {
        // Arrange
        var locations = new LocationResponse(new List<Location>
            {
                new Location
                {
                    Rating = new Rating
                    {
                        Beer = 5,
                        Amenities = 5
                    }
                },
                new Location
                {
                    Rating = new Rating
                    {
                        Beer = 1,
                        Amenities = 1
                    }
                }
            },
            0, 0, 0);
        var expected = new LocationResponse(new List<Location>
            {
                new Location
                {
                    Rating = new Rating
                    {
                        Beer = 5,
                        Amenities = 5
                    }
                }
            },
            0, 0, 0);
        var filter = new Filter
        {
            Rating = "beer,amenities",
            RatingValue = 3
        };

        // Act
        var result = this.GetSystemUnderTest().FilterByAggregatedRatings(locations, filter);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    #region Setup

    private FilteringService GetSystemUnderTest() => new FilteringService();

    #endregion
}