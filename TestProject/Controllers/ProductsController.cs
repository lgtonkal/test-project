using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestProject.DataAccess;
using TestProject.Entities;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductDal _productDal;

        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }
        
        // GET api/products
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _productDal.GetList();
                return Ok(products);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            return BadRequest();

        }

        // GET api/products/5
        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {

            try
            {
                var product = _productDal.Get(p => p.ProductId == productId);

                if (product == null)
                {
                    return NotFound($"There is no product with id = {productId}");
                }
                
                return Ok(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return BadRequest();
        }

        // POST api/products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                _productDal.Add(product);
                
                return new StatusCodeResult(201);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            return BadRequest();
        }

        // PUT api/products
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                _productDal.Update(product);
                
                return Ok(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            return BadRequest();
        }

        // DELETE api/products
        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                _productDal.Delete(new Product { ProductId = productId });

                return new StatusCodeResult(204);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);    
            }
            
            return BadRequest();
        }
    }
}