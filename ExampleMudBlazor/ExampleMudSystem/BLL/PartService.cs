﻿using BYSResults;
using ExampleMudSystem.DAL;
using ExampleMudSystem.ViewModels;

namespace ExampleMudSystem.BLL;

public class PartService
{
    private readonly OLTPDMIT2018Context _hogWildContext;

    internal PartService(OLTPDMIT2018Context hogWildContext)
    {
        _hogWildContext = hogWildContext;
    }
    
    // This system method will retrieve a list of parts that
		//		are either in the provided category, partially match the provided description,
		//		or both, all while not being included in the list of provided existing part IDs.
		public Result<List<PartView>> GetParts(int partCategoryID, string description,
													List<int> existingPartIDs)
		{
			// Set up the object used for returning data to the calling scope.
			var result = new Result<List<PartView>>();

			// In this case only a single test is required for the incoming data, so the 
			//		data validation and business rules may be combined.
			#region Data Validation and Business Rules

			// If both the provided part category ID and the provided description are invalid,
			//		immediately return with the following error message for the user.
			if (partCategoryID <= 0 && string.IsNullOrWhiteSpace(description))
			{
				result.AddError(new Error("Missing Information!",
							"Please provide either a category ID and/or description!"));

				return result;
			}

			#endregion

			// Making it to this point means we have a valid piece of information to use 
			//		as a filter for the part list.
			// If the description passed in is not useable information, replace it with
			//		a piece of information guaranteed not to have a match in the database.
			Guid tempGuid = new Guid();
			if (string.IsNullOrWhiteSpace(description))
			{
				description = tempGuid.ToString();
			}

			// Retrieve the parts matching the provided information
			var parts = _hogWildContext.Parts
						// First make sure the part is not in the exclusion list
						.Where(p => !existingPartIDs.Contains(p.PartID)
										// If we have a proper partial description
										&& (description.Length > 0
										// That is not equal to the guaranteed "no match" from above
										&& description != tempGuid.ToString()
										// If the part category is valid
										&& partCategoryID > 0
											// Include all parts matching the provided information
											? (p.Description.ToUpper().Contains(description.ToUpper())
												&& p.PartCategoryID == partCategoryID)
											: (p.Description.ToUpper().Contains(description.ToUpper())
												|| p.PartCategoryID == partCategoryID)
										// Don't forget to exclude those parts that have been discontinued
										&& !p.RemoveFromViewFlag))
						// Polulate the View Model instances for information transport
						.Select(p => new PartView
						{
							PartID = p.PartID,
							PartCategoryID = p.PartCategoryID,
							// You may need to use the navigation properties to get some information
							CategoryName = p.PartCategory.Name,
							Description = p.Description,
							Cost = p.Cost,
							Price = p.Price,
							ROL = p.ROL,
							QOH = p.QOH,
							Taxable = (bool)p.Taxable,
							RemoveFromViewFlag = p.RemoveFromViewFlag
						})
							.OrderBy(p => p.Description)
							.ToList();

			// If no parts are found for the search criteria, send an error message back to the
			//		calling scope.
			if (parts == null || parts.Count == 0)
			{
				result.AddError(new Error("No Parts Found!",
						"No parts were found that match the provided criteria"));

				return result;
			}

			// return the results retrieved to the calling scope if no errors encountered
			return result.WithValue(parts);
		}

		// This system method intended to retrieve a part that matches the 
		//		provided part ID.
		public Result<PartView> GetPart(int partID)
		{
			// Set up the object used for returning data to the calling scope.
			var result = new Result<PartView>();

			// In this case only a single test is required for the incoming data, so the 
			//		data validation and business rules may be combined.
			#region Business Rules

			// If the provided part ID is invalid
			//		immediately return with the following error message for the user.
			if (partID <= 0)
			{
				result.AddError(new Error("Missing Information!",
										"Part ID must be greater than zero!"));

				return result;
			}

			#endregion

			// Retrieve the information requested for the provided part ID
			var part = _hogWildContext.Parts
						.Where(p => p.PartID == partID && !p.RemoveFromViewFlag)
						.Select(p => new PartView
						{
							PartID = p.PartID,
							PartCategoryID = p.PartCategoryID,
							CategoryName = p.PartCategory.Name,
							Description = p.Description,
							Cost = p.Cost,
							Price = p.Price,
							ROL = p.ROL,
							QOH = p.QOH,
							Taxable = (bool)p.Taxable,
							RemoveFromViewFlag = p.RemoveFromViewFlag
						})
						.FirstOrDefault();  // Use FirstOrDefault() instead of ToList() when
											//		retrieve a single item.

			// If no part found, populate and return an appropriate error message to the
			//		calling scope.
			if (part == null)
			{
				result.AddError(new Error("No Part Found!",
							"No part was found for the provided part ID"));

				return result;
			}

			// return the results retrieved to the calling scope if no errors encountered
			return result.WithValue(part);
		}

		public Result<List<PartView>> GetPartsForPartIDs(List<int> partIDs)
		{
			// Set up the object used for returning data to the calling scope.
			var result = new Result<List<PartView>>();

			// In this case only a single test is required for the incoming data, so the 
			//		data validation and business rules may be combined.
			#region Business Rules

			// If the provided part ID is invalid
			//		immediately return with the following error message for the user.
			if (partIDs == null || partIDs.Count == 0)
			{
				result.AddError(new Error("Missing Information!",
										"One or more part IDs must be supplied!"));

				return result;
			}

			#endregion

			// Retrieve the information requested for the provided part ID
			var parts = _hogWildContext.Parts
						.Where(p => partIDs.Contains(p.PartID) && !p.RemoveFromViewFlag)
						.Select(p => new PartView
						{
							PartID = p.PartID,
							PartCategoryID = p.PartCategoryID,
							CategoryName = p.PartCategory.Name,
							Description = p.Description,
							Cost = p.Cost,
							Price = p.Price,
							ROL = p.ROL,
							QOH = p.QOH,
							Taxable = (bool)p.Taxable,
							RemoveFromViewFlag = p.RemoveFromViewFlag
						})
						.ToList();  // Use FirstOrDefault() instead of ToList() when
											//		retrieve a single item.

			// If no part found, populate and return an appropriate error message to the
			//		calling scope.
			if (parts == null || parts.Count == 0)
			{
				result.AddError(new Error("No Parts Found!",
							"No parts were found for the provided partID(s)"));

				return result;
			}

			// return the results retrieved to the calling scope if no errors encountered
			return result.WithValue(parts);
		}
}