using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Commands
{
    public interface IModifyPermissionCommand
    {
        public Task<PermissionDto> Execute(int id, PermissionDto permission);
    }
}
