using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Api.Services.ProductService;

namespace Api
{
    public class ProductFunction
    {

        private readonly IProductService _productService;

        public ProductFunction(IProductService productService)
        {
            _productService = productService;
        }

        [FunctionName("Products")]
        public IActionResult GetProducts(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req,
        ILogger log)
        {

            log.LogInformation("C# HTTP GET trigger function processed api/students request.");

           

            return new OkObjectResult(_productService.GetProducts());
        }
    }
}
