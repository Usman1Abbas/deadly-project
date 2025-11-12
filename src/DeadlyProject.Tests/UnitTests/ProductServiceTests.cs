using DeadlyProject.Api.Services;
using DeadlyProject.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DeadlyProject.Tests.UnitTests
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public void GetAllProducts_ReturnsEmptyList_WhenNoProductsExist()
        {
            // Arrange
            var productService = new ProductService();

            // Act
            var products = productService.GetAllProducts();

            // Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(0, products.Count());
        }

        [TestMethod]
        public void AddProduct_AddsProductToList()
        {
            // Arrange
            var productService = new ProductService();
            var product = new Product { Name = "Test Product", Price = 10.00M };

            // Act
            productService.AddProduct(product);
            var products = productService.GetAllProducts();

            // Assert
            Assert.AreEqual(1, products.Count());
            Assert.AreEqual("Test Product", products.First().Name);
        }
    }
}
