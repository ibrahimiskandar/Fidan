using LimakAz.Models;
using LimakAz.Models.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.ViewModels
{
    public class BalanceViewModel
    {
        public double Money { get; set; }
        public AppUser Member { get; set; }
        public PayModel payModel { get; set; }
        [Required (ErrorMessage = "Zəhmət olmasa məbləği daxil edin!")]
        [Range(1, 50, ErrorMessage = "Min: 1 USD - Max: 50 USD")]
        public double Amount { get; set; }

    }
}
