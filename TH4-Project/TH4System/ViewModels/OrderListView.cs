using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH4System.ViewModels
{
    public class OrderListView
    {
        public int OrderListID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string Product { get; set; } = string.Empty;
        public double QtyOrdered { get; set; }
        public double? QtyPicked { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string? CustomerComment { get; set; }
        public string? PickIssue { get; set; }
    }
}
