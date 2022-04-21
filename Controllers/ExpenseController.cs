using Microsoft.AspNetCore.Mvc;
using MVC_1.Data;
using MVC_1.Models;
using System.Collections;
using System.Collections.Generic;

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
            IEnumerable<Expense> list=_db.Expenses;
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            _db.Add(expense);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
