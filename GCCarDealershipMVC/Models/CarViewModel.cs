using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCarDealershipMVC.Models
{
    public class CarViewModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }
}