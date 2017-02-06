using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Entity
{
    public class LkpUnitType : BaseEntity
    {
        public int Id { get; set; }
        public String UnitType { get; set; }
        public String UnitTypeDesc { get; set; }

    }
}
