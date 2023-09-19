using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagementClientMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        private string CategoryApiUrl = "";

        public ProductsController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:44366/api/ProductsControllers";
            CategoryApiUrl = "https://localhost:44366/api/Category";
        }


        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Products> listProducts = JsonSerializer.Deserialize<List<Products>>(strData, options);
            return View(listProducts);
        }

       


        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/" + id);
            string strData = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(strData);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Products listProducts = JsonSerializer.Deserialize<Products>(strData, options);
            return View(listProducts);
        }

        private async Task<Products> GetProductById(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/" + id);
            if (!response.IsSuccessStatusCode)
                return null;
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<Products>(strData, options);
        }


        public async Task<IActionResult> Create()
        {
            // Category
            HttpResponseMessage response = await client.GetAsync(CategoryApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Category> listCategories = JsonSerializer.Deserialize<List<Category>>(strData, options);
            ViewBag.listCategories = listCategories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Products p)
        {

            await client.PostAsJsonAsync(ProductApiUrl, p);
            return Redirect("/Products/Index");
        }



        public async Task<IActionResult> Edit(int id)
        {
            var product = await GetProductById(id);
            HttpResponseMessage response = await client.GetAsync(CategoryApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Category> listCategories = JsonSerializer.Deserialize<List<Category>>(strData, options);
            ViewBag.listCategories = listCategories;
            if (product == null)
                return NotFound();
            return View(product);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] Products p)
        {

            await client.PostAsJsonAsync(ProductApiUrl + "/" + id, p);
            return Redirect("/Products/Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var product = await GetProductById(id);
            HttpResponseMessage response = await client.GetAsync(CategoryApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Category> listCategories = JsonSerializer.Deserialize<List<Category>>(strData, options);
            ViewBag.listCategories = listCategories;
            if (product == null)
                return NotFound();
            return View(product);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id, [FromForm] Products p)
        {

            await client.DeleteAsync(ProductApiUrl + "/" + id);
            return Redirect("/Products/Index");
        }





    }
}
