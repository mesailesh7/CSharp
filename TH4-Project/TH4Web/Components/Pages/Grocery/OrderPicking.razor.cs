using BYSResults;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using TH4System.BLL;
using TH4System.ViewModels;

namespace TH4Web.Components.Pages.Grocery
{
    public partial class OrderPicking
    {
        private OrderView OrderView = new();
        private MudForm pickerForm = new();
        private IEnumerable<PickerView> pickers = new List<PickerView>();


        #region Feedback & Error Messages
        // The feedback message
        private string feedbackMessage = string.Empty;

        // The error message
        private string? errorMessage = string.Empty;

        // has feedback
        private bool hasFeedback => !string.IsNullOrWhiteSpace(feedbackMessage);

        // has error
        private bool hasError => !string.IsNullOrWhiteSpace(errorMessage) || errorDetails.Any();

        // error details
        private List<string> errorDetails = new();
        #endregion


        [Inject]
        protected OrderPickService OrderService { get; set; } = default!;

        [Inject]
        protected IDialogService DialogService { get; set; } = default!;

        [Inject]
        protected NavigationManager NavigationManager { get; set; } = default;

        [Parameter]
        public int orderID { get; set; }


        private bool isFormValid;
        private bool hasDataChanged = false;

        private string closeButtonText => hasDataChanged ? "Cancel" : "Close";

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            try
            {
                errorDetails.Clear();
                errorMessage = string.Empty;
                feedbackMessage = string.Empty;


                if (orderID > 0)
                {
                    var result = OrderService.GetOrderDetails(orderID);

                    if (result.IsSuccess)
                    {
                        OrderView = result.Value;
                        pickers = OrderService.GetPicker(OrderView.StoreID);
                    }

                }
            }
            catch (Exception ex)
            {
                errorMessage = BlazorHelperClass.GetInnerException(ex).Message;
            }
        }

        private async Task SetDelivery()
        {
            //  NOTE:  NOT ALL CODE HAS BEEN PROVIDED FOR THIS METHOD

            
            hasDataChanged = true;
            await pickerForm.Validate();
            if (isFormValid)
            {
                bool? results = await DialogService.ShowMessageBox("Confirm Save", "Are you sure this delivery is close? Please confirm before saving, because once an order has been delivered you cannot edit it again.", yesText: "Yes", cancelText: "No");
                if (results == true)
                {
                    try
                    {
                        OrderView.Delivery = true;
                        var result = OrderService.DeliverOrder(OrderView);

                        if (result.IsSuccess)
                        {
                            OrderView = result.Value;
                            feedbackMessage = "Data was successfully saved";
                            hasDataChanged = false;
                            isFormValid = false;
                        }
                        else
                        {
                            errorDetails = BlazorHelperClass.GetErrorMessages(result.Errors.ToList());
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }
            StateHasChanged(); // Ensure UI updates immediately

        }

        private async Task OnQtyPickedChanged(OrderListView item, double? newValue)
        {
            item.QtyPicked = newValue;
            await pickerForm.Validate();
            hasDataChanged = true; // Force form state change
            StateHasChanged(); // Ensure UI updates immediately
        }

        private async Task OnPickIssueChanged(OrderListView item, string newValue)
        {
            item.PickIssue = newValue;
            await pickerForm.Validate();
            hasDataChanged = true; // Force form state change
            StateHasChanged(); // Ensure UI updates immediately
        }

        private void Save()
        {
            errorDetails.Clear();
            errorMessage = string.Empty;
            feedbackMessage = string.Empty;

            try
            {
                var result = OrderService.AddEditPicker(OrderView);
                if (result.IsSuccess)
                {
                    OrderView = result.Value;
                    feedbackMessage = "Data was successfully saved";
                    hasDataChanged = false;
                    isFormValid = false;

                }
                else
                {
                    errorDetails = BlazorHelperClass.GetErrorMessages(result.Errors.ToList());
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        private async Task Close()
        {
            if (hasDataChanged)
            {
                bool? results = await DialogService.ShowMessageBox("Confirm Cancel",
                                $"Do you wish to close the picker editor? All unsaved changes will be lost.",
                                yesText: "Yes", cancelText: "No");

                if (results == null)
                {
                    return;
                }

                NavigationManager.NavigateTo($"/Grocery/OrderList");
            }
            else
            {
                NavigationManager.NavigateTo($"/Grocery/OrderList");
            }
        }

        private async Task Clear()
        {
            
                bool? results = await DialogService.ShowMessageBox("Confirm Clear", $"Do you wish to clear the picker editor? All unsaved changes will be lost.", yesText: "Yes", cancelText: "No");

                if (results == true)
                {
                    OrderView.PickerID = null;
                    OrderView.PickedDate = null;
                    OrderView.Delivery = false;

                    foreach (var item in OrderView.OrderList)
                    {
                        item.QtyPicked = 0;
                        item.PickIssue = "";
                    }
                    var result = OrderService.DeliverOrder(OrderView);
                    if (result.IsSuccess)
                    {
                        OrderView = result.Value;
                        feedbackMessage = "Data was successfully cleared";
                        hasDataChanged = false;
                        isFormValid = false;
                    }
                    else
                    {
                        errorDetails = BlazorHelperClass.GetErrorMessages(result.Errors.ToList());
                    }
                }

                hasDataChanged = true;
                StateHasChanged();

            



        }



    }
}
