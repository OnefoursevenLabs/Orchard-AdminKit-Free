using OrchardCore.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;
//using OrchardCore.Navigation;

namespace Onefourseven.AdminKit.Free {
    public class Startup : StartupBase {
        public override void ConfigureServices(IServiceCollection services) {
            //services.AddNavigation();

            services.Configure<MvcOptions>((options) => {
                //options.Filters.Add(typeof(Panelv1Filter));
            });

            services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();
        }
    }
}