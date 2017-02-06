using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{

    public class LkpUnitTypeManager
    {
        public LkpUnitTypeService lkpUnitTypeService = null;

        public LkpUnitTypeManager()
        {
            lkpUnitTypeService = new LkpUnitTypeService();
        }

        public void Add(LkpUnitType lkpUnitType)
        {
            lkpUnitTypeService.Add(lkpUnitType);
        }

        public Boolean Delete(int lkpUnitTypeId)
        {
            return lkpUnitTypeService.Delete(lkpUnitTypeId);
        }

        public List<LkpUnitType> GetAll()
        {
            return lkpUnitTypeService.GetAll();
        }

        public void Update(LkpUnitType lkpUnitType)
        {
            lkpUnitTypeService.Update(lkpUnitType);
        }

        public LkpUnitType GetById(Int32 lkpUnitTypeId)
        {
            return lkpUnitTypeService.GetById(lkpUnitTypeId);
        }
    }
}
