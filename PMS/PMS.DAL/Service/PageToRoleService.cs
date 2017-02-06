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
    public class PageToRoleService
    {
        DataSet ds = null;
        public PageToRoleService()
        {

        }

        public PageToRole GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@pageToRole", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.PageToRole.GETPAGETOROLEPRC, lstSqlParameter, "PageToRole");
            PageToRole pageToRole = new PageToRole();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                pageToRole.PageToRoleId = Convert.ToInt32(ds.Tables[0].Rows[i]["PageToRoleId"]);
                pageToRole.PageId = Convert.ToInt32(ds.Tables[0].Rows[i]["PageName"]);
                pageToRole.RoleId = Convert.ToInt32(ds.Tables[0].Rows[i]["RoleName"]);

            }
            return pageToRole;
        }

        public void Add(PageToRole pageToRole)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@pageId", pageToRole.PageId));
            lstSqlParameter.Add(new SqlParameter("@roleId", pageToRole.RoleId));


            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.PageToRole.ADDPAGETOROLEPRC, lstSqlParameter);
        }

        public Boolean Delete(int pageToRoleId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@pageToRoleId", pageToRoleId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.PageToRole.DELETEPAGETOROLEPRC, lstSqlParameter);
        }

        public List<PageToRole> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.PageToRole.GETPAGETOROLEPRC);

            List<PageToRole> lstPageToRole = new List<PageToRole>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                PageToRole pageToRole = new PageToRole();
                pageToRole.PageToRoleId = Convert.ToInt32(ds.Tables[0].Rows[i]["PageToRoleId"]);
                pageToRole.PageName = Convert.ToString(ds.Tables[0].Rows[i]["PageName"]);
                pageToRole.RoleName = Convert.ToString(ds.Tables[0].Rows[i]["RoleName"]);
                pageToRole.PageId = Convert.ToInt32(ds.Tables[0].Rows[i]["PageId"]);
                pageToRole.RoleId = Convert.ToInt32(ds.Tables[0].Rows[i]["RoleId"]);

                lstPageToRole.Add(pageToRole);
            }
            return lstPageToRole;
        }

        public void Update(PageToRole pageToRole)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@pageToRoleId", pageToRole.PageToRoleId));
            lstSqlParameter.Add(new SqlParameter("@pageId", pageToRole.PageId));
            lstSqlParameter.Add(new SqlParameter("@roleId", pageToRole.RoleId));


            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.PageToRole.UPDATEPAGETOROLEPRC, lstSqlParameter);
        }

    }
}
