using System.Text;
using Core.Factories;
using Core.Models;
using Core.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
    public LocationRepository(IDbConnectionFactory dbConnectionFactory)
    {
        this.DbConnectionFactory = dbConnectionFactory;
    }

    private IDbConnectionFactory DbConnectionFactory { get; }

    public async Task<LocationResponse> GetLocations(
        Pagination pagination,
        Sorting? sorting = null,
        Filter? filter = null)
    {
        var dataQuery = new StringBuilder();
        var countQuery = new StringBuilder();
        
        dataQuery.AppendLine("SELECT * FROM locations");
        countQuery.AppendLine("SELECT COUNT(name) FROM locations");

        if (filter is not null)
        {
            var initialWhere = true;

            if (filter.Tags is not null)
            {
                foreach (var tag in filter.Tags.Split(','))
                {
                    dataQuery.AppendLine($"{(initialWhere ? "WHERE" : "AND")} tags like '%{tag}%'");
                    countQuery.AppendLine($"{(initialWhere ? "WHERE" : "AND")} tags like '%{tag}%'");
                    initialWhere = false;
                }
            }

            if (filter.Categories is not null)
            {
                var initialCategory = true;
                foreach (var category in filter.Categories.Split(','))
                {
                    var conjunction = initialCategory ? "AND" : "OR";
                    dataQuery.AppendLine($"{(initialWhere ? "WHERE" : conjunction)} category like '%{category}%'");
                    countQuery.AppendLine($"{(initialWhere ? "WHERE" : conjunction)} category like '%{category}%'");
                    initialCategory = false;
                    initialWhere = false;
                }
            }

            if (filter.Keyword is not null)
            {
                dataQuery.AppendLine($"{(initialWhere ? "WHERE" : "AND")} (name like '%{filter.Keyword}%' OR excerpt like '%{filter.Keyword}%')");
                countQuery.AppendLine($"{(initialWhere ? "WHERE" : "AND")} (name like '%{filter.Keyword}%' OR excerpt like '%{filter.Keyword}%')");
            }
        }

        if (sorting?.Rating is not null)
        {
            switch (sorting.Rating.ToLowerInvariant())
            {
                case "beer":
                    dataQuery.AppendLine("ORDER BY stars_beer DESC");
                    break;
                case "atmosphere":
                    dataQuery.AppendLine("ORDER BY stars_atmosphere DESC");
                    break;
                case "amenities":
                    dataQuery.AppendLine("ORDER BY stars_amenities DESC");
                    break;
                case "value":
                    dataQuery.AppendLine("ORDER BY stars_value DESC");
                    break;
            }
        }

        dataQuery.AppendLine($"LIMIT {pagination.Limit} OFFSET {pagination.Offset};");

        using var connection = this.DbConnectionFactory.GetConnection();
        var totalRecords = await connection.QueryAsync<int>(countQuery.ToString());
        var result = await connection.QueryAsync<LocationDTO>(dataQuery.ToString());
        var data = result.Select(data => new Location
        {
            Name = data.Name,
            Category = data.Category,
            Url = data.Url,
            Date = data.Date,
            Excerpt = data.Excerpt,
            Thumbnail = data.Thumbnail,
            Latitude = data.Lat,
            Longitude = data.Lng,
            Address = data.Address,
            Phone = data.Phone,
            Twitter = data.Twitter,
            Rating = new Rating
            {
                Beer = data.Stars_Beer,
                Atmosphere = data.Stars_Atmosphere,
                Amenities = data.Stars_Amenities,
                Value = data.Stars_Value
            },
            Tags = data.Tags.Split(',')
        });

        return new LocationResponse(data, pagination.Limit, pagination.Offset, totalRecords.FirstOrDefault());
    }
}