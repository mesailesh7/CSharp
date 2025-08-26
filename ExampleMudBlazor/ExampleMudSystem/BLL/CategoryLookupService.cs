using ExampleMudSystem.DAL;
using ExampleMudSystem.Entities;
using ExampleMudSystem.ViewModels;

namespace ExampleMudSystem.BLL;

public class CategoryLookupService
{
    #region Fields

    private readonly OLTPDMIT2018Context _hogWildContext;

    internal CategoryLookupService(OLTPDMIT2018Context hogWildContext)
    {
        _hogWildContext = hogWildContext;
    }
    #endregion
    
    #region Methods
    //Get the lookups
    public List<LookupView> GetLookups(string categoryName)
    {
        return _hogWildContext.Lookups
            .Where(x => x.Category.CategoryName == categoryName)
            .OrderBy(x => x.Name)
            .Select(x => new LookupView
            {   
                LookupID = x.LookupID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                RemoveFromViewFlag = x.RemoveFromViewFlag
            }).ToList();
    }
    #endregion
}