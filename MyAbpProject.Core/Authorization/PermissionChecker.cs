using Abp.Authorization;
using MyAbpProject.Authorization.Roles;
using MyAbpProject.MultiTenancy;
using MyAbpProject.Users;

namespace MyAbpProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
