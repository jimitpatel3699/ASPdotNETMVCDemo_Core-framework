using EFcodefirstinCoewMVC.Data;
using EFcodefirstinCoewMVC.Models;
using EFcodefirstinCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFcodefirstinCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _connection;
        private readonly IWebHostEnvironment _webhostenvironment;
        public ProductController(ApplicationDbContext connection, IWebHostEnvironment webHostEnvironment)
        {
            _connection = connection;
            _webhostenvironment = webHostEnvironment;
        }
        [NonAction]
        private IEnumerable<SelectListItem> GetCategory()
        {
            IEnumerable<SelectListItem> CategoryList = _connection!.Categories.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return CategoryList;
        }
        public IActionResult Index()
        {
            var objCategoryList = _connection.Products.Include(x=>x.Category).ToList();
            return View(objCategoryList);
        }
        public IActionResult Create() 
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webhostenvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productpath = Path.Combine(wwwRootPath, @"images\product");
                    using (var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\images\product\" + filename;
                }
                _connection.Products.Add(obj);
                _connection.SaveChanges();
                TempData["success"] = "Product added successfully";
                return RedirectToAction("Index", "Product");
            }

            else
            {
                ViewBag.CategoryList = GetCategory();
                return View();
        }   }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product findProduct = _connection.Products.Find(id);
            if (findProduct == null)
            {
                return NotFound();
            }
            ViewBag.CategoryList = GetCategory();
            return View(findProduct);
        }
        [HttpPost]
        public IActionResult Edit(Product obj, IFormFile? file )
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webhostenvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productpath = Path.Combine(wwwRootPath, @"images\product");
                    if(!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        //delete old image
                        var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\images\product\" + filename;
                }
                _connection.Products.Update(obj);
                _connection.SaveChanges();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.CategoryList = GetCategory();
                return View();
            }
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product findProduct = _connection.Products.Find(id);
            if (findProduct == null)
            {
                return NotFound();
            }
            _connection.Products.Remove(findProduct);
            _connection.SaveChanges();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index", "Product");
        }
        public IActionResult Details(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
         var findProduct = _connection.Products.Include(x=>x.Category).FirstOrDefault(x=>x.Id==id);
            //findProduct.Category = _connection.Categories.Find(id);
            if (findProduct == null)
            {
                return NotFound();
            }
            return View(findProduct);
        }
    }
}


