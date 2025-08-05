using Microsoft.AspNetCore.Components;
using TH4System.BLL;
using TH4System.ViewModels;

namespace TH4Web.Components.Pages.Grocery
{
    public partial class OrderList
    {
        #region Fields
        private string feedback = string.Empty;
        private string errorMessage = string.Empty;

        protected List<OrderView> Order { get; set; } = new List<OrderView>();
        #endregion

       

        #region Properties
        [Inject]
        protected OrderService OrderService { get; set; }


        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        #endregion
        #region Methods
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var result = OrderService.GetOrders();
            if(result.IsSuccess)
            {
                Order = result.Value;
            }

            await InvokeAsync(StateHasChanged);
        }
        #endregion



        private void EditOrder(int orderID)
        {
            NavigationManager.NavigateTo($"/Grocery/OrderPicking/{orderID}");
        }


    }
}
