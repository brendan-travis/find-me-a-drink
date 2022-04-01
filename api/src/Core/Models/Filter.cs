namespace Core.Models;

public class Filter
{
    public string? Tags { get; set; }
    public string? Categories { get; set; }
    public string? Keyword { get; set; }
    public string? Rating { get; set; }
    public double? RatingValue { get; set; }
}