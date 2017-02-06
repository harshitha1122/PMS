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
    public class UsersService
    {
        DataSet ds = null;
        public UsersService()
        {

        }

        public Users GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@userId", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Users.GETUSERSBYPRC, lstSqlParameter, "Users");
            Users users = new Users();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                users.UserId = Convert.ToInt32(ds.Tables[0].Rows[i]["UserId"]);
                users.UserName = Convert.ToString(ds.Tables[0].Rows[i]["UserName"]);
                users.Password = Convert.ToString(ds.Tables[0].Rows[i]["Password"]);
                users.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsActive"]);
                users.RoleId = Convert.ToInt32(ds.Tables[0].Rows[i]["RoleId"]);
            }
            return users;
        }

        public void Add(Users users)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@createdDate", DateTime.Now));
            lstSqlParameter.Add(new SqlParameter("@createdUserId", users.CreatedUserId));
            lstSqlParameter.Add(new SqlParameter("@userName", users.UserName));
            lstSqlParameter.Add(new SqlParameter("@password", users.Password));
            lstSqlParameter.Add(new SqlParameter("@isActive", users.IsActive));
            lstSqlParameter.Add(new SqlParameter("@roleId", users.RoleId));

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Users.ADDUSERSPRC, lstSqlParameter);
        }

        public Boolean Delete(int userId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@userId", userId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Users.DELETEUSERSPRC, lstSqlParameter);
        }

        public List<Users> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Users.GETUSERSPRC);

            List<Users> lstUsers = new List<Users>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Users users = new Users();
                users.UserId = Convert.ToInt32(ds.Tables[0].Rows[i]["UserId"]);
                users.UserName = Convert.ToString(ds.Tables[0].Rows[i]["UserName"]);
                users.Password = Convert.ToString(ds.Tables[0].Rows[i]["Password"]);
                users.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsActive"]);
                users.RoleId = Convert.ToInt32(ds.Tables[0].Rows[i]["RoleId"]);
                users.RoleName = Convert.ToString(ds.Tables[0].Rows[i]["RoleName"]);
                lstUsers.Add(users);
            }
            return lstUsers;
        }

        public void Update(Users users)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@lastModifiedDate", DateTime.Now));
            lstSqlParameter.Add(new SqlParameter("@lastModifiedUserId", users.CreatedUserId));
            lstSqlParameter.Add(new SqlParameter("@userName", users.UserName));
            lstSqlParameter.Add(new SqlParameter("@password", users.Password));
            lstSqlParameter.Add(new SqlParameter("@isActive", users.IsActive));
            lstSqlParameter.Add(new SqlParameter("@roleId", users.RoleId));
            lstSqlParameter.Add(new SqlParameter("@userId", users.UserId));

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Users.UPDATEUSERPRC, lstSqlParameter);
        }

    }
}
