using Microsoft.AspNetCore.Mvc;
using System;

namespace MVC_1.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return Ok(DateTime.Now.ToShortDateString());
            //return View();
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
                return Ok("You are on id: " + id);
            else
                return Index();
        }
    }
}
