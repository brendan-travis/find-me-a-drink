using Core.Models;
using Core.Services;

namespace Infrastructure.Services;

public class FilteringService : IFilteringService
{
    public LocationResponse FilterByAggregatedRatings(LocationResponse locations, Filter filter)
    {
        locations.Data = locations.Data.Where(location =>
        {
            var totalValue = 0d;

            if (filter.Rating.Contains("beer"))
            {
                totalValue += location.Rating.Beer;
            }
            if (filter.Rating.Contains("amenities"))
            {
                totalValue += location.Rating.Amenities;
            }
            if (filter.Rating.Contains("atmosphere"))
            {
                totalValue += location.Rating.Atmosphere;
            }
            if (filter.Rating.Contains("value"))
            {
                totalValue += location.Rating.Value;
            }

            var aggregatedValue = totalValue / filter.Rating.Split(',').Length;

            return aggregatedValue > filter.RatingValue;
        });

        return locations;
    }
}