using Core.Models;

namespace Core.Builders.Interfaces;

public interface ILocationBuilder
{
    /// <summary>
    /// Adds the very basic information needed on a location.
    /// Includes name, date, excerpt and category.
    /// </summary>
    void BuildBasicInformation();
    
    /// <summary>
    /// Adds locations data to the location.
    /// Includes address, latitude and longitude.
    /// </summary>
    void BuildLocationData();
    
    /// <summary>
    /// Adds social information to the location.
    /// Includes phone, URL, thumbnail and Twitter.
    /// </summary>
    void BuildSocialInformation();
    
    /// <summary>
    /// Adds rating information to the location.
    /// Includes amenities, atmosphere, beer and value.
    /// </summary>
    void BuildRatings();
    
    /// <summary>
    /// Adds tags to the location.
    /// </summary>
    void BuildTags();
}