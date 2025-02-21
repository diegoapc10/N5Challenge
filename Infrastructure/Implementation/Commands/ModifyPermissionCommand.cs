using Domain.Dtos;
using Infrastructure.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace Infrastructure.Implementation.Commands
{
    public class ModifyPermissionCommand : IModifyPermissionCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModifyPermissionCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PermissionDto> Execute(int id, PermissionDto permission)
        {
            return await _unitOfWork.permissionRepository.ModifyPermission(id, permission);
        }
    }
}
