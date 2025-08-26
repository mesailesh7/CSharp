using ExampleMudSystem.DAL;
using ExampleMudSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BYSResults;

namespace ExampleMudSystem.BLL
{
    public class CustomerService
    {
        private readonly OLTPDMIT2018Context _hogWildContext;


        internal CustomerService(OLTPDMIT2018Context hogWildContext)
        {
            _hogWildContext = hogWildContext;
        }

        public Result<List<CustomerSearchView>>
                                GetCustomers(string lastName, string phone)
        {
            var result = new Result<List<CustomerSearchView>>();

            #region Data Validation and BusinessRules - This time combined

            // Rule: lastName and phone may not both be empty or white space
            if (string.IsNullOrWhiteSpace(lastName) &&
                                    string.IsNullOrWhiteSpace(phone))
            {
                result.AddError(new Error("Missing Information!",
                            "Must provide either last name or phone number!"));

                // Only one check needed, so if this condition occurs, return
                //		immediately.  No point in carrying on.
                return result;
            }

            #endregion

            // In this case, we wish to retrieve all customers where at
            //		there is a partial match to the lastName or phone
            //		provided.  RemoveFromViewFlag must be false.
            var customers = _hogWildContext.Customers
                            .Where(c => (string.IsNullOrWhiteSpace(lastName)
                                            || c.LastName.ToLower()
                                                .Contains(lastName.ToLower()))
                                     && (string.IsNullOrWhiteSpace(phone)
                                             || c.Phone.Contains(phone))
                                     && !c.RemoveFromViewFlag)
                            .Select(c => new CustomerSearchView
                            {
                                CustomerID = c.CustomerID,
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                City = c.City,
                                Phone = c.Phone,
                                Email = c.Email,
                                StatusID = c.StatusID,
                                TotalSales = c.Invoices.Sum(i =>
                                        ((decimal?)(i.SubTotal + i.Tax) ?? 0))
                            })
                            .OrderBy(anon => anon.LastName)
                            .ToList();

            // If no customers were found, return an error message
            if (customers == null || customers.Count == 0)
            {
                result.AddError(new BYSResults.Error("No Customers!",
                        "No customers were found matching the provided search values!"));

                // No other errors possible at this point, so return immediately.
                return result;
            }

            // If we make it to here, we have customer information to return, so
            //		send back the List<CustomerSearchView>.
            return result.WithValue(customers);
        }


        public Result<CustomerEditView> GetCustomer(int customerID)
        {
            var result = new Result<CustomerEditView>();

            #region Data Validation and BusinessRules - This time combined

            // Rule: Provided customer ID must be valid.  Greater then zero.
            if (customerID <= 0)
            {
                result.AddError(new BYSResults.Error("Missing Information!",
                            "Customer ID must be greater than zero!"));

                // Only one check needed, so if this condition occurs, return
                //		immediately.  No point in carrying on.

                return result;
            }

            #endregion

            // In this case, we wish to retrieve all pieces of information
            //		for the customer matching the provided customer ID.
            var customer = _hogWildContext.Customers
                           .Where(c => c.CustomerID == customerID
                                       && !c.RemoveFromViewFlag)
                           .Select(c => new CustomerEditView
                           {
                               CustomerID = c.CustomerID,
                               FirstName = c.FirstName,
                               LastName = c.LastName,
                               Address1 = c.Address1,
                               Address2 = c.Address2,
                               City = c.City,
                               ProvStateID = c.ProvStateID,
                               CountryID = c.CountryID,
                               PostalCode = c.PostalCode,
                               Phone = c.Phone,
                               Email = c.Email,
                               StatusID = c.StatusID,
                               RemoveFromViewFlag = c.RemoveFromViewFlag
                           })
                           .FirstOrDefault();

            // If no matching customer is found, return an error message
            if (customer == null)
            {
                result.AddError(new BYSResults.Error("No Customer!",
                            "There is no customer with the provided customer ID!"));

                // No other errors possible at this point, so return immediately.
                return result;
            }

            // If we make it to here, we have customer information to return, so
            //		send back the populated CustomerEditView.
            return result.WithValue(customer);
        }

    }
}
