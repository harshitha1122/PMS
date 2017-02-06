using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{
    
    public class MedicineManager 
    {
        public MedicineService medicineService = null;

        public MedicineManager()
        {
            medicineService = new MedicineService();
        }

        public void Add(Medicine medicine)
        {
            medicineService.Add(medicine);
        }

        public Boolean Delete(int medicineId)
        {
            return medicineService.Delete(medicineId);
        }

        public List<Medicine> GetAll()
        {
            return medicineService.GetAll();
        }

        public void Update(Medicine medicine)
        {
            medicineService.Update(medicine);
        }

        public Medicine GetById(Int32 medicineId)
        {
            return medicineService.GetById(medicineId);
        }


        public Boolean IsMedicineNameExists(string medicineName)
        {
            return medicineService.IsMedicineNameExists(medicineName);
        }
    }
}
