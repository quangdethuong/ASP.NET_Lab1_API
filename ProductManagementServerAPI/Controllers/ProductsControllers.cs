
using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagementServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControllers : ControllerBase
    {
        private IProductsRepository productsRepository = new ProductsRepository();
        // GET: api/<ProductsControllers>
        [HttpGet]
        public ActionResult<IEnumerable> GetProducts() => productsRepository.GetProducts();


        // POST api/<ProductsControllers>
        [HttpPost]
        public IActionResult PostProduct(Products p)
        {
            productsRepository.SaveProduct(p);
            return Ok(p);
        }

        // PUT api/<ProductsControllers>/5
        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            var p = productsRepository.GetProductById(id);
            if (p == null)
                return NotFound();
            return Ok(p);
        }

        // DELETE api/<ProductsControllers>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var p = productsRepository.GetProductById(id);
            if (p == null)
                return NotFound();
            productsRepository.DeleteProduct(p);
            return NoContent();
        }

        [HttpPost("{id}")]
        public IActionResult UpdateProduct(int id, Products p)
        {
            var pTmp = productsRepository.GetProductById(id);
            if (pTmp == null)
                return NotFound();
            productsRepository.UpdateProduct(p);
            return Ok(p);
        }
    }
}
