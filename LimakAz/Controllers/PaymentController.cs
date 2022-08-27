using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LimakAz.Models.Payment;
using LimakAz.Payment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LimakAz.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
                var result = await ProcessPayment.PayAsync(payModel);

                if (result == "Success")
                {
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
