using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH4System.ViewModels
{
    public class OrderView
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreID { get; set; }
        public string? Location { get; set; }
        public int CustomerID { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int? PickerID { get; set; }
        public DateTime? PickedDate { get; set; }
        public bool Delivery { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GST { get; set; }
        // NOTE: When retrieving the Orders for the web page "Orders", do not retreived the "OrderListView" details.
        //       Only retreived the OrderList details when you are updating the picking information.
        public List<OrderListView> OrderList { get; set; } = new();
    }
}
