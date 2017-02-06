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
    public class MedicineQuantityService
    {
        DataSet ds = null;
        public MedicineQuantityService()
        {

        }

        public MedicineQuantity GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@medicineQuantity", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.MedicineQuantity.GETMEDICINEQUANTITYPRC, lstSqlParameter, "MedicineQuantity");
            MedicineQuantity medicineQuantity = new MedicineQuantity();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                medicineQuantity.QuantityId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuantityId"]);
                medicineQuantity.DateOfPurchase = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateOfPurchase"]);
                medicineQuantity.ExpiryDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ExpiryDate"]);
                medicineQuantity.ManfactureDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ManfactureDate"]);
                medicineQuantity.Price = Convert.ToInt32(ds.Tables[0].Rows[i]["Price"]);
                medicineQuantity.MedQuantity = Convert.ToInt32(ds.Tables[0].Rows[i]["MedQuantity"]);
                medicineQuantity.MedicineId = Convert.ToInt32(ds.Tables[0].Rows[i]["MedicineId"]);

            }
            return medicineQuantity;
        }

        public void Add(MedicineQuantity medicineQuantity)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@dateOfPurchase", medicineQuantity.DateOfPurchase));
           lstSqlParameter.Add(new SqlParameter("@expiryDate", medicineQuantity.ExpiryDate));
            lstSqlParameter.Add(new SqlParameter("@manfactureDate", medicineQuantity.ManfactureDate));
            lstSqlParameter.Add(new SqlParameter("@price", medicineQuantity.Price));
            lstSqlParameter.Add(new SqlParameter("@medQuantity", medicineQuantity.MedQuantity));
            lstSqlParameter.Add(new SqlParameter("@createdDate", DateTime.Now));
            lstSqlParameter.Add(new SqlParameter("@createdUserId", medicineQuantity.CreatedUserId));
            lstSqlParameter.Add(new SqlParameter("@medicineId", medicineQuantity.MedicineId));



            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.MedicineQuantity.ADDMEDICINEQUANTITYPRC, lstSqlParameter);
        }

        public Boolean Delete(int quantityId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@quantityId", quantityId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.MedicineQuantity.DELETEMEDICINEQUANTITYPRC, lstSqlParameter);
        }

        public List<MedicineQuantity> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.MedicineQuantity.GETMEDICINEQUANTITYPRC);

            List<MedicineQuantity> lstMedicineQuantity = new List<MedicineQuantity>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                MedicineQuantity medicineQuantity = new MedicineQuantity();
                medicineQuantity.QuantityId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuantityId"]);
                medicineQuantity.DateOfPurchase = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateOfPurchase"]);
                medicineQuantity.ExpiryDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ExpiryDate"]);
                medicineQuantity.ManfactureDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ManfactureDate"]);
                medicineQuantity.Price = Convert.ToInt32(ds.Tables[0].Rows[i]["Price"]);
                medicineQuantity.MedQuantity = Convert.ToInt32(ds.Tables[0].Rows[i]["MedQuantity"]);
                medicineQuantity.MedicineId = Convert.ToInt32(ds.Tables[0].Rows[i]["MedicineId"]);
                medicineQuantity.MedicineName = Convert.ToString(ds.Tables[0].Rows[i]["MedicineName"]);



                lstMedicineQuantity.Add(medicineQuantity);
            }
            return lstMedicineQuantity;
        }

        public void Update(MedicineQuantity medicineQuantity)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

             lstSqlParameter.Add(new SqlParameter("@dateOfPurchase", medicineQuantity.DateOfPurchase));
            lstSqlParameter.Add(new SqlParameter("@expiryDate", medicineQuantity.ExpiryDate));
            lstSqlParameter.Add(new SqlParameter("@manfactureDate", medicineQuantity.ManfactureDate));
            lstSqlParameter.Add(new SqlParameter("@price", medicineQuantity.Price));
            lstSqlParameter.Add(new SqlParameter("@medQuantity", medicineQuantity.MedQuantity));
            lstSqlParameter.Add(new SqlParameter("@lastModifiedDate", DateTime.Now));
            lstSqlParameter.Add(new SqlParameter("@lastModifiedUserId", medicineQuantity.CreatedUserId));
            lstSqlParameter.Add(new SqlParameter("@medicineId", medicineQuantity.MedicineId));
            lstSqlParameter.Add(new SqlParameter("@quantityId", medicineQuantity.QuantityId));
            



            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.MedicineQuantity.UPDATEMEDICINEQUANTITYPRC, lstSqlParameter);
        }

    }
}
