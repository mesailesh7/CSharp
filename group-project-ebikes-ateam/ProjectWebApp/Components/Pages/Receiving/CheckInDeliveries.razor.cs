using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using ReceivingSystem.BLL;
using ReceivingSystem.ViewModels;

namespace ProjectWebApp.Components.Pages.Receiving
{
    public partial class CheckInDeliveries
    {

        #region Fields
        [Parameter] public int poId { get; set; }

        //data models
        protected PurchaseOrderHeaderView? poHeader;
        protected List<OrderDetailView> orderDetails = new();
        protected List<UnorderedItemView> unorderedItems = new();
        protected UnorderedItemView newUnordered = new();

        protected string forceCloseReason = string.Empty;
        protected string UserFullName { get; set; } = string.Empty;
        protected string UserId { get; set; } = string.Empty;

        protected string UserRole { get; set; } = string.Empty;

        private MudForm? receivingForm;

        #endregion

        #region Feedback / Error Messages
        //alerts
        protected string Feedback { get; set; } = string.Empty;
        protected string ErrorMessage { get; set; } = string.Empty;
        protected List<string> ErrorMsgs { get; set; } = new();
       

        //validation flags
        private bool _isValid;    
        private bool _hasChanges;
        private bool _unorderedQtyError;
      //  private bool _confirmReceive = false; 

        #endregion

        #region Properties
        [Inject] protected ReceivingService ReceivingService { get; set; } = default!;
        [Inject] protected IDialogService DialogService { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        #endregion


        private bool _showSaveCancelButtons = false;


        #region Helpers


        private bool HasPOChanges() =>
            orderDetails.Any(d =>
                d.Received > 0 ||
                d.Returned > 0 ||
                (d.Returned > 0 && !string.IsNullOrWhiteSpace(d.Reason)));

        // Unordered table
        private bool HasUnorderedChanges() => unorderedItems.Any();

       
        private bool AnyChanges() =>
            HasPOChanges() || HasUnorderedChanges() || !string.IsNullOrWhiteSpace(forceCloseReason);

      
        private static bool HasRowError(OrderDetailView d) =>
            d.Received < 0 ||
            d.Received > d.OutstandingBase ||
            d.Returned < 0 ||
            (d.Returned > 0 && string.IsNullOrWhiteSpace(d.Reason));

      
        private bool HasErrors => _unorderedQtyError || orderDetails.Any(HasRowError);

     
        private bool CanReceive =>
    _isValid &&
    (HasPOChanges() || HasUnorderedChanges() || !string.IsNullOrWhiteSpace(forceCloseReason)) &&
    !HasErrors;

        private void MarkChanged()
        {
            _hasChanges = AnyChanges();       
            _ = receivingForm?.Validate();
            StateHasChanged();
        }




        private bool IsUnorderedValid() =>
        !string.IsNullOrWhiteSpace(newUnordered.Description)
        && !string.IsNullOrWhiteSpace(newUnordered.VendorPartId)
        && newUnordered.Quantity >= 1;

        #endregion




        #region Lifecycle
        protected override void OnInitialized()
        {
            try
            {
                poHeader = ReceivingService.GetPurchaseOrderHeader(poId);
                orderDetails = ReceivingService.GetOrderDetails(poId) ?? new List<OrderDetailView>();
                PrefillEditableFromDbTotals();

               
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error loading PO {poId}: {ex.Message}";
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            UserFullName = user.FindFirst("FullName")?.Value ?? "Unknown User";
            UserRole = user.FindFirst("role")?.Value ?? "";
            UserId = user.FindFirst("EmployeeID")?.Value ?? "";
        }

        #endregion

        #region Actions

        private void OnReceive()
        {
            ErrorMessage = string.Empty;
            ErrorMsgs.Clear();
            Feedback = string.Empty;

          
            if (!HasPOChanges() && !HasUnorderedChanges() && string.IsNullOrWhiteSpace(forceCloseReason))
            {
                ErrorMessage = "Nothing to receive. Enter a Received/Returned quantity or add an unordered item.";
                StateHasChanged();
                return;
            }

            if (HasErrors)
            {
                ErrorMessage = "Validation failed. Please fix the errors below.";
                StateHasChanged();
                return;
            }

            foreach (var detail in orderDetails)
            {
                if (detail.Received < 0)
                    ErrorMsgs.Add($"Part {detail.PartId}: Received cannot be negative.");

                if (detail.Received > detail.OutstandingBase)
                    ErrorMsgs.Add($"Part {detail.PartId}: Received ({detail.Received}) cannot exceed Outstanding ({detail.OutstandingBase}).");

                if (detail.Returned < 0)
                    ErrorMsgs.Add($"Part {detail.PartId}: Returned cannot be negative.");

                if (detail.Returned > detail.OrderQty)
                    ErrorMsgs.Add($"Part {detail.PartId}: Returned ({detail.Returned}) cannot exceed Ordered ({detail.OrderQty}).");

                if (detail.Returned > 0 && string.IsNullOrWhiteSpace(detail.Reason))
                    ErrorMsgs.Add($"Part {detail.PartId}: Reason required when returning items.");
            }

            if (_unorderedQtyError)
                ErrorMsgs.Add("Unordered Item: Quantity must be greater than zero.");

            if (ErrorMsgs.Any())
            {
                ErrorMessage = "Validation failed. Please fix the errors below.";
            }
            else
            {
                Feedback = "Items successfully validated.";
                _showSaveCancelButtons = true; 
            }

            StateHasChanged();
        }



        private async Task OnForceCloseAsync()
        {
            if (string.IsNullOrWhiteSpace(forceCloseReason))
            {
                ErrorMessage = "Reason required to force close an order.";
                StateHasChanged();
                return;
            }

            var confirm = await DialogService.ShowMessageBox(
                "Confirm Force Close",
                $"Are you sure you want to force close this order for reason: '{forceCloseReason}'?",
                yesText: "Yes, Force Close",
                cancelText: "Cancel",
                options: new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true }
            );

            if (confirm == true)
            {
                try
                {
                    await ReceivingService.SaveReceiveChangesAsync(orderDetails, unorderedItems, UserId);
                    await ReceivingService.ForceClosePurchaseOrderAsync(poId, forceCloseReason);

                    Feedback = $"Order force closed for reason: {forceCloseReason}.";
                    ErrorMessage = string.Empty;
                    ErrorMsgs.Clear();
                    _hasChanges = false;
                    await ResetFormAsync();
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Error while force closing: {ex.Message}";
                }
                StateHasChanged();
            }
        }

        private async Task OnResetAsync()
        {
            bool? result = await DialogService.ShowMessageBox(
                "Confirm Reset",
                "Are you sure you want to reset all changes? This action cannot be undone.",
                yesText: "Yes, Reset",
                cancelText: "Cancel",
                options: new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small });

            if (result == true)
            {
                Feedback = "Form has been reset.";
                await ResetFormAsync();  
            }
        }




  
        private async Task ResetFormAsync()
        {
            try
            {
              
                poHeader = ReceivingService.GetPurchaseOrderHeader(poId);
                orderDetails = ReceivingService.GetOrderDetailsFresh(poId) ?? new();
                PrefillEditableFromDbTotals();

              
                unorderedItems.Clear();
                newUnordered = new UnorderedItemView();
                forceCloseReason = string.Empty;

                ErrorMsgs.Clear();
                ErrorMessage = string.Empty;
                Feedback = "Form has been reset.";
                _hasChanges = false;
                _unorderedQtyError = false;

               
                if (receivingForm is not null)
                {
                    receivingForm.ResetValidation();
                    await receivingForm.Validate();
                }

                StateHasChanged();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Reset failed: {ex.Message}";
            }
        }






        #endregion

        #region Live handlers
        //live validation for PO







        private void OnReceivedChanged(OrderDetailView row, int newValue)
        {
            ErrorMsgs.RemoveAll(e => e.StartsWith($"Part {row.PartId}: Received"));

            row.Received = newValue;

            string? err = null;
            if (newValue < 0)
                err = "Received cannot be negative.";
            else if (newValue > row.OutstandingBase)
                err = $"Received cannot exceed Outstanding ({row.OutstandingBase}).";

            if (err != null) ErrorMsgs.Add($"Part {row.PartId}: {err}");

            ErrorMessage = ErrorMsgs.Any() ? "Validation failed. Please fix the errors below." : string.Empty;

            MarkChanged(); 
        }


        private void OnReasonChanged(OrderDetailView context, string newValue)
        {
            context.Reason = newValue;
            RefreshValidation(context);
            MarkChanged();
            _ = receivingForm?.Validate();
        }


        private void OnReturnedChanged(OrderDetailView r, int v)
        {
            r.Returned = v;

            if (v < 0)
            {
                ErrorMsgs.Add($"Part {r.PartId}: Returned cannot be negative.");
                ErrorMessage = "Validation failed. Please fix the errors below.";
            }
            else
            {
                ErrorMsgs.RemoveAll(e => e.StartsWith($"Part {r.PartId}: Returned"));
            }

            if (r.Returned > 0 && string.IsNullOrWhiteSpace(r.Reason))
            {
                ErrorMsgs.Add($"Part {r.PartId}: Reason required when returning items.");
                ErrorMessage = "Validation failed. Please fix the errors below.";
            }
            else
            {
                ErrorMsgs.RemoveAll(e => e.StartsWith($"Part {r.PartId}: Reason"));
            }

            RefreshValidation(r);
            MarkChanged();
            StateHasChanged();
        }


        #endregion

        #region Validation
      


        private void RefreshValidation(OrderDetailView r)
        {
            ErrorMsgs.RemoveAll(e => e.Contains($"Part {r.PartId}:"));

            if (r.Received < 0)
                ErrorMsgs.Add($"Part {r.PartId}: Received cannot be negative.");

       
            if (r.Received > r.OutstandingBase)
                ErrorMsgs.Add($"Part {r.PartId}: Received cannot exceed Outstanding ({r.OutstandingBase}).");

            if (r.Returned < 0)
                ErrorMsgs.Add($"Part {r.PartId}: Returned cannot be negative.");

            if (r.Returned > 0 && string.IsNullOrWhiteSpace(r.Reason))
                ErrorMsgs.Add($"Part {r.PartId}: Reason required when returning items.");

            ErrorMessage = ErrorMsgs.Any() ? "Validation failed. Please fix the errors below." : string.Empty;
            StateHasChanged();
        }



        //for unordered items
        private void OnUnorderedQtyChanged(int newValue)
        {
            newUnordered.Quantity = newValue;
            RefreshUnorderedValidation();
            StateHasChanged();
        }

       
        private void RefreshUnorderedValidation()
        {

            ErrorMsgs.RemoveAll(e => e.StartsWith("Unordered Item: Quantity", StringComparison.OrdinalIgnoreCase));

            if (newUnordered.Quantity <= 0)
            {
                _unorderedQtyError = true;
                ErrorMsgs.Add("Unordered Item: Quantity must be greater than zero.");
                ErrorMessage = "Validation failed. Please fix the errors below.";
            }
            else
            {
                _unorderedQtyError = false;


                if (!ErrorMsgs.Any()) ErrorMessage = string.Empty;
            }
        }
        #endregion

        #region Unordered Items Methods (Add, Clear, Remove)

        //Unordered Items Methods
        private void AddUnorderedItem()
        {
          
            ErrorMessage = string.Empty;
            ErrorMsgs.Clear();
            Feedback = string.Empty;

            if (string.IsNullOrWhiteSpace(newUnordered.Description))
                ErrorMsgs.Add("Unordered Item: Description is required.");
            if (string.IsNullOrWhiteSpace(newUnordered.VendorPartId))
                ErrorMsgs.Add("Unordered Item: Vendor Part ID is required.");
            if (newUnordered.Quantity <= 0)
                ErrorMsgs.Add("Unordered Item: Quantity must be greater than zero.");

            if (ErrorMsgs.Any())
            {
                ErrorMessage = "Validation failed. Please fix the errors below.";
                return;
            }

            unorderedItems.Add(new UnorderedItemView
            {
                Description = newUnordered.Description,

                VendorPartId = newUnordered.VendorPartId,
                Quantity = newUnordered.Quantity
            });

          
            newUnordered = new UnorderedItemView();
            Feedback = "Unordered item added successfully.";
            MarkChanged();

        }


        private async Task ClearNewUnordered()
        {
            bool? result = await DialogService.ShowMessageBox(
                "Confirm Clear",
                "Are you sure you want to clear the unordered item input? This action cannot be undone.",
                yesText: "Yes, Clear",
                cancelText: "Cancel",
                options: new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small }
            );

            if (result == true)
            {
                newUnordered = new UnorderedItemView();
                Feedback = "Unordered item input cleared.";
                ErrorMessage = string.Empty;
                ErrorMsgs.Clear();
                StateHasChanged();
            }
        }


        private async Task RemoveUnorderedItem(UnorderedItemView item)
        {
            bool? confirm = await DialogService.ShowMessageBox(
                "Confirm Delete",
                $"Are you sure you want to delete the unordered item: '{item.Description}'?",
                yesText: "Yes, Delete",
                cancelText: "Cancel",
                options: new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small }
            );

            if (confirm == true)
            {
                unorderedItems.Remove(item);
                Feedback = $"Unordered item '{item.Description}' removed.";
                ErrorMessage = string.Empty;
                ErrorMsgs.Clear();
                MarkChanged();
                StateHasChanged();
            }
        }

        #endregion


        //after resetting the form
       

        private void PrefillEditableFromDbTotals()
        {
            foreach (var d in orderDetails)
            {

                d.Received = 0;
                d.Returned = 0;
                d.Reason = string.Empty;
                d.HasEditedReceived = false;
            }
        }



        private bool IsValidOrderDetails(List<OrderDetailView> orderDetails)
        {
            return orderDetails.All(d => d.Received >= 0 && d.Received <= d.OutstandingBase);
        }

        //private async Task SaveReceiveChangesAsync()
        //{
        //    if (IsValidOrderDetails(orderDetails))
        //    {
        //        try
        //        {
        //            // Log or debug the order details for better inspection
        //            foreach (var detail in orderDetails)
        //            {
        //                Console.WriteLine($"PartId: {detail.PartId}, Received: {detail.Received}, OutstandingBase: {detail.OutstandingBase}");
        //            }

        //            // Proceed with saving the changes
        //            await ReceivingService.SaveReceiveChangesAsync(orderDetails);

        //            // Success message
        //            Feedback = "Changes saved successfully.";
        //        }
        //        catch (Exception ex)
        //        {
        //            // Catch the exception and provide detailed logging
        //            ErrorMessage = $"Error while saving: {ex.Message}";

        //            // Log the inner exception for more details if available
        //            if (ex.InnerException != null)
        //            {
        //                ErrorMessage += $" Inner Exception: {ex.InnerException.Message}";
        //                // Log the inner exception to the console for debugging purposes
        //                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
        //            }

        //            // Optionally log the stack trace for further investigation
        //            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        //        }
        //    }
        //    else
        //    {
        //        // If validation fails, display an error message
        //        ErrorMessage = "Validation failed. Please ensure all fields are correct.";
        //    }
        //}


        private async Task OnCancelAsync()
        {
            
            if (AnyChanges())
            {
               
                bool? confirm = await DialogService.ShowMessageBox(
                    "Confirm Cancel",
                    "You have unsaved changes. Do you wish to close this page? All unsaved changes will be lost.",
                    yesText: "Yes, Close",
                    cancelText: "No, Keep Editing");

               
                if (confirm != true) return;
            }

            NavigationManager.NavigateTo("/receiving/outstanding");
        }


        private string GetHelperText(OrderDetailView item)
        {
            return $"Previously received: {item.ReceivedToDate}";
        }


        private string? ValidateReceived(OrderDetailView item, int? v)
        {
            if (!v.HasValue) return "Received qty required."; 
            if (v.Value < 0) return "Received cannot be negative.";
            if (v.Value > item.OutstandingBase)
                return $"Received cannot exceed Outstanding ({item.OutstandingBase}).";
            return null;
        }

        private async Task SaveChanges()
        {
           
            var confirmSave = await DialogService.ShowMessageBox(
                "Confirm Save",
                "Are you sure you want to save the changes?",
                yesText: "Yes, Save",
                cancelText: "No, Cancel",
                options: new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true }
            );

            if (confirmSave == true)
            {
              
                try
                {
                    await ReceivingService.SaveReceiveChangesAsync(orderDetails, unorderedItems, UserId);
                    Feedback = "Changes have been saved successfully.";
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Error while saving: {ex.Message}";
                }
                _showSaveCancelButtons = false;
                Feedback = "Changes have been processed.";
                StateHasChanged();
            }
            else
            {
                
                Feedback = "Save operation was canceled.";
                StateHasChanged();
            }
        }

        private async Task CancelChanges()
        {
           
            var confirmCancel = await DialogService.ShowMessageBox(
                "Confirm Cancel",
                "Are you sure you want to cancel? All unsaved changes will be lost.",
                yesText: "Yes, Cancel",
                cancelText: "No, Keep Editing",
                options: new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true }
            );

            if (confirmCancel == true)
            {
               
                Feedback = "Changes have been canceled.";
                _showSaveCancelButtons = false; 
                StateHasChanged();
            }
            else
            {
               
                Feedback = "Cancel operation was canceled.";
                StateHasChanged();
            }
        }



    }
}
