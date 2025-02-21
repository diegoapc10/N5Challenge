using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PermissionDto
    {
        public int Id { get; set; }

        public string EmployeeForname { get; set; } = null!;

        public string? EmployeeSurname { get; set; }

        public int? PermissionType { get; set; }

        public string PermissionDate { get; set; }
    }
}
