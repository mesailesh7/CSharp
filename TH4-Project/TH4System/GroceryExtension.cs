using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TH4System.BLL;
using TH4System.DAL;

namespace TH4System
{
    public static class GroceryExtension
    {
        public static void AddBackendDependencies(this IServiceCollection services,
                                                        Action<DbContextOptionsBuilder> options)
        {
            // Register the HogWildContext class, which is the DbContext for your application,
            // with the service collection. This allows the DbContext to be injected into other
            // parts of your application as a dependency.

            // The 'options' parameter is an Action<DbContextOptionsBuilder> that typically
            // configures the options for the DbContext, including specifying the database
            // connection string.

            services.AddDbContext<GroceryListContext>(options);

            //  adding any services that you create in the class library (BLL)
            //  using .AddTransient<t>(...)
            //  Grocery List

            services.AddTransient<OrderService>
                  ((ServiceProvider) =>
                  {
                      var context = ServiceProvider.GetService<GroceryListContext>();

                      return new OrderService(context);
                  }
                );


            services.AddTransient<OrderPickService>
                ((ServiceProvider) =>
                {
                    var context = ServiceProvider.GetService<GroceryListContext>();

                    return new OrderPickService(context);
                });

        }
    }
}
