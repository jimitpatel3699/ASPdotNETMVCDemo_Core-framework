using EFcodefirstinCoewMVC.Data;
using EFcodefirstinCoewMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFcodefirstinCoewMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _connection;
        public CategoryController(ApplicationDbContext connection)
        {
            _connection = connection;  
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _connection.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.DisplayOrder<1) {
                ModelState.AddModelError("invalidnumber", "Display order must be greater than 0");
            }
            if(ModelState.IsValid)
            {
                _connection.Categories.Add(obj);
                _connection.SaveChanges();
                TempData["success"] = "Category added successfully";
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Edit(int? id)
        { 
                if(id==null || id==0)
                {
                    return NotFound();
                }
                Category findCategory = _connection.Categories.Find(id);
                if(findCategory==null)
                {
                    return NotFound();
                }
                return View(findCategory);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _connection.Categories.Update(obj);
                _connection.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category findCategory = _connection.Categories.Find(id);
            if (findCategory == null)
            {
                return NotFound();
            }
            _connection.Categories.Remove(findCategory);
            _connection.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index", "Category");
        }
    }
}
