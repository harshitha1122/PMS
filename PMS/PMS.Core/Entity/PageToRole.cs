using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Entity
{
    public class PageToRole : BaseEntity
    {
        public int PageToRoleId { get; set; }
        public int PageId { get; set; }
        public int RoleId { get; set; }

        public string PageName { get; set; }
        public string RoleName { get; set; }
        
    }
}

