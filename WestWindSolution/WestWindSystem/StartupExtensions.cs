using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WestWindSystem.DAL;
using WestWindSystem.BLL;
#endregion

namespace WestWindSystem
{
    public static class StartupExtensions
    {
        public static void AddBackendDependencies(this IServiceCollection services,
                Action<DbContextOptionsBuilder> options)
        {
            //add the context class of your application library to the service collection
            //pass in the connection string options.
            services.AddDbContext<WestWindContext>(options);  //WestWindContext

            //add any business logic layer class to the service collection so our
            //  web app has access to the methods within the BLL class.
            services.AddTransient<AboutServices>((serviceProvider) =>
            {
                //get the dbcontext class
                var context = serviceProvider.GetRequiredService<WestWindContext>();
                return new AboutServices(context);
            });

            //services.AddTransient<anotherBLLclass>((serviceProvider) =>
            //{
            //    //get the dbcontext class
            //    var context = serviceProvider.GetRequiredService<contextclass>();
            //    return new anotherBllclass(context);
            //});
        }
    }

}

