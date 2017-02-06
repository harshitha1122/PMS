using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{

    public class UserDetailsManager
    {
        public UserDetailsService userDetailsService = null;

        public UserDetailsManager()
        {
            userDetailsService = new UserDetailsService();
        }

        public void Add(UserDetails userDetails)
        {
            userDetailsService.Add(userDetails);
        }

        public Boolean Delete(int userDetailsId)
        {
            return userDetailsService.Delete(userDetailsId);
        }

        public List<UserDetails> GetAll()
        {
            return userDetailsService.GetAll();
        }

        public void Update(UserDetails userDetails)
        {
            userDetailsService.Update(userDetails);
        }

        public UserDetails GetById(Int32 userDetailsId)
        {
            return userDetailsService.GetById(userDetailsId);
        }
    }
}
