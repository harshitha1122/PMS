using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Constants
{
    public static class Constant
    {
        public const string ConnectionString = "PMSConnectionString";
    }

    public static class AppConfigConstants
    {
        public const string IsSqlLoggingEnable = "IsSqlLoggingEnable";
        public const string IsSendEmailEnable = "IsSendEmailEnable";
    }

    public class StoredProcedureConstants
    {
        public static class Company
        {
            //Stored procedure for Company Tables.
            public static string GETCOMPANYPRC = "GetCompanyPrc";
            public static string GETCOMPANYBYIDPRC = "GetCompanyByIdPrc";
            public static string UPDATECOMPANYPRC = "UpdateCompanyPrc";
            public static string DELETECOMPANYPRC = "DeleteCompanyPrc";
            public static string ADDCOMPANYPRC = "AddCompanyPrc";
        }
        public static class Customer
        {
            //Stored procedure for Customer Tables.
            public static string GETCUSTOMERPRC = "GetCustomerPrc";
            public static string GETCUSTOMERBYIDPRC = "GetCustomerByIdPrc";
            public static string UPDATECUSTOMERPRC = "UpdateCustomerPrc";
            public static string DELETECUSTOMERPRC = "DeleteCustomerPrc";
            public static string ADDCUSTOMERPRC = "AddCustomerPrc";
        }
        public static class LkpMedicineType
        {
            //Stored procedure for LkpMedicineType Tables.
            public static string GETLKPMEDICINETYPEPRC = "GetLkpMedicineTypePrc";
            public static string GETLKPMEDICINETYPEBYIDPRC = "GetLkpMedicineTypeByIdPrc";
            public static string UPDATELKPMEDICINETYPEPRC = "UpdateLkpMedicineTypePrc";
            public static string DELETELKPMEDICINETYPEPRC = "DeleteLkpMedicineTypePrc";
            public static string ADDLKPMEDICINETYPEPRC = "AddLkpMedicineTypePrc";
        }
        public static class LkpUnitType
        {
            //Stored procedure for LkpUnitType Tables.
            public static string GETLKPUNITTYPEPRC = "GetLkpUnitTypePrc";
            public static string GETLKPUNITTYPEBYIDPRC = "GetLkpUnitTypeByIdPrc";
            public static string UPDATELKPUNITTYPEPRC = "UpdateLkpUnitTypePrc";
            public static string DELETELKPUNITTYPEPRC = "DeleteLkpUnitTypePrc";
            public static string ADDLKPUNITTYPEPRC = "AddLkpUnitTypePrc";
        }
        public static class Medicine
        {
            //Stored procedure for Medicine Tables.
            public static string GETMEDICINEPRC = "GetMedicinePrc";
            public static string GETMEDICINEBYIDPRC = "GetMedicineByIdPrc";
            public static string UPDATEMEDICINEPRC = "UpdateMedicinePrc";
            public static string DELETEMEDICINEPRC = "DeleteMedicinePrc";
            public static string ADDMEDICINEPRC = "AddMedicinePrc";
            public static string ISMEDICINENAMEEXISTSPRC = "IsMedicineNameExistsPrc";
        }
        public static class Page
        {
            //Stored procedure for Page Tables.
            public static string GETPAGEPRC = "GetPagePrc";
            public static string GETPAGEBYIDPRC = "GetPageByIdPrc";
            public static string UPDATEPAGEPRC = "UpdatePagePrc";
            public static string DELETEPAGEPRC = "DeletePagePrc";
            public static string ADDPAGEPRC = "AddPagePrc";
        }
        public static class PageToRole
        {
            //Stored procedure for PageToRole Tables.
            public static string GETPAGETOROLEPRC = "GetPageToRolePrc";
            public static string GETPAGETOROLEBYIDPRC = "GetPageToRoleByIdPrc";
            public static string UPDATEPAGETOROLEPRC = "UpdatePageToRolePrc";
            public static string DELETEPAGETOROLEPRC = "DeletePageToRolePrc";
            public static string ADDPAGETOROLEPRC = "AddPageToRolePrc";
        }
        public static class PurchaseOrder
        {
            //Stored procedure for PurchaseOrder Tables.
            public static string GETPURCHASEORDERPRC = "GetPurchaseOrderPrc";
            public static string GETPURCHASEORDERBYIDPRC = "GetPurchaseOrderByIdPrc";
            public static string UPDATEPURCHASEORDERPRC = "UpdatePurchaseOrderPrc";
            public static string DELETEPURCHASEORDERPRC = "DeletePurchaseOrderPrc";
            public static string ADDPURCHASEORDERPRC = "AddPurchaseOrderPrc";
        }
        public static class MedicineQuantity
        {
            //Stored procedure for MedicineQuantity Tables.
            public static string GETMEDICINEQUANTITYPRC = "GetMedicineQuantityPrc";
            public static string GETMEDICINEQUANTITYBYIDPRC = "GetMedicineQuantityByIdPrc";
            public static string UPDATEMEDICINEQUANTITYPRC = "UpdateMedicineQuantityPrc";
            public static string DELETEMEDICINEQUANTITYPRC = "DeleteMedicineQuantityPrc";
            public static string ADDMEDICINEQUANTITYPRC = "AddMedicineQuantityPrc";
        }
        public static class Roles
        {
            //Stored procedure for Roles Tables.
            public static string GETROLESPRC = "GetRolesPrc";
            public static string GETROLESBYPRC = "GetRolesByIdPrc";
            public static string UPDATEROLESPRC = "UpdateRolesPrc";
            public static string DELETEROLESPRC = "DeleteRolesPrc";
            public static string ADDROLESPRC = "AddRolesPrc";
        }
        public static class UserDetails
        {
            //Stored procedure for UserDetails Tables.
            public static string GETUSERDETAILSPRC = "GetUserDetailsPrc";
            public static string GETUSERDETAILSBYPRC = "GetUserDetailsByIdPrc";
            public static string UPDATEUSERDETAILSPRC = "UpdateUserDetailsPrc";
            public static string DELETEUSERDETAILSPRC = "DeleteUserDetailsPrc";
            public static string ADDUSERDETAILSPRC = "AddUserDetailsPrc";
        }
        public static class Users
        {
            //Stored procedure for Users Tables.
            public static string GETUSERSPRC = "GetUsersPrc";
            public static string GETUSERSBYPRC = "GetUsersByIdPrc";
            public static string UPDATEUSERPRC = "UpdateUsersPrc";
            public static string DELETEUSERSPRC = "DeleteUsersPrc";
            public static string ADDUSERSPRC = "AddUsersPrc";
        }
    }
    
}
