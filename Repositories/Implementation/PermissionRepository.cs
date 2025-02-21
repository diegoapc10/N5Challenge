using AutoMapper;
using Domain.Dtos;
using Domain.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IRepository<Permission> _permissionsRepository;
        private readonly IMapper _mapper;

        public PermissionRepository(IRepository<Permission> permissionsRepository, IMapper mapper)
        {
            _permissionsRepository = permissionsRepository;
            _mapper = mapper;
        }

        public async Task<PermissionDto> RequestPermission(PermissionDto permission)
        {
            var permissionRequest = new Permission()
            {
                EmployeeForname = permission.EmployeeForname,
                EmployeeSurname = permission.EmployeeSurname,
                PermissionType = permission.PermissionType,
                PermissionDate = DateOnly.Parse(permission.PermissionDate)
            };

            var newPermissionRequest = await _permissionsRepository.Insert(permissionRequest);
            return _mapper.Map<PermissionDto>(newPermissionRequest);
        }

        public async Task<PermissionDto> ModifyPermission(int id, PermissionDto permission)
        {
            var permissionRequest = new Permission()
            {
                EmployeeForname = permission.EmployeeForname,
                EmployeeSurname = permission.EmployeeSurname,
                PermissionType = permission.PermissionType,
                PermissionDate = DateOnly.Parse(permission.PermissionDate)
            };

            var newPermissionRequest = await _permissionsRepository.Update(id, permissionRequest);
            return _mapper.Map<PermissionDto>(newPermissionRequest);
        }

        public async Task<IEnumerable<PermissionDto>> GetPermissions()
        {
            var list = await _permissionsRepository.Get();
            return list.Select(x => _mapper.Map<PermissionDto>(x));
        }
    }
}
