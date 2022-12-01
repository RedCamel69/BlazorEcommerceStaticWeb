using BlazorEcommerceStaticWebApp.Api.Data;
using BlazorEcommerceStaticWebApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public ProductService(
            ApplicationDbContext context , 
            IHttpContextAccessor httpContext
            )
        {
            _context = context;
            _httpContext = httpContext;
        }
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

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            Product product = null;

            if (_httpContext.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.Products
               .Include(p => p.Variants.Where(v => !v.Deleted))
               .ThenInclude(v => v.ProductType)
               .Include(p => p.Images)
               .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted);
            }
            else
            {
                product = await _context.Products
                .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                .ThenInclude(v => v.ProductType)
                 .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted && p.Visible);
            }

            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry this product does not exist";
            }
            else
            {
                response.Success = true;
                response.Data = product;
            }

            return response;
        }

        public ServiceResponse<Product> GetProduct(int productId)
        {
            var response = new ServiceResponse<Product>();
            Product product = null;

            if (_httpContext.HttpContext.User.IsInRole("Admin"))
            {
                product =  _context.Products
               .Include(p => p.Variants.Where(v => !v.Deleted))
               .ThenInclude(v => v.ProductType)
               .Include(p => p.Images)
               .FirstOrDefault(p => p.Id == productId && !p.Deleted);
            }
            else
            {
                product =  _context.Products
                .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                .ThenInclude(v => v.ProductType)
                 .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == productId && !p.Deleted && p.Visible);
            }

            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry this product does not exist";
            }
            else
            {
                response.Success = true;
                response.Data = product;
            }

            return response;
        }

        public ServiceResponse<List<Product>> GetProducts()
        {

            var response = new ServiceResponse<List<Product>>
            {
                Data = _context.Products.ToList<Product>()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                   .Where(p => !p.Deleted && p.Visible)
                   .Include(_ => _.Variants.Where(v => !v.Deleted && v.Visible))
                    .Include(p => p.Images)
                   .ToListAsync()

            };

            return response;
        }

     

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Where(p => p.Category.Url.ToLower() == categoryUrl.ToLower() && !p.Deleted && p.Visible)
                 .Include(_ => _.Variants.Where(v => !v.Deleted && v.Visible))
                  .Include(p => p.Images)
                .ToListAsync()
            };

            return response;
        }

        public ServiceResponse<List<Product>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = _context.Products
                .Where(p => p.Category.Url.ToLower() == categoryUrl.ToLower() && !p.Deleted && p.Visible)
                 .Include(_ => _.Variants.Where(v => !v.Deleted && v.Visible))
                  .Include(p => p.Images)
                .ToList()
            };

            return response;
        }

        public ServiceResponse<List<Product>> GetProductsByTitle()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = _context.Products
                            .OrderBy(p=>p.Title)
                            .ToList<Product>()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByTitleASync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                           .OrderBy(p => p.Title)
                           .ToListAsync<Product>()
            };

            return response;
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

        ServiceResponse<List<Product>> IProductService.GetProductsByTitle()
        {
            throw new NotImplementedException();
        }

       
    }
}
