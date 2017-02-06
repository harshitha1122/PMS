using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{
    public class UsersManager
    {
        public UsersService usersService = null;

        public UsersManager()
        {
            usersService = new UsersService();
        }

        public void Add(Users users)
        {
            usersService.Add(users);
        }

        public Boolean Delete(int userId)
        {
            return usersService.Delete(userId);
        }

        public List<Users> GetAll()
        {
            return usersService.GetAll();
        }

        public void Update(Users users)
        {
            usersService.Update(users);
        }

        public Users GetById(Int32 usersId)
        {
            return usersService.GetById(usersId);
        }
    }
}
