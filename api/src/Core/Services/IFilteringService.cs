using Core.Models;

namespace Core.Services;

public interface IFilteringService
{
    LocationResponse FilterByAggregatedRatings(LocationResponse locations, Filter filter);
}