using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BYSResults;
using TH4System.DAL;
using TH4System.ViewModels;

namespace TH4System.BLL
{
    public class OrderPickService
    {
        private readonly GroceryListContext _groceryListContext;

        internal OrderPickService(GroceryListContext groceryListContext)
        {
            _groceryListContext = groceryListContext;
        }



        public IEnumerable<PickerView> GetPicker(int storeId)
        {
            return _groceryListContext.Pickers
                .Where(p => p.StoreID == storeId && p.Active)
                .Select(x => new PickerView
                {
                    PickerID = x.PickerID,
                    FullName = $"{x.FirstName} {x.LastName}"
                }).ToList();
        }

        public Result<OrderView> GetOrderDetails(int orderID)
        {
            var result = new Result<OrderView>();

            if (orderID <= 0)
            {
                result.AddError(
                    new Error("Missing information", "Please provide a valid customer ID")
                );

                return result;
            }

            var order = _groceryListContext
                .Orders
                .Where(o => o.OrderID == orderID)
                .Select(o => new OrderView
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
                    SubTotal = o.SubTotal,
                    GST = o.GST,
                    OrderList = o
                        .OrderLists.Select(ol => new OrderListView
                        {
                            OrderListID = ol.OrderListID,
                            OrderID = ol.OrderID,
                            ProductID = ol.ProductID,
                            Product = ol.Product.Description,
                            QtyOrdered = ol.QtyOrdered,
                            QtyPicked = ol.QtyPicked,
                            Price = ol.Price,
                            CustomerComment = ol.CustomerComment,
                            Discount = ol.Discount,
                            PickIssue = ol.PickIssue,
                        })
                        .ToList(),
                })
                .OrderBy(o => o.OrderID)
                .FirstOrDefault();

            if (order == null)
            {
                result.AddError(new Error("No Order", "No Orders were found"));

                return result;
            }


            return result.WithValue(order);
        }


        public Result<OrderView> AddEditPicker(OrderView orderView)
        {
            var result = new Result<OrderView>();



            if(orderView == null)
            {
                result.AddError(new Error("Missing Order",
                                   "No order was supply"));
                
                return result;
            }

            var order = _groceryListContext.Orders.Find(orderView.OrderID);

            if(order == null)
            {
                result.AddError(new Error("Order not found", $"The order with ID {orderView.OrderID} could not be found"));
                return result;
            }

             
            if(orderView.PickerID == null || orderView.PickerID == 0)
            {
                result.AddError(new Error("Picker not selected", "A picker must be selected before the order can be saved"));
            }

            if (order.Delivery)
            {
                result.AddError(new Error("Order Delivered", "Order that have been delivered cannot be modified"));
            }


            if (orderView.OrderList.All(ol => ol.QtyPicked == null || ol.QtyPicked == 0))
            {
                result.AddError(new Error("No items picked", "At least one item must be picked before before saving the order"));
            }

            foreach (var item in orderView.OrderList)
            {
                if (item.QtyPicked < 0)
                {
                    result.AddError(new Error("Invalid pick qty", "At least one item must be picked before saving"));
                }

                if (item.QtyPicked > item.QtyOrdered)
                {
                    result.AddError(new Error("Invalid pick quantity", $"Picked quantity for product: {item.Product} exceeds ordered quantity"));
                }
            }


            if (result.IsFailure)
            {
                return result;
            }


            order.PickerID = orderView.PickerID;
            order.PickedDate = orderView.PickedDate;


            foreach (var orderList in orderView.OrderList)
            {
                var orderItem = _groceryListContext.OrderLists.Find(orderList.OrderListID);

                if (orderItem != null)
                {
                    orderItem.QtyPicked = orderList.QtyPicked;
                    orderItem.PickIssue = orderList.PickIssue;
                }
            }

            try
            {
                _groceryListContext.SaveChanges();

            }
            catch (Exception ex) {

                _groceryListContext.ChangeTracker.Clear();
                result.AddError(new Error("Error saving changes", ex.InnerException.Message));

                return result;

            }

            return GetOrderDetails(order.OrderID);

        }

        public Result<OrderView> DeliverOrder(OrderView orderView)
        {
            var result = new Result<OrderView>();

            if (orderView == null)
            {
                result.AddError(new Error("Missing Order",
                                   "No order was supply"));

                return result;
            }

            var order = _groceryListContext.Orders.Find(orderView.OrderID);

            if (order == null)
            {
                result.AddError(new Error("Order not found", $"The order with ID {orderView.OrderID} could not be found"));
                return result;
            }

            order.Delivery = orderView.Delivery;
            order.PickedDate = orderView.Delivery ? DateTime.Now : null;

            try
            {
                _groceryListContext.SaveChanges();

            }
            catch (Exception ex)
            {

                _groceryListContext.ChangeTracker.Clear();
                result.AddError(new Error("Error saving changes", ex.InnerException.Message));

                return result;

            }

            return GetOrderDetails(order.OrderID);
        }

    }
}
