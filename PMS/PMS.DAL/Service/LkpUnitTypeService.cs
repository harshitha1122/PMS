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
   
    public class LkpUnitTypeService
    {
        DataSet ds = null;
        public LkpUnitTypeService()
        {
            
        }

        public LkpUnitType GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@lkpUnitType", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.LkpUnitType.GETLKPUNITTYPEPRC, lstSqlParameter, "LkpUnitType");
            LkpUnitType lkpUnitType = new LkpUnitType();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lkpUnitType.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]);
                lkpUnitType.UnitType = Convert.ToString(ds.Tables[0].Rows[i]["UnitType"]);
                lkpUnitType.UnitTypeDesc = Convert.ToString(ds.Tables[0].Rows[i]["UnitTypeDesc"]);

            }
            return lkpUnitType;
        }

        public void Add(LkpUnitType lkpUnitType)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@unitType", lkpUnitType.UnitType));
            lstSqlParameter.Add(new SqlParameter("@unitTypeDesc", lkpUnitType.UnitTypeDesc));


            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.LkpUnitType.ADDLKPUNITTYPEPRC, lstSqlParameter);
        }

        public Boolean Delete(int lkpUnitTypeId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@id", lkpUnitTypeId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.LkpUnitType.DELETELKPUNITTYPEPRC, lstSqlParameter);
        }

        public List<LkpUnitType> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.LkpUnitType.GETLKPUNITTYPEPRC);

            List<LkpUnitType> lstLkpUnitType = new List<LkpUnitType>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                LkpUnitType lkpUnitType = new LkpUnitType();
                lkpUnitType.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]);
                lkpUnitType.UnitType = Convert.ToString(ds.Tables[0].Rows[i]["UnitType"]);
                lkpUnitType.UnitTypeDesc = Convert.ToString(ds.Tables[0].Rows[i]["UnitTypeDesc"]);

                lstLkpUnitType.Add(lkpUnitType);
            }
            return lstLkpUnitType;
        }

        public void Update(LkpUnitType lkpUnitType)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@id", lkpUnitType.Id));
            lstSqlParameter.Add(new SqlParameter("@unitType", lkpUnitType.UnitType));
            lstSqlParameter.Add(new SqlParameter("@unitTypeDesc", lkpUnitType.UnitTypeDesc));


            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.LkpUnitType.UPDATELKPUNITTYPEPRC, lstSqlParameter);
        }

    }
}
