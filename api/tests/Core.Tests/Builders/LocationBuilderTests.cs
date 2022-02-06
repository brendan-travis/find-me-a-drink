using System;
using Core.Builders;
using Core.Models;
using FluentAssertions;
using Xunit;

namespace Core.Tests.Builders;

public class LocationBuilderTests
{
    [Fact]
    public void GetLocation_NoBuildActionsCalled_ReturnsMinimalLocation()
    {
        // Arrange
        var sut = this.GetSystemUnderTest();
        var expected = new Location();

        // Act
        var result = sut.GetLocation();

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GetLocation_CalledWithBuildBasicInformation_ReturnsExpectedLocation()
    {
        // Arrange
        var sut = this.GetSystemUnderTest();

        // Act
        sut.BuildBasicInformation();
        var result = sut.GetLocation();

        // Assert
        result.Name.Should().NotBeNull();
        result.Date.Should().NotBe(new DateTime());
        result.Excerpt.Should().NotBeNull();
        result.Category.Should().NotBeNull();
    }

    [Fact]
    public void GetLocation_CalledWithBuildLocationData_ReturnsExpectedLocation()
    {
        // Arrange
        var sut = this.GetSystemUnderTest();

        // Act
        sut.BuildLocationData();
        var result = sut.GetLocation();

        // Assert
        result.Address.Should().NotBeNull();
        result.Latitude.Should().NotBe(default);
        result.Longitude.Should().NotBe(default);
    }

    [Fact]
    public void GetLocation_CalledWithBuildSocialInformation_ReturnsExpectedLocation()
    {
        // Arrange
        var sut = this.GetSystemUnderTest();

        // Act
        sut.BuildSocialInformation();
        var result = sut.GetLocation();

        // Assert
        result.Phone.Should().NotBeNull();
        result.Url.Should().NotBeNull();
        result.Thumbnail.Should().NotBeNull();
        result.Twitter.Should().NotBeNull();
    }

    [Fact]
    public void GetLocation_CalledWithBuildRatings_ReturnsExpectedLocation()
    {
        // Arrange
        var sut = this.GetSystemUnderTest();

        // Act
        sut.BuildRatings();
        var result = sut.GetLocation();

        // Assert
        result.Rating.Should().NotBeNull();
    }

    [Fact]
    public void GetLocation_CalledWithBuildTags_ReturnsExpectedLocation()
    {
        // Arrange
        var sut = this.GetSystemUnderTest();

        // Act
        sut.BuildTags();
        var result = sut.GetLocation();

        // Assert
        result.Tags.Should().NotBeNull();
    }
    
    #region Setup

    private LocationBuilder GetSystemUnderTest() => new LocationBuilder();

    #endregion
}