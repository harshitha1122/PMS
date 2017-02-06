using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Entity
{
    public class LkpMedicineType : BaseEntity
    {
        public int Id { get; set; }
        public String MedicineType { get; set; }
        public String MedicineTypeDesc { get; set; }
       
    }
}
