using Microsoft.AspNetCore.Mvc;
using MVC_1.Data;
using MVC_1.Models;
using System;
using System.Collections.Generic;

namespace MVC_1.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> list = _db.Items;
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            _db.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
