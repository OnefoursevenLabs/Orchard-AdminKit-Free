using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace Onefourseven.AdminKit.Free {
    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions> {
        private static ResourceManifest _manifest;

        static ResourceManagementOptionsConfiguration() {
            _manifest = new ResourceManifest();

            _manifest
                .DefineStyle("AdminKitTheme-bootstrap-oc")
                .SetUrl("~/Onefourseven.AdminKit.Free/css/bootstrap-oc.min.css", "~/Onefourseven.AdminKit.Free/css/bootstrap-oc.css")
                .SetVersion("1.0.0");

            _manifest
                .DefineScript("AdminKitTheme")
                .SetUrl("~/Onefourseven.AdminKit.Free/js/app.min.js", "~/Onefourseven.AdminKit.Free/js/app.js")
                .SetVersion("6.0.7");

            _manifest
                .DefineStyle("AdminKitTheme")
                .SetUrl("~/Onefourseven.AdminKit.Free/css/app.min.css", "~/Onefourseven.AdminKit.Free/css/app.css")
                .SetVersion("6.0.7");
        }

        public void Configure(ResourceManagementOptions options) {
            options.ResourceManifests.Add(_manifest);
        }
    }
}
