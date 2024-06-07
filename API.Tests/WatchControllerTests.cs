using API.Controllers;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace API.Tests;

public class WatchControllerTests
{
    private readonly IMapper _mapper;
    
    public WatchControllerTests()
    {
        var myProfile = new AutomapperProfiles();
        var configuration = new MapperConfiguration(config => config.AddProfile(myProfile));
        _mapper = new Mapper(configuration);
    }
    
    [Fact]
    public async Task GetWatches_ReturnsOkResult_WithListOFWatches()
    {
        // Arrange
        var watchRepo = new Mock<IWatchRepository>();

        // var mockMapper = new Mock<IMapper>();
        watchRepo.Setup(repo => repo.GetWatchesAsync())
            .ReturnsAsync(GetTestWatches());
        var watchController = new WatchController(watchRepo.Object, _mapper);
        // var watchController = new WatchController(watchRepo.Object, mockMapper.Object);
        
        // Act
        var result = await watchController.GetWatches();
        
        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<Watch>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<List<Watch>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }
    
    // [Fact]
    // public async Task GetWatch_ReturnsNotFoundResult_WhenWatchDoesNotExist()
    // {
    //     // Arrange
    //     var watchRepo = new Mock<IWatchRepository>();
    //     watchRepo.Setup(repo => repo.GetWatchByIdAsync(10))
    //         .ReturnsAsync((Watch)null);
    //     var controller = new WatchController(watchRepo.Object);
    //
    //     // Act
    //     var result = await controller.GetWatch(10);
    //
    //     // Assert
    //     var actionResult = Assert.IsType<ActionResult<Watch>>(result);
    //     Assert.IsType<NotFoundResult>(actionResult.Result);
    // }
    //
    // [Fact]
    // public async Task GetItem_ReturnsOkResult_WithItem()
    // {
    //     // Arrange
    //     var watchRepo = new Mock<IWatchRepository>();
    //     watchRepo.Setup(repo => repo.GetWatchByIdAsync(1))
    //         .ReturnsAsync(GetTestWatches().Find(w => w.Id == 1));
    //     var controller = new WatchController(watchRepo.Object);
    //
    //     // Act
    //     var result = await controller.GetWatch(1);
    //
    //     // Assert
    //     var actionResult = Assert.IsType<ActionResult<Watch>>(result);
    //     var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
    //     var returnValue = Assert.IsType<Watch>(okResult.Value);
    //     Assert.Equal(1, returnValue.Id);
    // }

    private List<Watch> GetTestWatches()
    {
        List<Photo> watch1 = new List<Photo>();
        watch1.Add(new Photo() {Id = 1, Url = "w1.com", IsMain = true, PublicId = "1", WatchId = 1});
        watch1.Add(new Photo() {Id = 2, Url = "w2.com", IsMain = true, PublicId = "2", WatchId = 1});
        
        List<Photo> watch2 = new List<Photo>();
        watch2.Add(new Photo() {Id = 1, Url = "w1.com", IsMain = true, PublicId = "1", WatchId = 2});
        watch2.Add(new Photo() {Id = 2, Url = "w2.com", IsMain = true, PublicId = "2", WatchId = 2});
        
        
        return new List<Watch>
        {
       
            
            new()
            {
                Id = 1,
                Name = "L1",
                BrandId = 1,
                Brand = new Brand { Id = 1, Name = "Seiko" },
                CalibreId = 1,
                Calibre = new Calibre { Id = 1, Name = "NHK" },
                CaseMaterialId = 1,
                CaseMaterial = new CaseMaterial { Id = 1, Material = "Steel" },
                CrystalId = 1,
                Crystal = new Crystal { Id = 1, Material = "Hardlex" },
                DialId = 1,
                Dial = new Dial { Id = 1, Colour = "Red" },
                Lume = true,
                Reference = "SKXZL1",
                MovementTypeId = 1,
                MovementType = new MovementType { Id = 1, Type = "Automatic" },
                Photos = watch1,
                Price = (decimal)999.99,
                PowerReserveId = 1,
                PowerReserve = new PowerReserve { Id = 1, Duration = "40hrs" },
                StockId = 1,
                Stock = new Stock {Id = 1, Quantity = 10},
                StrapBraceletMaterialId = 1,
                StrapBraceletMaterial = new StrapBraceletMaterial { Id = 1, Material = "Steel" },
                WatchCaseMeasurementsId = 1,
                WatchCaseMeasurements = new WatchCaseMeasurements { Id = 1, Diameter = 39, Length = 46, LugWidth = 20, Thickness = 10},
                WatchTypeId = 1,
                WatchType = new WatchType { Id = 1, Type = "Gmt" },
                WaterResistanceId = 1,
                WaterResistance = new WaterResistance { Id = 1, Resistance = "100" },
                OtherSpecifications = "Limited edition Gmt watch"
            },
            new()
            {
                Id = 2,
                Name = "L2",
                BrandId = 2,
                Brand = new Brand { Id = 2, Name = "Seiko" },
                CalibreId = 2,
                Calibre = new Calibre { Id = 2, Name = "NHK" },
                CaseMaterialId = 2,
                CaseMaterial = new CaseMaterial { Id = 2, Material = "Steel" },
                CrystalId = 2,
                Crystal = new Crystal { Id = 2, Material = "Hardlex" },
                DialId = 2,
                Dial = new Dial { Id = 2, Colour = "Blue" },
                Lume = true,
                Reference = "SKXZL2",
                MovementTypeId = 2,
                MovementType = new MovementType { Id = 2, Type = "Automatic" },
                Photos = watch2,
                Price = (decimal)1000.50,
                PowerReserveId = 2,
                PowerReserve = new PowerReserve { Id = 2, Duration = "40hrs" },
                StockId = 2,
                Stock = new Stock {Id = 2, Quantity = 5},
                StrapBraceletMaterialId = 2,
                StrapBraceletMaterial = new StrapBraceletMaterial { Id = 2, Material = "Steel" },
                WatchCaseMeasurementsId = 2,
                WatchCaseMeasurements = new WatchCaseMeasurements { Id = 2, Diameter = 39, Length = 46, LugWidth = 20, Thickness = 10},
                WatchTypeId = 2,
                WatchType = new WatchType { Id = 2, Type = "Chronograph" },
                WaterResistanceId = 2,
                WaterResistance = new WaterResistance { Id = 2, Resistance = "200" },
                OtherSpecifications = "Limited edition chronograph watch"
            }
        };
    }
}