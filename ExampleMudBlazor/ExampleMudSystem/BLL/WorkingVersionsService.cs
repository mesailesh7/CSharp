using ExampleMudSystem.DAL;
using ExampleMudSystem.Entities;
using ExampleMudSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMudSystem.BLL
{
    public class WorkingVersionsService
    {
        private readonly OLTPDMIT2018Context _hogWildContext;

        internal WorkingVersionsService(OLTPDMIT2018Context hogWildContext)
        {
            _hogWildContext = hogWildContext;
        }

        public WorkingVersionView GetWorkingVersion()
        {
            return _hogWildContext.WorkingVersions
                .Select(x => new WorkingVersionView
                {
                    VersionId = x.VersionId,
                    Major = x.Major,
                    Minor = x.Minor,
                    Build = x.Build,
                    AsOfDate = x.AsOfDate,
                    Comments = x.Comments,
                    Revision = x.Revision

                }
                ).FirstOrDefault();
        }
    }
}
