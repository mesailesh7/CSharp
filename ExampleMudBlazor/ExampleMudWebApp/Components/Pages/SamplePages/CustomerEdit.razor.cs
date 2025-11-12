using ExampleMudSystem.BLL;
using ExampleMudSystem.ViewModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ExampleMudWebApp.Components.Pages.SamplePages
{
    public partial class CustomerEdit
    {
        #region Feedback & Error messages
        
        private string feedbackMessage = string.Empty;
        private string? errorMessage;
        private bool hasFeedback => !string.IsNullOrWhiteSpace(feedbackMessage);
        private bool hasError => !string.IsNullOrWhiteSpace(errorMessage);
        private List<string> errorDetails = new();
        private bool disableViewButton = false;
        
        
        #endregion

        #region Fields

        private CustomerEditView customer = new CustomerEditView();
        private MudForm customerForm = new();
        
        private List<LookupView> provinces = new();
        private List<LookupView> countries = new();
        private List<LookupView> statusLookup = new();
        private List<InvoiceView> invoices = new();
        
        #endregion

        #region  Validation

        private bool isFormValid;
        private bool hasDataChanged = false;
        private string closeButtonText => hasDataChanged ? "Cancel" : "Close";
        #endregion
        
        #region Properties

        [Inject] protected CustomerService CustomerService { get; set; } = default!;
        
        [Inject] protected CategoryLookupService CategoryLookupService { get; set; } = default!;
        
        [Inject] 
        protected NavigationManager NavigationManager { get; set; } = default!;
        [Parameter] public int CustomerID { get; set; } = 0;
        [Inject]
        protected IDialogService DialogService { get; set; } = default!;
        [Inject]
        protected InvoiceService InvoiceService { get; set; }
        
        #endregion

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            try
            {
                errorDetails.Clear();
                errorMessage = string.Empty;
                feedbackMessage = string.Empty;

                if (CustomerID > 0)
                {
                    var result = CustomerService.GetCustomer(CustomerID);
                    
                    if (result.IsSuccess)
                    {   
                        customer = result.Value;
                        var invoiceResults = InvoiceService.GetCustomerInvoices(CustomerID);

                        if (invoiceResults.IsSuccess)
                        {
                            invoices = invoiceResults.Value;
                        }
                        else
                        {
                            errorDetails = HelperMethods.GetErrorMessages(result.Errors.ToList());
                        }
                    }
                    else
                    {
                        errorMessage = "Please solve the below issues first";
                        errorDetails = HelperMethods.GetErrorMessages(result.Errors.ToList());
                    }
                }
                else
                {
                    customer = new();
                }
                
                //lookups
                provinces = CategoryLookupService.GetLookups("province");
                countries = CategoryLookupService.GetLookups("Country");
                statusLookup = CategoryLookupService.GetLookups("Customer Status");

                StateHasChanged();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            #endregion
        }

        private void Save()
        {
            errorDetails.Clear();
            errorMessage = string.Empty;
            feedbackMessage = string.Empty;

            try
            {
                var result = CustomerService.AddEditCustomer(customer);

                if (result.IsSuccess)
                {
                    customer = result.Value;
                    feedbackMessage = "Customer Saved";

                    hasDataChanged = false;
                    isFormValid = false;
                        customerForm.ResetTouched();
                }
                else
                {
                    errorDetails = HelperMethods.GetErrorMessages(result.Errors.ToList());
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }

        private async Task Cancel()
        {
            if (hasDataChanged)
            {
                bool? results = await DialogService.ShowMessageBox("Confirm Cancel", $"Do you  want to cancel the changes?", "Yes", "No");

                if (results == null)
                {
                    return;
                }
            }
            NavigationManager.NavigateTo("/SamplePages/CustomerList");
        }


        private void NewInvoice()
        {
            NavigationManager.NavigateTo($"/SamplePages/InvoiceEdit/0/${CustomerID}/1");
        }

        private void EditInvoice(int invoiceID)
        {
            NavigationManager.NavigateTo($"/SamplePages/InvoiceEdit/{invoiceID}/{CustomerID}/1");
        }
    
}
}