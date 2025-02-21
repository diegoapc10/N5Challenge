using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Commands
{
    public interface IRequestPermissionCommand
    {
        public Task<PermissionDto> Execute(PermissionDto permission);
    }
}
