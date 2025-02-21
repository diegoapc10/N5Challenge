using AutoMapper;
using Domain.Dtos;
using Domain.Models;
using Infrastructure.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace Infrastructure.Implementation.Commands
{
    public class RequestPermissionCommand : IRequestPermissionCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestPermissionCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PermissionDto> Execute(PermissionDto permission)
        {
            return await _unitOfWork.permissionRepository.RequestPermission(permission);
        }
    }
}
