using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{

    public class PurchaseOrderManager
    {
        public PurchaseOrderService purchaseOrderService = null;

        public PurchaseOrderManager()
        {
            purchaseOrderService = new PurchaseOrderService();
        }

        public void Add(PurchaseOrder purchaseOrder)
        {
            purchaseOrderService.Add(purchaseOrder);
        }

        public Boolean Delete(int purchaseOrderId)
        {
            return purchaseOrderService.Delete(purchaseOrderId);
        }

        public List<PurchaseOrder> GetAll()
        {
            return purchaseOrderService.GetAll();
        }

        public void Update(PurchaseOrder purchaseOrder)
        {
            purchaseOrderService.Update(purchaseOrder);
        }

        public PurchaseOrder GetById(Int32 purchaseOrderId)
        {
            return purchaseOrderService.GetById(purchaseOrderId);
        }
    }
}
