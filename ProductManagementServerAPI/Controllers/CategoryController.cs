using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Collections.Generic;

namespace ProductManagementServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IProductsRepository productsRepository = new ProductsRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() => productsRepository.GetCategories();
    }
}
