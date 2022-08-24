using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class Tariff
    {
        public int Id { get; set; }
        public string Weight { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public double Price { get; set; }
        public bool IsLocal { get; set; }
    }
}
