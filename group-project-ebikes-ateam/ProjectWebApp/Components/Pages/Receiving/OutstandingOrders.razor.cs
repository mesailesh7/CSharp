using Microsoft.AspNetCore.Components;
using MudBlazor;
using ReceivingSystem.BLL;
using ReceivingSystem.ViewModels;

namespace ProjectWebApp.Components.Pages.Receiving
{
    public partial class OutstandingOrders
    {
        #region Fields
        private string Feedback = string.Empty;
        private string ErrorMessage = string.Empty;
        private List<string> ErrorMsgs = new();
        private bool hasFeedback => !string.IsNullOrWhiteSpace(Feedback);
        private bool hasError => !string.IsNullOrWhiteSpace(ErrorMessage);
        #endregion

        #region Properties
        [Inject] protected ReceivingService ReceivingService { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

        [Inject] protected IDialogService DialogService { get; set; } = default!;
        protected List<PurchaseOrderView> purchaseOrders { get; set; } = new();
        #endregion

        #region Methods
        protected override void OnInitialized()
        {
            try
            {
                purchaseOrders = ReceivingService.GetOutstandingPurchaseOrders();
                if (!purchaseOrders.Any())
                {
                    Feedback = "No outstanding purchase orders available.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected void ViewOrder(int poId)
        {
            NavigationManager.NavigateTo($"/receiving/checkin/{poId}");
        }



        private async Task OnCloseAsync()
        {
            bool? confirm = await DialogService.ShowMessageBox(
                "Confirm Close",
                "Are you sure you want to close and return to the main menu?",
                yesText: "Yes, Close",
                cancelText: "No, Stay");

            if (confirm == true)
            {
                NavigationManager.NavigateTo("/");
            }
        }
        #endregion
    }
}