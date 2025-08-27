using System;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Washyn.Kfc;
using Xunit;

namespace ERP.SYSTEM.EntityFrameworkCore.Samples;

public class SampleRepositoryTests : SYSTEMEntityFrameworkCoreTestBase
{
    private readonly IProductRepository _productRepository;

    public SampleRepositoryTests()
    {
        _productRepository = GetRequiredService<IProductRepository>();
    }

    [Fact]
    public async Task Should_Query_AppUser()
    {
        /* Need to manually start Unit Of Work because
         * FirstOrDefaultAsync should be executed while db connection / context is available.
         */
        // await WithUnitOfWorkAsync(async () =>
        // {
        //         //Act
        //         var adminUser = await _appUserRepository
        //         .FirstOrDefaultAsync(u => u.UserName == "admin");
        //         
        //         //Assert
        //         adminUser.ShouldNotBeNull();
        // });

        var board = new Product(Guid.NewGuid(), "1234567890", "1234567890");
        
        await _productRepository.InsertAsync(board);

        var res = await _productRepository.GetAsync(board.Id);
            
        res.Id.ShouldBe(board.Id);
    }
}
