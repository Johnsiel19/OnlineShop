using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShopWeb.Models;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineShopWeb.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7173/api");
        private readonly HttpClient _httpClient;

        public ProductController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productsList = Enumerable.Empty<ProductViewModel>();
            try
            {
                var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/products/getproducts").ConfigureAwait(false);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(data))
                        productsList = JsonConvert.DeserializeObject<List<ProductViewModel>>(data) ?? Enumerable.Empty<ProductViewModel>();
                }
            }
            catch (Exception ex)
            {
            }
            
            return View(productsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage responde = _httpClient.PostAsync(_httpClient.BaseAddress + "/products/createproduct", content).Result;

                if (responde.StatusCode == HttpStatusCode.OK)
                {
                    TempData["successMessage"] = "Product Create.";
                    return RedirectToAction("Index");
                }

            }
            catch(Exception ex)
            {
                TempData["successMessage"] = ex.Message;
                return View();
            }
            return View();

           
        }
    }
}
