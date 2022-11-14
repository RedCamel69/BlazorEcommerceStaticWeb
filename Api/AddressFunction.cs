using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using BlazorEcommerceStaticWebApp.Shared;

namespace BlazorEcommerceStaticWebApp.Api
{
    public static class AddressFunction
    {
        [FunctionName("Addresses")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            List<Address> addresses = new List<Address>();
            addresses.Add(new Address()
            {
                City = "Manchester",
                Country= "England",
                FirstName = "Harry",
                LastName = "Palmer"
            });

            addresses.Add(new Address()
            {
                City = "Poole",
                Country = "England",
                FirstName = "James",
                LastName = "Bond"
            });

            return new OkObjectResult(addresses);
        }
    }
}
