using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Entity
{
    public class Company : BaseEntity
    {
        public int CompanyId { get; set; }
        public String CompanyName { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String Website { get; set; }
        public String CompanyReg { get; set; }
    }
}
