using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PermissionType
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
