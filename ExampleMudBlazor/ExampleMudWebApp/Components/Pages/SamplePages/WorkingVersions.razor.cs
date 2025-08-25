using ExampleMudSystem.BLL;
using ExampleMudSystem.ViewModels;
using Microsoft.AspNetCore.Components;

namespace ExampleMudWebApp.Components.Pages.SamplePages
{
    public partial class WorkingVersions
    {

        #region Fields
        private WorkingVersionView workingVersionsView = new WorkingVersionView();

        private string feedback = string.Empty;

        #endregion


        #region Properties
        [Inject]
        protected WorkingVersionsService WorkingVersionsService { get; set; }
        #endregion


        #region Methods
        private void GetWorkingVersion()
        {
            try
            {
                workingVersionsView = WorkingVersionsService.GetWorkingVersion();
            }
            catch (Exception ex)
            {
                feedback = ex.Message;
            }
        }
        #endregion

    }
}