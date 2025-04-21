#nullable enable
namespace API.Helpers.Pagination;

public class UserParams
{
    private const int MaxPageSize = 50;
    public int PageNumber { get; set; } = 1;
    private int _pageSize { get; set; } = 8;

    public int PageSize
    {
        get => _pageSize; 
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    
    public string[]? Brands { get; set; } = [];
    public string[]? Calibres { get; set; } = [];
    public string[]? Dials { get; set; } = [];
    public double[]? Diameters { get; set; } = [];
    public string[]? MovementTypes { get; set; } = [];
    public string[]? WatchTypes { get; set; } = [];
    public string[]? Price { get; set; } = [];
}