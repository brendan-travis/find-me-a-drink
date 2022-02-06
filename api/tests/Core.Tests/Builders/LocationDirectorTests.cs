using Core.Builders;
using Core.Builders.Interfaces;
using NSubstitute;
using Xunit;

namespace Core.Tests.Builders;

public class LocationDirectorTests
{
    [Fact]
    public void BuildLocation_CallsAllMethodsOnBuilder()
    {
        // Act
        this.GetSystemUnderTest().BuildLocation();
        
        // Assert
        this.LocationBuilder.Received(1).BuildBasicInformation();
        this.LocationBuilder.Received(1).BuildLocationData();
        this.LocationBuilder.Received(1).BuildSocialInformation();
        this.LocationBuilder.Received(1).BuildRatings();
        this.LocationBuilder.Received(1).BuildTags();
    }
    
    #region Setup

    private LocationDirector GetSystemUnderTest() => new LocationDirector(this.LocationBuilder);

    private ILocationBuilder LocationBuilder { get; } = Substitute.For<ILocationBuilder>();

    #endregion
}