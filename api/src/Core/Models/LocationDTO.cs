namespace Core.Models;

public class LocationDTO
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Url { get; set; }
    public DateTime Date { get; set; }
    public string Excerpt { get; set; }
    public string Thumbnail { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Twitter { get; set; }
    public double Stars_Beer { get; set; }
    public double Stars_Atmosphere { get; set; }
    public double Stars_Amenities { get; set; }
    public double Stars_Value { get; set; }
    public string Tags { get; set; }
}