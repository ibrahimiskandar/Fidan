using LimakAz.Models;
using LimakAz.Models.Settings;
using LimakAz.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pg = 1)
        {

            var products = _context.ShopItems;
            const int pageSize = 12;
            if (pg < 1)
                pg = 1;
            int recsCount = products.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = products.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            ShopViewModel shopVM = new ShopViewModel
            {
                Categories = _context.Categories.Where(x => !x.IsDeleted).ToList(),
                ShopItems = data
            };

            return View(shopVM);

        }

        public IActionResult Category(int id)
        {
            ShopViewModel shopVM = new ShopViewModel
            {
                Categories = _context.Categories.Where(x => !x.IsDeleted).ToList(),
                ShopItems = _context.ShopItems.Where(x => x.IsFeatured).Where(x => x.CategoryId == id).ToList()
            };

            return View(shopVM);

        }
        //public IActionResult Turkey(int id)
    }
}
