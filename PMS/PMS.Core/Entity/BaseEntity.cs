using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Entity
{
    public class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }

        public Int32? CreatedUserId { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public Int32? LastModifiedUserId { get; set; }
    }
}
