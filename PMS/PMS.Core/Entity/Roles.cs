using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Entity
{
    public class Roles : BaseEntity
    {
        public int RoleId { get; set; }
        public String RoleName { get; set; }
        
    }
}

