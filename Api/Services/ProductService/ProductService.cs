using BlazorEcommerceStaticWebApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.ProductService
{
    public class ProductService : IProductService
    {
        //private readonly DataContext _context;
        //private readonly IHttpContextAccessor _httpContext;

        //public ProductService(DataContext context, IHttpContextAccessor httpContext)
        //{
        //    _context = context;
        //    _httpContext = httpContext;
        //}
        public Task<ServiceResponse<Product>> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Product>>> GetAdminProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Product>>> GetProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = new List<Product>()
                {
                    new Product() {
                         Id = 1,
                          Title= "Test1"
                    },
                    new Product() {
                            Id = 1,
                          Title= "Test1"

                    }
                }

            };

            return response;
        }

        public Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Product>> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
