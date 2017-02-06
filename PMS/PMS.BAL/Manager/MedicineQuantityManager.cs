using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{

    public class MedicineQuantityManager
    {
        public MedicineQuantityService medicineQuantityService = null;

        public MedicineQuantityManager()
        {
            medicineQuantityService = new MedicineQuantityService();
        }

        public void Add(MedicineQuantity medicineQuantity)
        {
            medicineQuantityService.Add(medicineQuantity);
        }

        public Boolean Delete(int medicineQuantityId)
        {
            return medicineQuantityService.Delete(medicineQuantityId);
        }

        public List<MedicineQuantity> GetAll()
        {
            return medicineQuantityService.GetAll();
        }

        public void Update(MedicineQuantity medicineQuantity)
        {
            medicineQuantityService.Update(medicineQuantity);
        }

        public MedicineQuantity GetById(Int32 medicineQuantityId)
        {
            return medicineQuantityService.GetById(medicineQuantityId);
        }
    }
}
