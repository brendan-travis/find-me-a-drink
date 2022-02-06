using Core.Models;
using Core.Repositories;
using Core.Services;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class LocationService : ILocationService
{
    public LocationService(ILocationRepository locationRepository, IMockLocationRepository mockLocationRepository,
        IConfiguration configuration)
    {
        this.LocationRepository = locationRepository;
        this.MockLocationRepository = mockLocationRepository;
        this.Configuration = configuration;
    }

    private ILocationRepository LocationRepository { get; }

    private IMockLocationRepository MockLocationRepository { get; }

    private IConfiguration Configuration { get; }

    public async Task<LocationResponse> GetLocations(
        Pagination pagination,
        Sorting? sorting = null,
        Filter? filter = null)
    {
        if (bool.Parse(this.Configuration["MockData"]))
        {
            return this.MockLocationRepository.GetLocations(pagination, sorting, filter);
        }

        return await this.LocationRepository.GetLocations(pagination, sorting, filter);
    }
}