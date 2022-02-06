using Core.Models;

namespace Core.Repositories;

public interface ILocationRepository
{
    /// <summary>
    /// Returns a list of locations include pagination data.
    /// </summary>
    /// <param name="pagination">Page data used to retrieve the data.</param>
    /// <param name="sorting">Information on sorting the output.</param>
    /// <param name="filter">Filters to apply on the data.</param>
    /// <returns>A <see cref="LocationResponse"/> containing 0 to many <see cref="Location"/>s and pagination data.</returns>
    Task<LocationResponse> GetLocations(
        Pagination pagination,
        Sorting? sorting = null,
        Filter? filter = null);
}