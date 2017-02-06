using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Entity
{
    public class Page : BaseEntity
    {
        public int PageId { get; set; }
        public String PageName { get; set; }
        public String PageDescription{ get; set; }
        
    }
}
