using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizeCulture.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public double Cost { get; set; }

        public double? Tax { get; set; }
      //  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LaunchDate { get; set; }
    }
}
