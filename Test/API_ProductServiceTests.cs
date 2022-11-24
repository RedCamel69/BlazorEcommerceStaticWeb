using Api.Services.ProductService;

namespace Test
{
    public class API_ProductServiceTests
    {
        [Fact]
        public void GetProducts_Returns_ServiceResponse()
        {
            var prodService = new ProductService();
            var products = prodService.GetProducts();
            Assert.NotNull(products);
        }
    }
}