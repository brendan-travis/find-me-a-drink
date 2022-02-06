namespace Core.Models;

public class LocationResponse
{
    public LocationResponse(IEnumerable<Location> data, int limit, int offset, int recordCount)
    {
        this.Data = data;
        this.Limit = limit;
        this.Offset = offset;
        this.RecordCount = recordCount;
    }
    
    public IEnumerable<Location> Data { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
    public int RecordCount { get; set; }
}