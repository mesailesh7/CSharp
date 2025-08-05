#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH4System.ViewModels
{
    public class PickerView
    {
        public int PickerID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public bool Active { get; set; }
        public int StoreID { get; set; }
    }
}
