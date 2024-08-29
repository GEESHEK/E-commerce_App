using API.Data.Repositories;

namespace API.Controllers;

public class OrderController : BaseApiController
{
    private readonly IWatchRepository _watchRepository;

    public OrderController(IWatchRepository watchRepository)
    {
        _watchRepository = watchRepository;
    }
    
    
}