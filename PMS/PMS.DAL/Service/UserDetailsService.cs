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
    public class UserDetailsService
    {
        DataSet ds = null;
        public UserDetailsService()
        {

        }

        public UserDetails GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@userDetailId", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.UserDetails.GETUSERDETAILSBYPRC, lstSqlParameter, "UserDetails");
            UserDetails userDetails = new UserDetails();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                userDetails.UserDetailId = Convert.ToInt32(ds.Tables[0].Rows[i]["UserDetailId"]);
                userDetails.FirstName = Convert.ToString(ds.Tables[0].Rows[i]["FirstName"]);
                userDetails.LastName = Convert.ToString(ds.Tables[0].Rows[i]["LastName"]);
              userDetails.DateOfJoining = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateOfJoining"]);
                userDetails.MobileNumber = Convert.ToString(ds.Tables[0].Rows[i]["MobileNumber"]);
                userDetails.UserName = Convert.ToString(ds.Tables[0].Rows[i]["EmailId"]);
                userDetails.UserId = Convert.ToInt32(ds.Tables[0].Rows[i]["UserId"]);
                
            }
            return userDetails;
        }

        public void Add(UserDetails userDetails)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@createdDate", DateTime.Now));
            lstSqlParameter.Add(new SqlParameter("@createdUserId", userDetails.CreatedUserId));
            lstSqlParameter.Add(new SqlParameter("@firstName", userDetails.FirstName));
            lstSqlParameter.Add(new SqlParameter("@lastName", userDetails.LastName));
           lstSqlParameter.Add(new SqlParameter("@dateOfJoining", userDetails.DateOfJoining));
            lstSqlParameter.Add(new SqlParameter("@mobileNumber", userDetails.MobileNumber));
            lstSqlParameter.Add(new SqlParameter("@emailId", userDetails.UserName));
            lstSqlParameter.Add(new SqlParameter("@userId", userDetails.UserId));
            

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.UserDetails.ADDUSERDETAILSPRC, lstSqlParameter);
        }

        public Boolean Delete(int userDetailId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@userDetailId", userDetailId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.UserDetails.DELETEUSERDETAILSPRC, lstSqlParameter);
        }

        public List<UserDetails> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.UserDetails.GETUSERDETAILSPRC);

            List<UserDetails> lstUserDetails = new List<UserDetails>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                UserDetails userDetails = new UserDetails();
                userDetails.UserDetailId = Convert.ToInt32(ds.Tables[0].Rows[i]["UserDetailId"]);
                userDetails.FirstName = Convert.ToString(ds.Tables[0].Rows[i]["FirstName"]);
                userDetails.LastName = Convert.ToString(ds.Tables[0].Rows[i]["LastName"]);
                userDetails.DateOfJoining = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateOfJoining"]);
                userDetails.MobileNumber = Convert.ToString(ds.Tables[0].Rows[i]["MobileNumber"]);
                userDetails.EmailId = Convert.ToString(ds.Tables[0].Rows[i]["EmailId"]);
                userDetails.UserId = Convert.ToInt32(ds.Tables[0].Rows[i]["UserId"]);
                userDetails.UserName = Convert.ToString(ds.Tables[0].Rows[i]["UserName"]);
                lstUserDetails.Add(userDetails);
            }
            return lstUserDetails;
        }

        public void Update(UserDetails userDetails)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@lastModifiedDate", DateTime.Now));
            lstSqlParameter.Add(new SqlParameter("@lastModifiedUserId", userDetails.CreatedUserId));
            lstSqlParameter.Add(new SqlParameter("@firstName", userDetails.FirstName));
            lstSqlParameter.Add(new SqlParameter("@lastName", userDetails.LastName));
            lstSqlParameter.Add(new SqlParameter("@dateOfJoining", userDetails.DateOfJoining));
            lstSqlParameter.Add(new SqlParameter("@mobileNumber", userDetails.MobileNumber));
            lstSqlParameter.Add(new SqlParameter("@emailId", userDetails.EmailId));
            lstSqlParameter.Add(new SqlParameter("@userId", userDetails.UserId));
            lstSqlParameter.Add(new SqlParameter("@userDetailId", userDetails.UserDetailId));
           

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.UserDetails.UPDATEUSERDETAILSPRC, lstSqlParameter);
        }

    }
}
