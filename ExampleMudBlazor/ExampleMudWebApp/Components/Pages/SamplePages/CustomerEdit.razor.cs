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

        #endregion

        #region Fields

        private CustomerEditView customer = new();
        private MudForm customerForm = new();
        
        
        

        #endregion

        #region Properties

        [Inject] protected CustomerService CustomerService { get; set; } = default!;
        
        [Inject] protected CategoryLookupService CategoryLookupService { get; set; } = default!;
        
        [Parameter] public int CustomerID { get; set; } = 0;

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

                StateHasChanged();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            #endregion
        }
    
}
}