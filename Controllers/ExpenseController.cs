using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_1.Data;
using MVC_1.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MVC_1.Controllers
{
    public class ExpenseController : Controller
    {
        public readonly ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> list = _db.Expenses.Include(m=>m.ExpenseCategory);

            return View(list);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            if(ModelState.IsValid)
            {
                _db.Add(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Create()
        {
            IEnumerable<SelectListItem> list = _db.Categories.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.categoryselect = list;
            return View();
        }


        public IActionResult Update(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            Expense expense = _db.Expenses.Find(id);
            IEnumerable<SelectListItem> list = _db.Categories.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }) ;
            ViewBag.catelist = list;
            if(expense==null)
            {
                return NotFound();
            }
            return View(expense);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense expense)
        {
            if(ModelState.IsValid)
            {
                _db.Expenses.Update(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(expense);
        }



        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Expense expense = _db.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Expense expense)
        {
            //if (ModelState.IsValid)
            //{
                _db.Expenses.Remove(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            //}

            //return View(expense);
        }
    }
}
