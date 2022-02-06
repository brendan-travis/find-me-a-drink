using Core.Builders.Interfaces;

namespace Core.Builders;

public class LocationDirector
{
    public LocationDirector(ILocationBuilder locationBuilder)
    {
        LocationBuilder = locationBuilder;
    }

    private ILocationBuilder LocationBuilder { get; }

    public void BuildLocation()
    {
        this.LocationBuilder.BuildBasicInformation();
        this.LocationBuilder.BuildLocationData();
        this.LocationBuilder.BuildSocialInformation();
        this.LocationBuilder.BuildRatings();
        this.LocationBuilder.BuildTags();
    }
}