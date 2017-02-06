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
    public class PurchaseOrderService
    {
        DataSet ds = null;
        public PurchaseOrderService()
        {

        }

        public PurchaseOrder GetById(int id)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@purchaseOrderId", id));
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.PurchaseOrder.GETPURCHASEORDERBYIDPRC, lstSqlParameter, "PurchaseOrder");
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                purchaseOrder.PurchaseOrderId = Convert.ToInt32(ds.Tables[0].Rows[i]["PurchaseOrderId"]);
                purchaseOrder.MedicineId = Convert.ToInt32(ds.Tables[0].Rows[i]["MedicineId"]);
                purchaseOrder.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]);
                purchaseOrder.Price = Convert.ToInt32(ds.Tables[0].Rows[i]["Price"]);
                //purchaseOrder.PurchaseDate= Convert.ToInt32(ds.Tables[0].Rows[i]["PurchaseDate"]);
                purchaseOrder.TotalAmount = Convert.ToInt32(ds.Tables[0].Rows[i]["TotalAmount"]);
                purchaseOrder.CustomerId = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerId"]);


            }
            return purchaseOrder;
        }

        public void Add(PurchaseOrder purchaseOrder)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            
            lstSqlParameter.Add(new SqlParameter("@medicineId", purchaseOrder.MedicineId));
            lstSqlParameter.Add(new SqlParameter("@quantity", purchaseOrder.Quantity));
            
            lstSqlParameter.Add(new SqlParameter("@price", purchaseOrder.Price));
            //lstSqlParameter.Add(new SqlParameter("@purchaseDate", purchaseOrder.PurchaseDate));
            lstSqlParameter.Add(new SqlParameter("@totalAmount", purchaseOrder.TotalAmount));
            lstSqlParameter.Add(new SqlParameter("@createdUserId", purchaseOrder.CreatedUserId));
            lstSqlParameter.Add(new SqlParameter("@customerId", purchaseOrder.CustomerId));

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.PurchaseOrder.ADDPURCHASEORDERPRC, lstSqlParameter);
        }

        public Boolean Delete(int purchaseOrderId)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            lstSqlParameter.Add(new SqlParameter("@purchaseOrderId", purchaseOrderId));
            return SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.PurchaseOrder.DELETEPURCHASEORDERPRC, lstSqlParameter);
        }

        public List<PurchaseOrder> GetAll()
        {
            ds = SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.PurchaseOrder.GETPURCHASEORDERPRC);

            List<PurchaseOrder> lstPurchaseOrder = new List<PurchaseOrder>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                PurchaseOrder purchaseOrder = new PurchaseOrder();
                purchaseOrder.PurchaseOrderId = Convert.ToInt32(ds.Tables[0].Rows[i]["PurchaseOrderId"]);
                purchaseOrder.MedicineId = Convert.ToInt32(ds.Tables[0].Rows[i]["MedicineId"]);
                purchaseOrder.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]);
                purchaseOrder.Price = Convert.ToInt32(ds.Tables[0].Rows[i]["Price"]);
                //purchaseOrder.PurchaseDate = Convert.ToInt32(ds.Tables[0].Rows[i]["PurchaseDate"]);
                purchaseOrder.TotalAmount = Convert.ToInt32(ds.Tables[0].Rows[i]["TotalAmount"]);
                purchaseOrder.CustomerId = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerId"]);
                lstPurchaseOrder.Add(purchaseOrder);
            }
            return lstPurchaseOrder;
        }

        public void Update(PurchaseOrder purchaseOrder)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            lstSqlParameter.Add(new SqlParameter("@medicineId", purchaseOrder.MedicineId));
            lstSqlParameter.Add(new SqlParameter("@quantity", purchaseOrder.Quantity));

            lstSqlParameter.Add(new SqlParameter("@price", purchaseOrder.Price));
            //lstSqlParameter.Add(new SqlParameter("@purchaseDate", purchaseOrder.PurchaseDate));
            lstSqlParameter.Add(new SqlParameter("@totalAmount", purchaseOrder.TotalAmount));
            lstSqlParameter.Add(new SqlParameter("@createdUserId", purchaseOrder.CreatedUserId));
            lstSqlParameter.Add(new SqlParameter("@customerId", purchaseOrder.CustomerId));

            SqlHelper.ExecuteStoredProcedure(StoredProcedureConstants.PurchaseOrder.UPDATEPURCHASEORDERPRC, lstSqlParameter);
        }

    }
}
