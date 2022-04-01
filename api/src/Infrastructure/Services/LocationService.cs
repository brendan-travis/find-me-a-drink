using Core.Models;
using Core.Repositories;
using Core.Services;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class LocationService : ILocationService
{
    public LocationService(ILocationRepository locationRepository, IMockLocationRepository mockLocationRepository,
        IConfiguration configuration, IFilteringService filteringService)
    {
        this.LocationRepository = locationRepository;
        this.MockLocationRepository = mockLocationRepository;
        this.Configuration = configuration;
        this.FilteringService = filteringService;
    }

    private ILocationRepository LocationRepository { get; }

    private IMockLocationRepository MockLocationRepository { get; }

    private IConfiguration Configuration { get; }
    
    private IFilteringService FilteringService { get; }

    public async Task<LocationResponse> GetLocations(
        Pagination pagination,
        Sorting? sorting = null,
        Filter? filter = null)
    {
        LocationResponse result;
        
        if (bool.Parse(this.Configuration["MockData"]))
        {
            result = this.MockLocationRepository.GetLocations(pagination, sorting, filter);
        }
        else
        {
            result = await this.LocationRepository.GetLocations(pagination, sorting, filter);
        }

        if (filter?.Rating is not null)
        {
            result = this.FilteringService.FilterByAggregatedRatings(result, filter);
        }

        return result;
    }
}