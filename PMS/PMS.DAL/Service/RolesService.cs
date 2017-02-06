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
    public class RolesService
    {
        DataSet ds = null;
        public RolesService()
        {

        }

        public Roles GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@roles", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Roles.GETROLESPRC, lstSqlParameter, "Roles");
            Roles roles = new Roles();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                roles.RoleId = Convert.ToInt32(ds.Tables[0].Rows[i]["RoleId"]);
                roles.RoleName = Convert.ToString(ds.Tables[0].Rows[i]["RoleName"]);
                

            }
            return roles;
        }

        public void Add(Roles roles)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@roleName", roles.RoleName));
            


            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Roles.ADDROLESPRC, lstSqlParameter);
        }

        public Boolean Delete(int roleId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@roleId", roleId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Roles.DELETEROLESPRC, lstSqlParameter);
        }

        public List<Roles> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Roles.GETROLESPRC);

            List<Roles> lstRoles = new List<Roles>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Roles roles = new Roles();
                roles.RoleId = Convert.ToInt32(ds.Tables[0].Rows[i]["RoleId"]);
                roles.RoleName = Convert.ToString(ds.Tables[0].Rows[i]["RoleName"]);
                

                lstRoles.Add(roles);
            }
            return lstRoles;
        }

        public void Update(Roles roles)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@roleId", roles.RoleId));
            lstSqlParameter.Add(new SqlParameter("@roleName", roles.RoleName));
           


            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Roles.UPDATEROLESPRC, lstSqlParameter);
        }

    }
}
