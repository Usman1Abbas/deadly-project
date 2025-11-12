using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DeadlyProject.Api.Models;
using System.Net.Http;
using System.Text;

namespace DeadlyProject.Tests.IntegrationTests
{
    [TestClass]
    public class ProductsControllerTests
    {
        private readonly HttpClient _client;

        public ProductsControllerTests()
        {
            var application = new WebApplicationFactory<DeadlyProject.Api.Program>()
                .WithWebHostBuilder(builder =>
                {
                    // Configure the web host if needed
                });

            _client = application.CreateClient();
        }

        [TestMethod]
        public async Task GetProducts_ReturnsOkResult()
        {
            // Act
            var response = await _client.GetAsync("/products");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task PostProduct_CreatesNewProduct()
        {
            // Arrange
            var product = new Product { Name = "New Product", Price = 20.00M };
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/products", content);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
