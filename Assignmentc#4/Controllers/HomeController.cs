using Assignmentc_4.IServices;
using Assignmentc_4.Models;
using Assignmentc_4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public ActionResult ShowAllProduct()
        {
            List<Product> products = productServices.GetAllProducts();
            return View(products); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }
        public IActionResult TrangChu()
        {
            List<Product> product = productServices.GetAllProducts();
            return View(product);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product, IFormFile LinkAnh)
        {
            if (LinkAnh != null && LinkAnh.Length > 0)
            {
                var fileName = Path.GetFileName(LinkAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    LinkAnh.CopyTo(stream);
                }
                // Lưu đường dẫn đến ảnh vào đối tượng User
                product.ImgUrl = "/images/" + fileName;
            }
            if (productServices.CreateProduct(product))
            {
                return RedirectToAction("TrangChu");
            }
            else return BadRequest();
        }

        public IActionResult Details(Guid id)
        {
            var product = productServices.GetProductById(id);
            return View(product); ;
        }
        public IActionResult Delete(Guid id)
        {
            if (productServices.DeleteProduct(id))
            {
                return RedirectToAction("TrangChu");
            }
            else return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var product = productServices.GetProductById(id);
            return View(product);
        }
        public IActionResult Edit(Product p, IFormFile LinkAnh)
        {
            if (LinkAnh != null && LinkAnh.Length > 0)
            {
                var fileName = Path.GetFileName(LinkAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    LinkAnh.CopyTo(stream);
                }

                p.ImgUrl = "/images/" + fileName;
            }
            if (productServices.UpdateProduct(p))
            {
                return RedirectToAction("TrangChu");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult ViewBag_ViewData()
        {
            var product = productServices.GetAllProducts();
            // ViewBag chứa dữ liệu dạng dyanamic, khi cần sử dụng 
            // ta không cần khởi tạo mà gán thẳng giá trị vào
            ViewBag.Products = product;
            //ViewData chứa dữ liệu dạng Generic, dữ liệu này được lưu 
            // dưới dạng key-value
            ViewData["Products"] = product;
            //Trong đó "Products" là key còn product là value 
            return View(product);
        }
        public IActionResult AddToCart(Guid id)
        {
            var product = productServices.GetProductById(id);
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Product");
            if (products.Count == 0)
            {
                products.Add(new Product
                {
                    Id = id,
                    Name = product.Name,
                    ImgUrl = product.ImgUrl,
                    SoLuongTon = 1,
                    Price = product.Price,
                });
                SessionServices.SetObjToSession(HttpContext.Session, "Product", products);
            }
            else
            {
                if (SessionServices.CheckObjInList(id, products))
                {
                    var item = products.FirstOrDefault(c => c.Id == id);
                    item.SoLuongTon++;
                    SessionServices.SetObjToSession(HttpContext.Session, "Product", products);
                }
                else
                {
                    products.Add(new Product
                    {
                        Id = id,
                        Name = product.Name,
                        ImgUrl = product.ImgUrl,
                        SoLuongTon = 1,
                        Price = product.Price,
                    }); // Thêm trực tiếp sp vào nếu List chưa chứa sp đó
                    SessionServices.SetObjToSession(HttpContext.Session, "Product", products);
                }
            }
            return RedirectToAction("ShowCart");
        }
        public int IsExist(Guid id)
        {
            List<Product> products = SessionServices.GetObjFromSession(HttpContext.Session, "Product");
            for(int i =0; i < products.Count; i++)
            {
                if (products[i].Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult DeleteCart(Guid id)
        {
            var product = SessionServices.GetObjFromSession(HttpContext.Session, "Product");
            int index = IsExist(id);
            product.RemoveAt(index);
            SessionServices.SetObjToSession(HttpContext.Session, "Product", product);
            return RedirectToAction("ShowCart");
        }

        public IActionResult ShowCart()
        {
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Product");
            ViewBag.cart = products;
            ViewBag.total = products.Sum(c => c.SoLuongTon * c.Price);
            return View(products);  // Truyền sang view
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}