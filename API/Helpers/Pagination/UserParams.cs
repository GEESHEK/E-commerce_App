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
    
    public string? Brand { get; set; }
    public string? WatchType { get; set; }
}