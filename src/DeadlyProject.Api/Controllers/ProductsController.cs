using Microsoft.AspNetCore.Mvc;
using DeadlyProject.Api.Services;
using DeadlyProject.Api.Models;
using System.Collections.Generic;
using System;

namespace DeadlyProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                // TODO: Log the error
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                // TODO: Log the error
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _productService.AddProduct(product);
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                // TODO: Log the error
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            try
            {
                if (product == null || id != product.Id)
                {
                    return BadRequest("Invalid product object or ID mismatch");
                }

                if (!_productService.ProductExists(id))
                {
                    return NotFound();
                }

                _productService.UpdateProduct(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                // TODO: Log the error
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_productService.ProductExists(id))
                {
                    return NotFound();
                }

                _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // TODO: Log the error
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
