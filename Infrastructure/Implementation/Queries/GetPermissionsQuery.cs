using Domain.Dtos;
using Infrastructure.Interfaces.Queries;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace Infrastructure.Implementation.Queries
{
    public class GetPermissionsQuery : IGetPermissionsQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionsQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PermissionDto>> Execute()
        {
            return await _unitOfWork.permissionRepository.GetPermissions();
        }
    }
}
