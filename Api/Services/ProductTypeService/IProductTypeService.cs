using BlazorEcommerceStaticWebApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        ServiceResponse<List<ProductType>> GetProductTypes();
        Task<ServiceResponse<List<ProductType>>> GetProductTypesAsync();
        Task<ServiceResponse<List<ProductType>>> AddProductType(ProductType productType);
        Task<ServiceResponse<List<ProductType>>> UpdateProductType(ProductType productType);


    }
}
