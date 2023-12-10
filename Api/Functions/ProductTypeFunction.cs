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
using Api.Services.Services.ProductTypeService;

namespace Api.Functions
{
    public class ProductTypeFunction
    {

        private readonly IProductTypeService _service;

        public ProductTypeFunction(IProductTypeService service)
        {
            _service = service;
        }

        [FunctionName("ProductTypes")]
        public IActionResult GetProductTypes(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "producttypes")] HttpRequest req,
        ILogger log)
        {
            log.LogInformation("C# HTTP GET trigger function processed api/products request.");
            return new OkObjectResult(_service.GetProductTypes());
        }

        [FunctionName("ProductTypesAsync")]
        public async Task<IActionResult> GetProductTypesAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
        ILogger log)
        {
            log.LogInformation("C# HTTP GET trigger function processed api/productsasync request.");

            //var res = _productService.GetProductsAsync().Result;
            var res = await _service.GetProductTypesAsync();

            return new OkObjectResult(res);
        }

    }
}
