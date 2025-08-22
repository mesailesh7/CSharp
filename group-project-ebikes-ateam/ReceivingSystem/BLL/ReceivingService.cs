using Microsoft.EntityFrameworkCore;
using ReceivingSystem.DAL;
using ReceivingSystem.Entities;
using ReceivingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceivingSystem.BLL
{
    public class ReceivingService
    {
        private readonly eBikeContext _eBikeContext;
        protected string Feedback { get; set; } = string.Empty;
        protected string ErrorMessage { get; set; } = string.Empty;
        protected List<string> ErrorMsgs { get; set; } = new();

        internal ReceivingService(eBikeContext eBikeContext)
        {
            _eBikeContext = eBikeContext ?? throw new ArgumentNullException(nameof(eBikeContext));
        }

        #region
       
        public List<PurchaseOrderView> GetOutstandingPurchaseOrders()
        {
            return _eBikeContext.PurchaseOrders
                       .Include(po => po.Vendor)
                .Where(po => !po.Closed
                     && po.OrderDate != null
                     && po.RemoveFromViewFlag == false)
                .OrderBy(po => po.OrderDate)
                .Select(po => new PurchaseOrderView
                {
                    PurchaseOrderId = po.PurchaseOrderID,
                    OrderDate = po.OrderDate,
                    Vendor = po.Vendor.VendorName,
                    ContactNumber = po.Vendor.Phone
                })
                .ToList();
        }

        //public List<OrderDetailView> GetOrderDetails(int poId)
        //{
        //    return _eBikeContext.PurchaseOrderDetails
        //        .Include(d => d.Part)
        //        .Include(d => d.ReceiveOrderDetails)
        //        .Include(d => d.ReturnedOrderDetails)
        //        .Where(d => d.PurchaseOrderID == poId)
        //        .OrderBy(d => d.PartID)
        //        .Select(d => new OrderDetailView
        //        {
        //            PartId = d.PartID,
        //            Description = d.Part.Description,
        //            OrderQty = d.Quantity,

        //            ReceivedToDate = d.ReceiveOrderDetails.Sum(r => (int?)r.QuantityReceived) ?? 0,
        //            ReturnedToDate = d.ReturnedOrderDetails.Sum(r => (int?)r.Quantity) ?? 0,
        //            Outstanding = d.Quantity - (d.ReceiveOrderDetails.Sum(r => (int?)r.QuantityReceived) ?? 0),

        //            LastReturnReason = d.ReturnedOrderDetails
        //                                   .OrderByDescending(r => r.ReturnedOrderDetailID)
        //                                   .Select(r => r.Reason)
        //                                   .FirstOrDefault() ?? string.Empty,

        //            Received = 0,
        //            Returned = 0,
        //            Reason = string.Empty,
        //            HasError = false
        //        })
        //        .ToList();
        //}


        //for reset form
        //public List<OrderDetailView> GetOrderDetailsFresh(int poId)
        //{

        //    return _eBikeContext.PurchaseOrderDetails
        //        .AsNoTracking()
        //        .Include(d => d.Part)
        //        .Include(d => d.ReceiveOrderDetails)
        //        .Include(d => d.ReturnedOrderDetails)
        //        .Where(d => d.PurchaseOrderID == poId)
        //        .OrderBy(d => d.PartID)
        //        .Select(d => new OrderDetailView
        //        {
        //            PartId = d.PartID,
        //            Description = d.Part.Description,
        //            OrderQty = d.Quantity,

        //            ReceivedToDate = d.ReceiveOrderDetails.Sum(r => (int?)r.QuantityReceived) ?? 0,
        //            ReturnedToDate = d.ReturnedOrderDetails.Sum(r => (int?)r.Quantity) ?? 0,
        //            Outstanding = d.Quantity - (d.ReceiveOrderDetails.Sum(r => (int?)r.QuantityReceived) ?? 0),

        //            LastReturnReason = d.ReturnedOrderDetails
        //                                   .OrderByDescending(r => r.ReturnedOrderDetailID)
        //                                   .Select(r => r.Reason)
        //                                   .FirstOrDefault() ?? string.Empty,

        //            Received = 0,
        //            Returned = 0,
        //            Reason = string.Empty
        //        })
        //        .ToList();
        //}


        public List<OrderDetailView> GetOrderDetails(int poId)
        {
            return _eBikeContext.PurchaseOrderDetails
                .Include(d => d.Part)
                .Include(d => d.ReceiveOrderDetails)
                .Include(d => d.ReturnedOrderDetails)
                .Where(d => d.PurchaseOrderID == poId)
                .OrderBy(d => d.PartID)
                .Select(d => new OrderDetailView
                {
                    PartId = d.PartID,
                    Description = d.Part.Description,
                    OrderQty = d.Quantity,
                    PurchaseOrderId = d.PurchaseOrderID,
                    PurchaseOrderDetailID = d.PurchaseOrderDetailID, 
                    ReceivedToDate = d.ReceiveOrderDetails.Sum(r => (int?)r.QuantityReceived) ?? 0,
                    ReturnedToDate = d.ReturnedOrderDetails.Sum(r => (int?)r.Quantity) ?? 0,
                    Received = d.ReceiveOrderDetails.Sum(r => (int?)r.QuantityReceived) ?? 0,
                    Returned = d.ReturnedOrderDetails.Sum(r => (int?)r.Quantity) ?? 0,
                    LastReturnReason = d.ReturnedOrderDetails
                                  .OrderByDescending(r => r.ReturnedOrderDetailID)
                                  .Select(r => r.Reason)
                                  .FirstOrDefault() ?? string.Empty,
                    Reason = string.Empty,
                    HasError = false
                })
                .ToList();
        }

        public List<OrderDetailView> GetOrderDetailsFresh(int poId)
        {
            return _eBikeContext.PurchaseOrderDetails
                .AsNoTracking()
                .Include(d => d.Part)
                .Include(d => d.ReceiveOrderDetails)
                .Include(d => d.ReturnedOrderDetails)
                .Where(d => d.PurchaseOrderID == poId)
                .OrderBy(d => d.PartID)
                .Select(d => new OrderDetailView
                {
                    PartId = d.PartID,
                    Description = d.Part.Description,
                    OrderQty = d.Quantity,
                    PurchaseOrderId = d.PurchaseOrderID,
                    PurchaseOrderDetailID = d.PurchaseOrderDetailID, 
                    ReceivedToDate = d.ReceiveOrderDetails.Sum(r => (int?)r.QuantityReceived) ?? 0,
                    ReturnedToDate = d.ReturnedOrderDetails.Sum(r => (int?)r.Quantity) ?? 0,
                    Received = d.ReceiveOrderDetails.Sum(r => (int?)r.QuantityReceived) ?? 0,
                    Returned = d.ReturnedOrderDetails.Sum(r => (int?)r.Quantity) ?? 0,
                    LastReturnReason = d.ReturnedOrderDetails
                                  .OrderByDescending(r => r.ReturnedOrderDetailID)
                                  .Select(r => r.Reason)
                                  .FirstOrDefault() ?? string.Empty,
                    Reason = string.Empty
                })
                .ToList();
        }





        public PurchaseOrderHeaderView? GetPurchaseOrderHeader(int poId)
        {
            var po = _eBikeContext.PurchaseOrders
                .Include(p => p.Vendor)
               .FirstOrDefault(p => p.PurchaseOrderID == poId
                             && !p.Closed
                             && p.OrderDate != null
                             && p.RemoveFromViewFlag == false);


            if (po == null) return null;

            return new PurchaseOrderHeaderView
            {
                PurchaseOrderId = po.PurchaseOrderID,
                OrderDate = po.OrderDate,
                Vendor = po.Vendor?.VendorName ?? "Unknown Vendor",
                ContactNumber = po.Vendor?.Phone ?? "N/A"
            };
        }


        #endregion

        public async Task SaveReceiveChangesAsync(List<OrderDetailView> orderDetails, List<UnorderedItemView> unorderedItems, string UserId)
        {
            try
            {
                // Step 1: Insert a new ReceiveOrder
                var receiveOrder = new ReceiveOrder
                {
                    PurchaseOrderID = orderDetails.First().PurchaseOrderId,
                    ReceiveDate = DateTime.Now,
                    EmployeeID = UserId, 
                    RemoveFromViewFlag = false
                };

                _eBikeContext.ReceiveOrders.Add(receiveOrder);
                await _eBikeContext.SaveChangesAsync(); 

                var receiveOrderId = receiveOrder.ReceiveOrderID;

                // Step 2: Insert ReceiveOrderDetails
                foreach (var orderDetail in orderDetails)
                {
                    if (orderDetail.PurchaseOrderDetailID != 0)
                    {
                        var purchaseOrderDetailExists = await _eBikeContext.PurchaseOrderDetails
                            .AnyAsync(pod => pod.PurchaseOrderDetailID == orderDetail.PurchaseOrderDetailID);

                        if (!purchaseOrderDetailExists)
                        {
                            Console.WriteLine($"Invalid PurchaseOrderDetailID: {orderDetail.PurchaseOrderDetailID} does not exist.");
                            continue;
                        }

                        var receiveOrderDetail = new ReceiveOrderDetail
                        {
                            ReceiveOrderID = receiveOrderId,
                            PurchaseOrderDetailID = orderDetail.PurchaseOrderDetailID,
                            QuantityReceived = orderDetail.Received
                        };

                        _eBikeContext.ReceiveOrderDetails.Add(receiveOrderDetail);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid PurchaseOrderDetailID: {orderDetail.PurchaseOrderDetailID}");
                    }
                }

                // Step 3: Update the Parts table
                foreach (var orderDetail in orderDetails)
                {
                    var part = await _eBikeContext.Parts
                        .FirstOrDefaultAsync(p => p.PartID == orderDetail.PartId);

                    if (part != null)
                    {
                        part.QuantityOnHand += orderDetail.Received; 
                    }
                }

                await _eBikeContext.SaveChangesAsync();

                // Step 4: Insert ReturnedOrderDetails for any returned items
                foreach (var orderDetail in orderDetails)
                {
                    if (orderDetail.Returned > 0)
                    {
                        var returnedOrderDetail = new ReturnedOrderDetail
                        {
                            ReceiveOrderID = receiveOrderId,
                            PurchaseOrderDetailID = orderDetail.PurchaseOrderDetailID,
                            Quantity = orderDetail.Returned,
                            Reason = orderDetail.Reason
                        };
                        _eBikeContext.ReturnedOrderDetails.Add(returnedOrderDetail);
                    }
                }

                // Step 5: Insert Unordered Items
                foreach (var unordered in unorderedItems)
                {
                    var unorderedEntity = new UnorderedPurchaseItemCart
                    {
                        ReceiveOrderID = receiveOrderId,
                        Description = unordered.Description,
                        VendorPartNumber = unordered.VendorPartId,
                        Quantity = unordered.Quantity,
                        RemoveFromViewFlag = false 
                    };
                    _eBikeContext.UnorderedPurchaseItemCarts.Add(unorderedEntity);
                }

                await _eBikeContext.SaveChangesAsync();

                Feedback = "Changes saved successfully.";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error while saving: {ex.Message}";
                if (ex.InnerException != null)
                {
                    ErrorMessage += $" Inner Exception: {ex.InnerException.Message}";
                }
            }
        }

        public async Task ForceClosePurchaseOrderAsync(int poId, string reason)
        {
            var po = await _eBikeContext.PurchaseOrders.FindAsync(poId);
            if (po != null)
            {
                po.Closed = true;
                po.Notes = reason; 
                await _eBikeContext.SaveChangesAsync();
            }
        }
    }
}
