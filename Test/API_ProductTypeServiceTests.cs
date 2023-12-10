using Api.Services.ProductService;
using Api.Services.Services.ProductTypeService;
using BlazorEcommerceStaticWebApp.Api.Data;
using BlazorEcommerceStaticWebApp.Shared;
using BlazorEcommerceStaticWebApp.Test;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net.Http;
using System.Reflection.Metadata;

namespace Test
{
    public class API_ProductTypeService
    {

        // after https://learn.microsoft.com/en-gb/ef/ef6/fundamentals/testing/mocking?redirectedfrom=MSDN

        // after https://www.andrewhoefling.com/Blog/Post/moq-entity-framework-dbset

        [Fact]
        public void GetProductTypes_Returns_ServiceResponse()
        {
            var data = new List<ProductType>
            {
                new ProductType {   Id = 1, Name="Product Type 1", Editing=false, IsNew=true },
                 new ProductType {   Id = 2, Name="Product Type 2", Editing=false, IsNew=true },
                 new ProductType {   Id = 3, Name="Product Type 3", Editing=false, IsNew=true }
            }.AsQueryable();

            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();

            var mockSet = new Mock<DbSet<ProductType>>();
            mockSet.As<IQueryable<ProductType>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ProductType>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ProductType>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ProductType>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.ProductTypes).Returns(mockSet.Object);

            var service = new ProductTypeService(mockContext.Object, mockHttpContextAccessor.Object);
            var products = service.GetProductTypes();

            Assert.Contains("ServiceResponse", products.GetType().Name);

            Assert.True(true);
        }
    }
}