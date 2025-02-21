using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Permission
    {
        public int Id { get; set; }

        public string EmployeeForname { get; set; } = null!;

        public string? EmployeeSurname { get; set; }

        public int? PermissionType { get; set; }

        public DateOnly? PermissionDate { get; set; }

        public virtual PermissionType? PermissionTypeNavigation { get; set; }
    }
}
