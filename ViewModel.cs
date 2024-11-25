using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfExporting
{
    public class ViewModel
    {
        public ObservableCollection<Order> Orders { get; set; }

        public ViewModel()
        {
            Orders = new ObservableCollection<Order>
            {
                new Order { OrderID = 1001, CustomerName = "Michael Johnson", Quantity = 10, Price = 250.00 },
                new Order { OrderID = 1002, CustomerName = "Emily Davis", Quantity = 5, Price = 100.00 },
                new Order { OrderID = 1003, CustomerName = "Christopher Brown", Quantity = 12, Price = 300.00 },
                new Order { OrderID = 1004, CustomerName = "Sarah Taylor", Quantity = 8, Price = 200.00 },
                new Order { OrderID = 1005, CustomerName = "James Miller", Quantity = 15, Price = 375.00 },
                new Order { OrderID = 1006, CustomerName = "Olivia Wilson", Quantity = 20, Price = 500.00 },
                new Order { OrderID = 1007, CustomerName = "Benjamin Moore", Quantity = 25, Price = 625.00 },
                new Order { OrderID = 1008, CustomerName = "Sophia Anderson", Quantity = 30, Price = 750.00 },
                new Order { OrderID = 1009, CustomerName = "Alexander Thomas", Quantity = 18, Price = 450.00 },
                new Order { OrderID = 1010, CustomerName = "Isabella Martinez", Quantity = 7, Price = 175.00 },
                new Order { OrderID = 1011, CustomerName = "Daniel Harris", Quantity = 14, Price = 350.00 },
                new Order { OrderID = 1012, CustomerName = "Victoria Martin", Quantity = 22, Price = 550.00 },
                new Order { OrderID = 1013, CustomerName = "Matthew White", Quantity = 16, Price = 400.00 },
                new Order { OrderID = 1014, CustomerName = "Emma Thompson", Quantity = 24, Price = 600.00 },
                new Order { OrderID = 1015, CustomerName = "Liam Garcia", Quantity = 9, Price = 225.00 },
                new Order { OrderID = 1016, CustomerName = "Ava Clark", Quantity = 13, Price = 325.00 },
                new Order { OrderID = 1017, CustomerName = "Noah Lewis", Quantity = 21, Price = 525.00 },
                new Order { OrderID = 1018, CustomerName = "Charlotte Young", Quantity = 11, Price = 275.00 },
                new Order { OrderID = 1019, CustomerName = "Ethan Walker", Quantity = 19, Price = 475.00 },
                new Order { OrderID = 1020, CustomerName = "Amelia Hall", Quantity = 17, Price = 425.00 },
                new Order { OrderID = 1021, CustomerName = "Lucas Allen", Quantity = 6, Price = 150.00 },
                new Order { OrderID = 1022, CustomerName = "Mia Scott", Quantity = 28, Price = 700.00 },
                new Order { OrderID = 1023, CustomerName = "William Wright", Quantity = 23, Price = 575.00 },
                new Order { OrderID = 1024, CustomerName = "Harper Adams", Quantity = 4, Price = 100.00 },
                new Order { OrderID = 1025, CustomerName = "Ella Baker", Quantity = 3, Price = 75.00 }
            };
        }
    }

}
