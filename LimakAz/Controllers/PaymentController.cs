﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LimakAz.Models;
using LimakAz.Models.Payment;
using LimakAz.Payment;
using LimakAz.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LimakAz.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public PaymentController(ILogger<PaymentController> logger, AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index(BalanceViewModel balance)
        {

            HttpContext.Session.SetInt32("Amount", (balance.Amount));

            return View(balance);
        }

        public IActionResult Page1()
        {
            return View();
        }
        public IActionResult Page2()
        {
            return View();
        }
        public IActionResult Page3()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }


        [Route("pay")]
        public async Task<dynamic> Pay(PayModel payModel)
        {
            if (ModelState.IsValid)
            {

                payModel.Amount = HttpContext.Session.GetInt32("Amount");
                var result = await ProcessPayment.PayAsync(payModel);

                if (result == "Success")
                {
                    AppUser member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                    member.Balance = member.Balance + Convert.ToInt32(payModel.Amount);
                    var increaseResult = await _userManager.UpdateAsync(member);
                    if (!increaseResult.Succeeded)
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }

                        return RedirectToAction("Error", increaseResult);
                    }
                    return RedirectToAction("Success");
                }
                else
                {
                    return RedirectToAction("Error", result);
                }
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string error)
        {
            return View(new ErrorViewModel { RequestId = error != null ? error : Activity.Current?.Id ?? HttpContext.TraceIdentifier }); ;
        }
    }
}
