using Microsoft.AspNetCore.Mvc;
using MVC_1.Data;
using MVC_1.Models;
using System.Collections.Generic;

namespace MVC_1.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> list = _db.Categories;
            return View(list);
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Category c = _db.Categories.Find(Id);
            if (c == null)
            {
                return NotFound();
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Delete(Category c)
        {
            _db.Categories.Remove(c);
            _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            Category c = _db.Categories.Find(id);
            if (c == null)
            {
                return NotFound();
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Update(Category c)
        {
            _db.Categories.Update(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category == null)
            {
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                 return RedirectToAction("Index");
            }
            return View();
        }
    }
}
