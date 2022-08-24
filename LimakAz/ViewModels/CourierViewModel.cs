using LimakAz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.ViewModels
{
    public class CourierViewModel
    {
        public List<Courier> Couriers { get; set; }
        public AppUser User { get; set; }
    }
}
