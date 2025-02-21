using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IPermissionRepository
    {
        Task<PermissionDto> RequestPermission(PermissionDto permission);
        Task<PermissionDto> ModifyPermission(int id, PermissionDto permission);
        Task<IEnumerable<PermissionDto>> GetPermissions();
    }
}
