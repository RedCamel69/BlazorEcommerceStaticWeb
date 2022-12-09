using BlazorEcommerceStaticWebApp.Shared;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorEcommerceStaticWebApp.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Product> AdminProducts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CurrentPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PageCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastSearchText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action ProductsChanged;

        public Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task GetAdminProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var res = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product/featured")
                : await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/Category/{categoryUrl}");



            if (res != null && res.Data != null)
                Products = res.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0)
            {
                Message = "No Products Found";
            }

            ProductsChanged.Invoke();
        }

        public Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            throw new NotImplementedException();
        }

        public Task SearchProducts(string searchText, int page)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
