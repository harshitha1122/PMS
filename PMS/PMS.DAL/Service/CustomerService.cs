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
    public class CustomerService
    {
        DataSet ds = null;
        public CustomerService()
        {

        }

        public Customer GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@customerId", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Customer.GETCUSTOMERPRC, lstSqlParameter, "Customer");
            Customer customer = new Customer();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                customer.CustomerId = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerId"]);
                customer.FirstName = Convert.ToString(ds.Tables[0].Rows[i]["FirstName"]);
                customer.LastName = Convert.ToString(ds.Tables[0].Rows[i]["LastName"]);
                customer.MobileNumber = Convert.ToString(ds.Tables[0].Rows[i]["MobileNumber"]);
                customer.EmailId = Convert.ToString(ds.Tables[0].Rows[i]["EmailId"]);
                
            }
            return customer;
        }

        public void Add(Customer customer)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@firstName", customer.FirstName));
            lstSqlParameter.Add(new SqlParameter("@lastName", customer.LastName));
            lstSqlParameter.Add(new SqlParameter("@mobileNumber", customer.MobileNumber));
            lstSqlParameter.Add(new SqlParameter("@emailId", customer.EmailId));
            lstSqlParameter.Add(new SqlParameter("@createdUserId", customer.CreatedUserId));
            lstSqlParameter.Add(new SqlParameter("@createdDate", DateTime.Now));
            

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Customer.ADDCUSTOMERPRC, lstSqlParameter);
        }

        public Boolean Delete(int customerId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@customerId", customerId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Customer.DELETECUSTOMERPRC, lstSqlParameter);
        }

        public List<Customer> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Customer.GETCUSTOMERPRC);

            List<Customer> lstCustomer = new List<Customer>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Customer customer = new Customer();
                customer.CustomerId = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerId"]);
                customer.FirstName = Convert.ToString(ds.Tables[0].Rows[i]["FirstName"]);
                customer.LastName = Convert.ToString(ds.Tables[0].Rows[i]["LastName"]);
                customer.MobileNumber = Convert.ToString(ds.Tables[0].Rows[i]["MobileNumber"]);
                customer.EmailId = Convert.ToString(ds.Tables[0].Rows[i]["EmailId"]);
               
                lstCustomer.Add(customer);
            }
            return lstCustomer;
        }

        public void Update(Customer customer)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@customerId", customer.CustomerId));
            lstSqlParameter.Add(new SqlParameter("@lastModifiedUserId", customer.LastModifiedUserId));
            lstSqlParameter.Add(new SqlParameter("@firstName", customer.FirstName));
            lstSqlParameter.Add(new SqlParameter("@lastName", customer.LastName));
            lstSqlParameter.Add(new SqlParameter("@lastModifiedDate", DateTime.Now));
            lstSqlParameter.Add(new SqlParameter("@mobileNumber", customer.MobileNumber));
            lstSqlParameter.Add(new SqlParameter("@emailId", customer.EmailId));
           

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Customer.UPDATECUSTOMERPRC, lstSqlParameter);
        }

    }
}
