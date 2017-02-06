using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{

    public class CustomerManager
    {
        public CustomerService customerService = null;

        public CustomerManager()
        {
            customerService = new CustomerService();
        }

        public void Add(Customer customer)
        {
            customerService.Add(customer);
        }

        public bool Delete(int customerId)
        {
            return customerService.Delete(customerId);
        }

        public List<Customer> GetAll()
        {
            return customerService.GetAll();
        }

        public void Update(Customer customer)
        {
            customerService.Update(customer);
        }

        public Customer GetById(Int32 customerId)
        {
            return customerService.GetById(customerId);
        }
    }
}
