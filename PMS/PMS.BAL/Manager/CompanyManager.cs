using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{

    public class CompanyManager
    {
        public CompanyService companyService = null;

        public CompanyManager()
        {
            companyService = new CompanyService();
        }

        public void Add(Company company)
        {
            companyService.Add(company);
        }

        public Boolean Delete(int companyId)
        {
            return companyService.Delete(companyId);
        }

        public List<Company> GetAll()
        {
            return companyService.GetAll();
        }

        public void Update(Company company)
        {
            companyService.Update(company);
        }

        public Company GetById(Int32 companyId)
        {
            return companyService.GetById(companyId);
        }
    }
}
