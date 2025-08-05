using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using BYSResults;
using TH4System.DAL;
using TH4System.Entities;
using TH4System.ViewModels;

namespace TH4System.BLL
{
    public class OrderService
    {
        private readonly GroceryListContext _groceryListContext;

        internal OrderService(GroceryListContext groceryListContext)
        {
            _groceryListContext = groceryListContext;
        }

        public Result<List<OrderView>> GetOrders()
        {
            var result = new Result<List<OrderView>>();

            var orders = _groceryListContext
                .Orders.Select(o => new OrderView
                {
                    OrderID = o.OrderID,
                    OrderDate = o.OrderDate,
                    StoreID = o.StoreID,
                    Location = o.Store.Location,
                    CustomerID = o.CustomerID,
                    Customer = $"{o.Customer.FirstName} {o.Customer.LastName}",
                    Phone = o.Customer.Phone,
                    PickerID = o.PickerID,
                    PickedDate = o.PickedDate,
                    Delivery = o.Delivery,
                    SubTotal = Math.Round(o.SubTotal, 2, MidpointRounding.AwayFromZero),
                    GST = Math.Round(o.GST, 2, MidpointRounding.AwayFromZero),
                })
                .OrderBy(o => o.OrderID)
                .ToList();

            if (orders == null || orders.Count() == 0)
            {
                result.AddError(new Error("No Orders", "No orders were found"));

                return result;
            }

            return result.WithValue(orders);
        }

       
    }
}
