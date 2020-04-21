using CustomModelBinder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CustomModelBinder.Controllers
{
    public class PointController: Controller
    {
        private static List<PointViewModel> points = new List<PointViewModel>();

        public IActionResult Table()
        {
            return View(points);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PointViewModel p)
        {
            points.Add(p);
            return RedirectToAction("Table");
        }
    }
}
