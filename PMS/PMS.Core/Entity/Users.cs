using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Entity
{
    public class Users : BaseEntity
    {
        public int UserId { get; set; }
        public String UserName { get; set; }
        public String RoleName { get; set; }
        public String Password { get; set; }
        public Boolean IsActive { get; set; }
        public int RoleId { get; set; }
    }
}
