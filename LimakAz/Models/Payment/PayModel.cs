using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class PayModel
    {

        [Required(ErrorMessage = "Please Enter amount")]
        [Display(Name = "Cardholder Name")]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "Please Enter amount")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter amount")]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please Enter amount")]
        [Display(Name = "Card Number")]
        public string CardNumder { get; set; }


        [Required(ErrorMessage = "Please Enter amount")]
        [Display(Name = "Expiration Month")]
        public int Month { get; set; }


        [Required(ErrorMessage = "Please Enter amount")]
        [Display(Name = "Expiration Year")]
        public int Year { get; set; }


        [Required(ErrorMessage = "Please Enter amount")]
        public string CVC { get; set; }
        [Range(1, 100)]
        [Required(ErrorMessage ="Please Enter amount")]
        public int Amount { get; set; }
    }
}
