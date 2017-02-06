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
    public class LkpMedicineTypeService
    {
        DataSet ds = null;
        public LkpMedicineTypeService()
        {

        }

        public LkpMedicineType GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@lkpMedicineType", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.LkpMedicineType.GETLKPMEDICINETYPEPRC, lstSqlParameter, "LkpMedicineType");
            LkpMedicineType lkpMedicineType = new LkpMedicineType();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lkpMedicineType.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]);
                lkpMedicineType.MedicineType = Convert.ToString(ds.Tables[0].Rows[i]["MedicineType"]);
                lkpMedicineType.MedicineTypeDesc = Convert.ToString(ds.Tables[0].Rows[i]["MedicineTypeDesc"]);

            }
            return lkpMedicineType;
        }

        public void Add(LkpMedicineType lkpMedicineType)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@medicineType", lkpMedicineType.MedicineType));
            lstSqlParameter.Add(new SqlParameter("@medicineTypeDesc", lkpMedicineType.MedicineTypeDesc));
            

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.LkpMedicineType.ADDLKPMEDICINETYPEPRC, lstSqlParameter);
        }

        public Boolean Delete(int medicineTypeId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@id", medicineTypeId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.LkpMedicineType.DELETELKPMEDICINETYPEPRC, lstSqlParameter);
        }

        public List<LkpMedicineType> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.LkpMedicineType.GETLKPMEDICINETYPEPRC);

            List<LkpMedicineType> lstLkpMedicineType = new List<LkpMedicineType>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                LkpMedicineType lkpMedicineType = new LkpMedicineType();
                lkpMedicineType.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]);
                lkpMedicineType.MedicineType = Convert.ToString(ds.Tables[0].Rows[i]["MedicineType"]);
                lkpMedicineType.MedicineTypeDesc = Convert.ToString(ds.Tables[0].Rows[i]["MedicineTypeDesc"]);

                lstLkpMedicineType.Add(lkpMedicineType);
            }
            return lstLkpMedicineType;
        }

        public void Update(LkpMedicineType lkpMedicineType)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@id", lkpMedicineType.Id));
            lstSqlParameter.Add(new SqlParameter("@medicineType", lkpMedicineType.MedicineType));
            lstSqlParameter.Add(new SqlParameter("@medicineTypeDesc", lkpMedicineType.MedicineTypeDesc));


            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.LkpMedicineType.UPDATELKPMEDICINETYPEPRC, lstSqlParameter);
        }

    }
}
