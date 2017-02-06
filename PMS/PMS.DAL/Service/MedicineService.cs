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
    public class MedicineService
    {
        DataSet ds = null;
        public MedicineService()
        {

        }

        public Medicine GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@medicine", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Medicine.GETMEDICINEPRC, lstSqlParameter, "Medicine");
            Medicine medicine = new Medicine();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                medicine.MedicineId = Convert.ToInt32(ds.Tables[0].Rows[i]["MedicineId"]);
                medicine.MedicineName = Convert.ToString(ds.Tables[0].Rows[i]["MedicineName"]);
                medicine.MedicineTypeId = Convert.ToInt32(ds.Tables[0].Rows[i]["MedicineTypeId"]);
                medicine.CompanyId = Convert.ToInt32(ds.Tables[0].Rows[i]["CompanyId"]);
                medicine.Weight = Convert.ToInt32(ds.Tables[0].Rows[i]["Weight"]);
                medicine.UnitTypeId = Convert.ToInt32(ds.Tables[0].Rows[i]["UnitTypeId"]);

            }
            return medicine;
        }

        public void Add(Medicine medicine)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@medicineName", medicine.MedicineName));
            lstSqlParameter.Add(new SqlParameter("@medicineTypeId", medicine.MedicineTypeId));
            lstSqlParameter.Add(new SqlParameter("@companyId", medicine.CompanyId));
            lstSqlParameter.Add(new SqlParameter("@weight", medicine.Weight));
            lstSqlParameter.Add(new SqlParameter("@unitTypeId", medicine.UnitTypeId));
            lstSqlParameter.Add(new SqlParameter("@createdDate", DateTime.Now));
            lstSqlParameter.Add(new SqlParameter("@createdUserId", medicine.CreatedUserId));



            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Medicine.ADDMEDICINEPRC, lstSqlParameter);
        }

        public Boolean Delete(int medicineId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@medicineId", medicineId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Medicine.DELETEMEDICINEPRC, lstSqlParameter);
        }

        public List<Medicine> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Medicine.GETMEDICINEPRC);

            List<Medicine> lstMedicine = new List<Medicine>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Medicine medicine = new Medicine();
                medicine.MedicineId = Convert.ToInt32(ds.Tables[0].Rows[i]["MedicineId"]);
                medicine.MedicineName = Convert.ToString(ds.Tables[0].Rows[i]["MedicineName"]);
                medicine.MedicineTypeId = Convert.ToInt32(ds.Tables[0].Rows[i]["MedicineTypeId"]);
                medicine.CompanyId = Convert.ToInt32(ds.Tables[0].Rows[i]["CompanyId"]);
                medicine.Weight = Convert.ToInt32(ds.Tables[0].Rows[i]["Weight"]);
                medicine.UnitTypeId = Convert.ToInt32(ds.Tables[0].Rows[i]["UnitTypeId"]);
                medicine.UnitType = Convert.ToString(ds.Tables[0].Rows[i]["UnitType"]);
                medicine.MedicineType = Convert.ToString(ds.Tables[0].Rows[i]["MedicineType"]);
                medicine.CompanyName = Convert.ToString(ds.Tables[0].Rows[i]["CompanyName"]);
                lstMedicine.Add(medicine);
            }
            return lstMedicine;
        }

        public void Update(Medicine medicine)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

           
            lstSqlParameter.Add(new SqlParameter("@medicineName", medicine.MedicineName));
            lstSqlParameter.Add(new SqlParameter("@medicineTypeId", medicine.MedicineTypeId));
            lstSqlParameter.Add(new SqlParameter("@companyId", medicine.CompanyId));
            lstSqlParameter.Add(new SqlParameter("@weight", medicine.Weight));
            lstSqlParameter.Add(new SqlParameter("@unitTypeId", medicine.UnitTypeId));
            lstSqlParameter.Add(new SqlParameter("@lastModifiedDate", DateTime.Now));
            lstSqlParameter.Add(new SqlParameter("@lastModifiedUserId", medicine.LastModifiedUserId));
            lstSqlParameter.Add(new SqlParameter("@medicineId", medicine.MedicineId));

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.Medicine.UPDATEMEDICINEPRC, lstSqlParameter);
        }

        public bool IsMedicineNameExists(string medicineName)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@medicineName", medicineName));
            return SqlHelper.ExecuteScalar(StoredProcedureConstants.Medicine.ISMEDICINENAMEEXISTSPRC, lstSqlParameter).Equals("1");
        }
    }
}
