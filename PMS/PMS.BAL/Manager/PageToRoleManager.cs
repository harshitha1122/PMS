using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{

    public class PageToRoleManager
    {
        public PageToRoleService pageToRoleService = null;

        public PageToRoleManager()
        {
            pageToRoleService = new PageToRoleService();
        }

        public void Add(PageToRole pageToRole)
        {
            pageToRoleService.Add(pageToRole);
        }

        public Boolean Delete(int pageToRoleId)
        {
            return pageToRoleService.Delete(pageToRoleId);
        }

        public List<PageToRole> GetAll()
        {
            return pageToRoleService.GetAll();
        }

        public void Update(PageToRole pageToRole)
        {
            pageToRoleService.Update(pageToRole);
        }

        public PageToRole GetById(Int32 pageToRoleId)
        {
            return pageToRoleService.GetById(pageToRoleId);
        }
    }
}
