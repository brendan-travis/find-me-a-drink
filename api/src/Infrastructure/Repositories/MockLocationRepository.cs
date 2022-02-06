using Core.Builders;
using Core.Models;
using Core.Repositories;

namespace Infrastructure.Repositories;

public class MockLocationRepository : IMockLocationRepository
{
    private const int NumberOfTestLocations = 100;

    public MockLocationRepository()
    {
        this.Locations = new List<Location>();
        var builder = new LocationBuilder();
        var director = new LocationDirector(builder);

        for (var i = 0; i < NumberOfTestLocations; i++)
        {
            director.BuildLocation();
            this.Locations.Add(builder.GetLocation());
        }
    }

    private IList<Location> Locations { get; set; }

    public LocationResponse GetLocations(
        Pagination pagination,
        Sorting? sorting = null,
        Filter? filter = null)
    {
        var locationEnum = this.Locations.AsEnumerable();

        if (sorting?.Rating is not null)
        {
            locationEnum = sorting.Rating.ToLowerInvariant() switch
            {
                "beer" => locationEnum.OrderByDescending(item => item.Rating.Beer),
                "atmosphere" => locationEnum.OrderByDescending(item => item.Rating.Atmosphere),
                "amenities" => locationEnum.OrderByDescending(item => item.Rating.Amenities),
                "value" => locationEnum.OrderByDescending(item => item.Rating.Value),
                _ => locationEnum
            };
        }

        if (filter is not null)
        {
            if (filter.Tags is not null)
            {
                var tags = filter.Tags.Split(',');
                locationEnum = locationEnum.Where(item =>
                    item.Tags.Any(tagA =>
                        tags.All(tagB => string.Equals(tagA, tagB, StringComparison.InvariantCultureIgnoreCase))));
            }

            if (filter.Categories is not null)
            {
                var categories = filter.Categories.Split(',');
                locationEnum = locationEnum.Where(item => categories.Any(category =>
                    string.Equals(item.Category, category, StringComparison.InvariantCultureIgnoreCase)));
            }

            if (filter.Keyword is not null)
            {
                locationEnum = locationEnum.Where(item => item.Name.Contains(filter.Keyword) ||
                                                          item.Excerpt.Contains(filter.Keyword));
            }
        }

        this.Locations = locationEnum.ToList();

        var length = this.Locations.Count;
        if (pagination.Limit + pagination.Offset > length)
        {
            pagination.Offset = length - pagination.Limit;
        }

        return new LocationResponse(this.Locations.Skip(pagination.Offset).Take(pagination.Limit), pagination.Limit,
            pagination.Offset, NumberOfTestLocations);
    }
}