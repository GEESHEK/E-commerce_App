using API.Controllers;
using API.Data.Repositories;
using API.Data.SeedData.Watch;
using API.Entities.Watch;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace API.Tests;

public class BrandControllerTests
{
    private readonly Mock<IBrandRepository> _brandRepo;

    public BrandControllerTests()
    {
        _brandRepo = new Mock<IBrandRepository>();
    }

    [Fact]
    public async Task GetWatchBrands_ReturnsOkResult_WithListOfBrands()
    {
        _brandRepo.Setup(repo => repo.GetBrands())
            .ReturnsAsync(BrandSeedData.GetBrandSeedData);
        var brandController = new BrandController(_brandRepo.Object);

        var result = await brandController.GetWatchBrands();
        
        var actionResult = Assert.IsType<ActionResult<IEnumerable<Brand>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<List<Brand>>(okResult.Value);
        Assert.Equal(5, returnValue.Count);
    }
}