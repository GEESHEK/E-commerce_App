using API.Controllers;
using API.Data.Repositories;
using API.Data.SeedData;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace API.Tests;

public class WatchTypeControllerTests
{
    private readonly Mock<IWatchTypeRepository> _watchTypeRepo;

    public WatchTypeControllerTests()
    {
        _watchTypeRepo = new Mock<IWatchTypeRepository>();
    }
    
    [Fact]
    public async Task GetWatchWatchTypes_ReturnsOkResult_WithListOfWatchTypes()
    {
        _watchTypeRepo.Setup(repo => repo.GetWatchTypes())
            .ReturnsAsync(WatchTypeSeedData.GetWatchTypeSeedData);
        var brandController = new WatchTypeController(_watchTypeRepo.Object);

        var result = await brandController.GetWatchTypes();
        
        var actionResult = Assert.IsType<ActionResult<IEnumerable<WatchType>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<List<WatchType>>(okResult.Value);
        Assert.Equal(7, returnValue.Count);
    }
}