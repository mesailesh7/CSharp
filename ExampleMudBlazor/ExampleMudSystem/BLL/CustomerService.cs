using ExampleMudSystem.DAL;
using ExampleMudSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BYSResults;
using ExampleMudSystem.Entities;
using ExampleMudWebApp;

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

        public Result<CustomerEditView> AddEditCustomer(CustomerEditView editCustomer)
        {
            var result = new Result<CustomerEditView>();

            #region Data Validation

            if (editCustomer == null)
            {
                result.AddError(new BYSResults.Error("Missing Customer", "No customer object was supplied"));

                return result;
            }
             if (string.IsNullOrWhiteSpace(editCustomer.FirstName))
            {
                result.AddError(new BYSResults.Error("Missing information",
                                                "First name required!"));
            }

            if (string.IsNullOrWhiteSpace(editCustomer.LastName))
            {
                result.AddError(new BYSResults.Error("Missing information",
                                                "Last name required!"));
            }

            if (string.IsNullOrWhiteSpace(editCustomer.Address1))
            {
                result.AddError(new BYSResults.Error("Missing information",
                                                "Address Line 1 required!"));
            }

            if (string.IsNullOrWhiteSpace(editCustomer.City))
            {
                result.AddError(new BYSResults.Error("Missing information",
                                                "City required!"));
            }

            if (editCustomer.ProvStateID <= 0)
            {
                result.AddError(new BYSResults.Error("Missing Information!",
                            "Province/State ID must be greater than zero!"));
            }

            if (editCustomer.CountryID <= 0)
            {
                result.AddError(new BYSResults.Error("Missing Information!",
                            "Country ID must be greater than zero!"));
            }

            if (string.IsNullOrWhiteSpace(editCustomer.PostalCode))
            {
                result.AddError(new BYSResults.Error("Missing information",
                                                "Postal code required!"));
            }

            if (string.IsNullOrWhiteSpace(editCustomer.Phone))
            {
                result.AddError(new BYSResults.Error("Missing information",
                                                "Phone number required!"));
            }

            if (string.IsNullOrWhiteSpace(editCustomer.Email))
            {
                result.AddError(new BYSResults.Error("Missing information",
                                                "Email is required!"));
            }

            if (editCustomer.StatusID <= 0)
            {
                result.AddError(new BYSResults.Error("Missing Information!",
                            "Status ID must be greater than zero!"));
            }

            if (result.Errors.Count > 0)
            {
                return result;
            }
        
            #endregion

            #region Business Rules

            if (editCustomer.CustomerID <= 0)
            {
                bool customerExist = _hogWildContext.Customers
                    .Any(customer =>
                        customer.FirstName.ToLower() == editCustomer.FirstName.ToLower()
                        && customer.LastName.ToLower() == editCustomer.LastName.ToLower()
                        && customer.Phone.ToLower() == editCustomer.Phone.ToLower()
                    );

                if (customerExist)
                {
                    result.AddError(new BYSResults.Error("Existing Customer Data",
                        "A customer with the same first name , last name" +
                        " and phone number already exists in the database"));
                }
            }

            if (result.IsFailure)
            {
                return result;
            }
            
            #endregion

            Customer customer = _hogWildContext.Customers
                .Where(x => x.CustomerID == editCustomer.CustomerID)
                .FirstOrDefault();
            if (customer == null)
            {
                customer = new Customer();
            }
            
            customer.FirstName = editCustomer.FirstName;
            customer.LastName = editCustomer.LastName;
            customer.Address1 = editCustomer.Address1;
            customer.Address2 = editCustomer.Address2;
            customer.City = editCustomer.City;
            customer.ProvStateID = editCustomer.ProvStateID;
            customer.CountryID = editCustomer.CountryID;
            customer.PostalCode = editCustomer.PostalCode;
            customer.Email = editCustomer.Email;
            customer.Phone = editCustomer.Phone;
            customer.StatusID = editCustomer.StatusID;
            customer.RemoveFromViewFlag = editCustomer.RemoveFromViewFlag;

            if (customer.CustomerID <= 0)
            {
                _hogWildContext.Customers.Add(customer);
            }
            else
            {
                _hogWildContext.Customers.Update(customer);
            }

            try
            {
                _hogWildContext.SaveChanges();
            }
            catch (Exception e)
            {
            _hogWildContext.ChangeTracker.Clear();

            result.AddError(
                new BYSResults.Error("Error Saving changes", HelperMethods.GetInnerMostException(e).Message));

            return result;
            }

            return GetCustomer(customer.CustomerID);
        }

    }
}
