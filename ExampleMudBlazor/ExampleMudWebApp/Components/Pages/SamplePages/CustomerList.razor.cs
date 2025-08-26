using ExampleMudSystem.BLL;
using ExampleMudSystem.ViewModels;
using Microsoft.AspNetCore.Components;
using System.IO.Compression;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExampleMudWebApp.Components.Pages.SamplePages
{
    public partial class CustomerList
    {
        #region Fields
        private string lastName = string.Empty;
        private string phoneNumber = string.Empty;
        private bool noRecords;
        private string feedbackMessage = string.Empty;
        private string errorMessage = string.Empty;

        private bool hasFeedback => !string.IsNullOrWhiteSpace(feedbackMessage);

        private bool hasErrors => !string.IsNullOrWhiteSpace(errorMessage);

        private List<string> errorDetails = new();

        #endregion


        [Inject]
        protected CustomerService CustomerService { get; set; } = default!;

        [Inject]
        protected NavigationManager NavigationManager { get; set; } = default!;

        protected List<CustomerSearchView> Customers { get; set; } = new();


        #region Methods
        private void Search()
        {
            noRecords = false;
            errorDetails.Clear();
            errorMessage = string.Empty;
            feedbackMessage = string.Empty;

            try
            {
                var result = CustomerService.GetCustomers(lastName, phoneNumber);

                    if (result.IsSuccess)
                {
                    Customers = result.Value;
                }
                else
                {
                    //if (result.Errors.Any(e => e.Code == "No Customers"))
                    //{
                    //    noRecords = true;
                    //}
                    errorMessage = "Please address the following errors:";
                    noRecords = true;
                    errorDetails = HelperMethods.GetErrorMessages(result.Errors.ToList());
                }
            }
            catch (Exception ex)
            {
                errorMessage = HelperMethods.GetInnerMostException(ex).Message;
            }
        }

        private void New()
        {
            NavigationManager.NavigateTo("/SamplePagges/CustomerEdit/0");
        }

        private void EditCustomer(int customerID)
        {
            NavigationManager.NavigateTo($"/SamplePages/CustomerEdit/{customerID}");
        }

        private void NewInvoice(int customerID) { }
        #endregion

    }
}