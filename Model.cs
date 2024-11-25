using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PdfExporting
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
