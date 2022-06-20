using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace Onefourseven.AdminKit.Free {
    public class Permissions : IPermissionProvider {
        public static readonly Permission AccessDashboard = new Permission("AccessDashboard", "Access dashboard");

        public IEnumerable<Permission> GetPermissions() {
            return new[]
            {
                AccessDashboard
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = GetPermissions()
                },
                new PermissionStereotype {
                    Name = "Editor",
                    Permissions = GetPermissions()
                },
                new PermissionStereotype {
                    Name = "Moderator",
                    Permissions = GetPermissions()
                },
                new PermissionStereotype {
                    Name = "Author",
                    Permissions = GetPermissions()
                },
                new PermissionStereotype {
                    Name = "Contributor",
                    Permissions = GetPermissions()
                }
            };
        }

        public Task<IEnumerable<Permission>> GetPermissionsAsync() {
            return Task.FromResult(new[]
            {
                AccessDashboard
            }
            .AsEnumerable());
        }
    }
}