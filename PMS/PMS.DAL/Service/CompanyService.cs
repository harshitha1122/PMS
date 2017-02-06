using PMS.Core.Constants;
using PMS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Service
{
    public class CompanyService
    {
        DataSet ds = null;
        public CompanyService()
        {

        }

        public Company GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@companyId", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Company.GETCOMPANYBYIDPRC, lstSqlParameter,"Company");
            Company company = new Company();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                company.CompanyId = Convert.ToInt32(ds.Tables[0].Rows[i]["CompanyId"]);
                company.CompanyName = Convert.ToString(ds.Tables[0].Rows[i]["CompanyName"]);
                company.Address = Convert.ToString(ds.Tables[0].Rows[i]["Address"]);
                company.CompanyReg = Convert.ToString(ds.Tables[0].Rows[i]["CompanyReg"]);
                company.PhoneNumber = Convert.ToString(ds.Tables[0].Rows[i]["PhoneNumber"]);
                company.Website = Convert.ToString(ds.Tables[0].Rows[i]["Website"]);
            }
            return company;
        }

        public void Add(Company company)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@createdUserId", company.CreatedUserId));
            lstSqlParameter.Add(new SqlParameter("@companyName", company.CompanyName));
            lstSqlParameter.Add(new SqlParameter("@companyReg", company.CompanyReg));
            lstSqlParameter.Add(new SqlParameter("@createdDate", DateTime.Now));
            lstSqlParameter.Add(new SqlParameter("@phoneNumber", company.PhoneNumber));
            lstSqlParameter.Add(new SqlParameter("@website", company.Website));
            lstSqlParameter.Add(new SqlParameter("@address", company.Address));

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Company.ADDCOMPANYPRC, lstSqlParameter);
        }

        public Boolean Delete(int companyId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@companyId", companyId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Company.DELETECOMPANYPRC, lstSqlParameter);
        }

        public List<Company> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Company.GETCOMPANYPRC);
            
            List<Company> lstCompany = new List<Company>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Company company = new Company();
                company.CompanyId = Convert.ToInt32(ds.Tables[0].Rows[i]["CompanyId"]);
                company.CompanyName = Convert.ToString(ds.Tables[0].Rows[i]["CompanyName"]);
                company.Address = Convert.ToString(ds.Tables[0].Rows[i]["Address"]);
                company.CompanyReg = Convert.ToString(ds.Tables[0].Rows[i]["CompanyReg"]);
                company.PhoneNumber = Convert.ToString(ds.Tables[0].Rows[i]["PhoneNumber"]);
                company.Website = Convert.ToString(ds.Tables[0].Rows[i]["Website"]);
                lstCompany.Add(company);
            }
            return lstCompany;
        }

        public void Update(Company company)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@companyId", company.CompanyId));
            lstSqlParameter.Add(new SqlParameter("@lastModifiedUserId", company.LastModifiedUserId));
            lstSqlParameter.Add(new SqlParameter("@companyName", company.CompanyName));
            lstSqlParameter.Add(new SqlParameter("@companyReg", company.CompanyReg));
            lstSqlParameter.Add(new SqlParameter("@lastModifiedDate", DateTime.Now));
            lstSqlParameter.Add(new SqlParameter("@phoneNumber", company.PhoneNumber));
            lstSqlParameter.Add(new SqlParameter("@website", company.Website));
            lstSqlParameter.Add(new SqlParameter("@address", company.Address));

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Company.UPDATECOMPANYPRC, lstSqlParameter);
        }

    }
}
