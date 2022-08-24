using LimakAz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "SuperAdmin")]
    public class CourierController : Controller
    {
        private readonly AppDbContext _context;
        public CourierController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Courier> couriers = _context.Couriers.ToList();
            return View(couriers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Courier courier)
        {
            if (!ModelState.IsValid) return View();

            _context.Couriers.Add(courier);
            _context.SaveChanges();

            return RedirectToAction("index", "courier");
        }

        public IActionResult Edit(int id)
        {
            Courier courier = _context.Couriers.FirstOrDefault(x => x.Id == id);
            if (courier == null) return RedirectToAction("index", "error");

            return View(courier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Courier courier)
        {
            Courier existCourier = _context.Couriers.FirstOrDefault(x => x.Id == courier.Id);

            if (existCourier == null) return RedirectToAction("index", "error");
            if (!ModelState.IsValid) return View();

            existCourier.FullName = courier.FullName;
            existCourier.WareHouseId = courier.WareHouseId;
            existCourier.Money = courier.Money;

            _context.SaveChanges();

            return RedirectToAction("index", "courier");
        }

        public IActionResult DeleteFetch(int id)
        {
            Courier courier = _context.Couriers.FirstOrDefault(x => x.Id == id);
            if (courier == null) return Json(new { status = 404 });

            _context.Couriers.Remove(courier);
            _context.SaveChanges();


            return RedirectToAction("index", "courier");
        }
    }
}

