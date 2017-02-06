using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{

    public class LkpMedicineTypeManager
    {
        public LkpMedicineTypeService lkpMedicineTypeService = null;

        public LkpMedicineTypeManager()
        {
            lkpMedicineTypeService = new LkpMedicineTypeService();
        }

        public void Add(LkpMedicineType lkpMedicineType)
        {
            lkpMedicineTypeService.Add(lkpMedicineType);
        }

        public Boolean Delete(int medicineTypeId)
        {
            return lkpMedicineTypeService.Delete(medicineTypeId);
        }

        public List<LkpMedicineType> GetAll()
        {
            return lkpMedicineTypeService.GetAll();
        }

        public void Update(LkpMedicineType lkpMedicineType)
        {
            lkpMedicineTypeService.Update(lkpMedicineType);
        }

        public LkpMedicineType GetById(Int32 lkpMedicineTypeId)
        {
            return lkpMedicineTypeService.GetById(lkpMedicineTypeId);
        }
    }
}
