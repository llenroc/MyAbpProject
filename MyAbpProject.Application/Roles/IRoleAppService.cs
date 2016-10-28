using System.Threading.Tasks;
using Abp.Application.Services;
using MyAbpProject.Roles.Dto;

namespace MyAbpProject.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
