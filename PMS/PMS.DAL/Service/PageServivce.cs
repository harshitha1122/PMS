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
    public class PageService
    {
        DataSet ds = null;
        public PageService()
        {

        }

        public Page GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@page", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Page.GETPAGEPRC, lstSqlParameter, "Page");
            Page page = new Page();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                page.PageId = Convert.ToInt32(ds.Tables[0].Rows[i]["PageId"]);
                page.PageName = Convert.ToString(ds.Tables[0].Rows[i]["PageName"]);
                page.PageDescription= Convert.ToString(ds.Tables[0].Rows[i]["PageDescription"]);
            }
            return page;
        }

        public void Add(Page page)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@pageName", page.PageName));
            lstSqlParameter.Add(new SqlParameter("@pageDescription", page.PageDescription));
            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Page.ADDPAGEPRC, lstSqlParameter);
        }

        public Boolean Delete(int pageId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@pageId", pageId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Page.DELETEPAGEPRC, lstSqlParameter);
        }

        public List<Page> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Page.GETPAGEPRC);

            List<Page> lstPage = new List<Page>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Page page = new Page();
                page.PageId = Convert.ToInt32(ds.Tables[0].Rows[i]["PageId"]);
                page.PageName = Convert.ToString(ds.Tables[0].Rows[i]["PageName"]);
                page.PageDescription = Convert.ToString(ds.Tables[0].Rows[i]["PageDescription"]);

                lstPage.Add(page);
            }
            return lstPage;
        }

        public void Update(Page page)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@pageid", page.PageId));
            lstSqlParameter.Add(new SqlParameter("@pageName", page.PageName));
            lstSqlParameter.Add(new SqlParameter("@pageDescription", page.PageDescription));


            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Page.UPDATEPAGEPRC, lstSqlParameter);
        }

    }
}
