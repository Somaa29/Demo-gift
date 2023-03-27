using Assignmentc_4.IServices;
using Assignmentc_4.Models;
using Assignmentc_4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignmentc_4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices productServices; //Interface


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productServices = new ProductServices();
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult TrangChu()
        {
            return View();
        }
        public IActionResult SanPham()
        {
            return View();
        }
       
        public ActionResult ShowAllProduct()
        {
            List<Product> products = productServices.GetAllProducts();
            return View(products); // Truyền trực tiếp 1 Obj Model duy nhất sang view
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (productServices.CreateProduct(p))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }

        public IActionResult Details(Guid id)
        {
            var product = productServices.GetProductById(id);
            return View(product);
        }

        public IActionResult Delete(Guid id)
        {
            if (productServices.DeleteProduct(id))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var product = productServices.GetProductById(id);
            return View(product);
        }
        public IActionResult Edit(Product p) 
        { 
            if (p.Price <= 1)
            {
                return Content("Giá phải lớn hơn 1");
            }
            else if(p.SoLuongTon <=1)
            {
                return Content("Số Lượng phải lớn hơn 1");
            }
            else
            {
                productServices.UpdateProduct(p);
                return RedirectToAction("ShowAllProduct");
            } return BadRequest();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}