using Shouldly;
using Washyn.Kfc;
using Xunit;

namespace Infraestructure.Tests.Products;

public class ProductRepositoryTests : InfraestructureTestBase
{
    private readonly IProductRepository _productRepository;

    public ProductRepositoryTests()
    {
        _productRepository = GetRequiredService<IProductRepository>();
    }

    [Fact]
    public async Task Should_Insert_And_Query_Product()
    {
        // Arrange
        var board = new Product(Guid.NewGuid(), "1234567890", "1234567890");


        // Act
        await _productRepository.InsertAsync(board);
        var res = await _productRepository.GetAsync(board.Id);
        var products = await _productRepository.GetListAsync();

        // Assert
        products.Count.ShouldBe(1);
        res.Id.ShouldBe(board.Id);
    }
}
