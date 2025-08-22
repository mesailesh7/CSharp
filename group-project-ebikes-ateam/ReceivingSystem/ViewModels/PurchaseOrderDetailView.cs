﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceivingSystem.ViewModels
{
    public class PurchaseOrderDetailView
    {
        public int PurchaseOrderDetailID { get; set; }
        public int PurchaseOrderID { get; set; }
        public int PartID { get; set; }
        public int Quantity { get; set; }  
        public decimal PurchasePrice { get; set; }
        public string? VendorPartNumber { get; set; }
        public bool RemoveFromViewFlag { get; set; }
    }
}
