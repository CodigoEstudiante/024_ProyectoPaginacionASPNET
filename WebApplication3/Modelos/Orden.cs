using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Modelos
{
    public class Orden
    {
        public string OrderId { get; set; }
        public string CustomerID { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCountry { get; set; }
    }
}