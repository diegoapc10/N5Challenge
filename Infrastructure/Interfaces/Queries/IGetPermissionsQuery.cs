using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Queries
{
    public interface IGetPermissionsQuery
    {
        Task<IEnumerable<PermissionDto>> Execute();
    }
}
