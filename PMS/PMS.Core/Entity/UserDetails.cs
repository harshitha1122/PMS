using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Entity
{
    public class UserDetails : BaseEntity
    {
        public int UserDetailId { get; set; }

        public string UserName { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public String MobileNumber { get; set; }
        public String EmailId { get; set; }
        public int UserId { get; set; }
    }
}
