using ExampleMudSystem.BLL;
using ExampleMudSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMudSystem
{
    public static class ExampleMudExtension
    {
        public static void AddBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            
            services.AddDbContext<OLTPDMIT2018Context>(options);

            
            services.AddTransient<WorkingVersionsService>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<OLTPDMIT2018Context>();

                return new WorkingVersionsService(context);
            });



            services.AddTransient<CustomerService>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<OLTPDMIT2018Context>();

                return new CustomerService(context);
            });
            
            services.AddTransient<CategoryLookupService>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<OLTPDMIT2018Context>();

                return new CategoryLookupService(context);
            });
            
            services.AddTransient<InvoiceService>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<OLTPDMIT2018Context>();

                return new InvoiceService(context);
            });
            
            services.AddTransient<PartService>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<OLTPDMIT2018Context>();

                return new PartService(context);
            });
        }
    }
}
