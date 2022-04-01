using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

/// <summary>
/// Gather information on various locations
/// </summary>
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    /// <inheritdoc />
    public LocationsController(ILocationService locationService)
    {
        this.LocationService = locationService;
    }

    private ILocationService LocationService { get; }

    /// <summary>
    /// Get information about various locations.
    /// Allows pagination, sorting and filtering with query parameters.
    /// </summary>
    /// <param name="limit">The limit of items per page.</param>
    /// <param name="offset">The offset at which to start the new result set.</param>
    /// <param name="sortByRating">The rating to sort by.</param>
    /// <param name="tagFilter">The tags to filter on. Comma seperated and applies an AND conjunction.</param>
    /// <param name="categoryFilter">The categories to filter on. Comma seperated and applies an OR conjunction.</param>
    /// <param name="keywordFilter">An open text search field to search on.</param>
    /// <returns>A <see cref="LocationResponse"/> containing 0 to many <see cref="Location"/>s and pagination data.</returns>
    [ProducesResponseType(200)]
    [HttpGet]
    public async Task<IActionResult> GetLocations(
        [FromQuery] int limit = 20,
        [FromQuery] int offset = 0,
        [FromQuery(Name = "sort_by_rating")] string? sortByRating = null,
        [FromQuery(Name = "tag_filter")] string? tagFilter = null,
        [FromQuery(Name = "category_filter")] string? categoryFilter = null,
        [FromQuery(Name = "keyword_filter")] string? keywordFilter = null,
        [FromQuery(Name = "rating_filter")] string? ratingFilter = null,
        [FromQuery(Name = "rating_value_filter")] double? ratingValueFilter = null)
    {
        var pagination = new Pagination
        {
            Limit = limit,
            Offset = offset
        };
        var sorting = new Sorting
        {
            Rating = sortByRating
        };
        var filter = new Filter
        {
            Tags = tagFilter,
            Categories = categoryFilter,
            Keyword = keywordFilter,
            Rating = ratingFilter,
            RatingValue = ratingValueFilter
        };

        var locations = await this.LocationService.GetLocations(pagination, sorting, filter);

        return this.Ok(locations);
    }
}