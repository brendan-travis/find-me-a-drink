namespace Core.Models;

public class Location
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Url { get; set; }
    public DateTime Date { get; set; }
    public string Excerpt { get; set; }
    public string Thumbnail { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Twitter { get; set; }
    public Rating Rating { get; set; }
    public IEnumerable<string> Tags { get; set; }
}