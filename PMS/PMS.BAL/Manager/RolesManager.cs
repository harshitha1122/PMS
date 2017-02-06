using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{

    public class RolesManager
    {
        public RolesService rolesService = null;

        public RolesManager()
        {
            rolesService = new RolesService();
        }

        public void Add(Roles role)
        {
            rolesService.Add(role);
        }

        public Boolean Delete(int roleID)
        {
            return rolesService.Delete(roleID);
        }

        public List<Roles> GetAll()
        {
            return rolesService.GetAll();
        }

        public void Update(Roles roles)
        {
            rolesService.Update(roles);
        }

        public Roles GetById(Int32 rolesId)
        {
            return rolesService.GetById(rolesId);
        }
    }
}
