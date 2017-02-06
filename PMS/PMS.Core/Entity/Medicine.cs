using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Entity
{
    public class Medicine : BaseEntity
    {
        public int MedicineId { get; set; }
        public String MedicineName { get; set; }
        public int MedicineTypeId { get; set; }
        public int CompanyId { get; set; }
        public int Weight { get; set; }
        public int UnitTypeId { get; set; }
        public string UnitType { get; set; }
        public string MedicineType { get; set; }
        public string CompanyName { get; set; }
    }
}
