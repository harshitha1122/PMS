using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Entity
{
    public class MedicineQuantity : BaseEntity
    {
        public DateTime DateOfPurchase{ get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ManfactureDate { get; set; }
        public decimal Price { get; set; }
        public int MedQuantity{ get; set; }
        public int MedicineId { get; set; }
        public int QuantityId { get; set; }
        public String MedicineName{ get; set; }

    }
}
