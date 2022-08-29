using LimakAz.Models;
using LimakAz.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.ViewModels
{
    public class BalanceViewModel
    {
        public double Money { get; set; }
        public AppUser Member { get; set; }
        public PayModel payModel { get; set; }
    }
}
