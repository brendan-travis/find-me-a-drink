using Core.Builders.Interfaces;
using Core.Models;

namespace Core.Builders;

public class LocationBuilder : ILocationBuilder
{
    private readonly string[] _tags = {
        "dance floor",
        "free wifi",
        "food",
        "beer garden",
        "coffee",
        "breakfast",
        "live music",
        "sofas"
    };

    private readonly string[] _categories = {
        "Bar reviews",
        "Closed venues",
        "Pub reviews",
        "Other",
        "Uncategorized"
    };
    
    private Location Location { get; set; } = new Location();
    
    public void Reset()
    {
        this.Location = new Location();
    }

    public Location GetLocation()
    {
        var objectToReturn = this.Location;
        this.Reset();

        return objectToReturn;
    }

    public void BuildBasicInformation()
    {
        this.Location.Name = Faker.Company.Name();
        this.Location.Date = Faker.Identification.DateOfBirth();
        this.Location.Excerpt = Faker.Company.CatchPhrase();
        this.Location.Category = this._categories[Faker.RandomNumber.Next(4)];
    }

    public void BuildLocationData()
    {
        var rng = new Random();

        this.Location.Address = Faker.Address.StreetAddress();
        this.Location.Latitude = rng.NextDouble() * 180 - 90;
        this.Location.Longitude = rng.NextDouble() * 360 - 180;
    }

    public void BuildSocialInformation()
    {
        this.Location.Phone = Faker.Phone.Number();
        this.Location.Url = Faker.Internet.Url();
        this.Location.Thumbnail = Faker.Internet.Url();
        this.Location.Twitter = Faker.Company.Name();
    }

    public void BuildRatings()
    {
        this.Location.Rating = new Rating
        {
            Amenities = Faker.RandomNumber.Next(5),
            Atmosphere = Faker.RandomNumber.Next(5),
            Beer = Faker.RandomNumber.Next(5),
            Value = Faker.RandomNumber.Next(5)
        };
    }

    public void BuildTags()
    {
        var listOfTags = new List<string>();

        for (var i = 0; i < Faker.RandomNumber.Next(7); i++)
        {
            listOfTags.Add(this._tags[Faker.RandomNumber.Next(7)]);
        }

        this.Location.Tags = listOfTags.Distinct();
    }
}