using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPermissionRepository permissionRepository {  get; }

        public UnitOfWork(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }
    }
}
