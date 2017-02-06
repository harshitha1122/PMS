using PMS.BAL.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class MedicineQuantity : System.Web.UI.Page
    {
        MedicineQuantityManager medicineQuantityManager = new MedicineQuantityManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMedicineQuantityGrid();
                
                BindMedicineNameDropDown();
                
            }
        }

       
        private void BindMedicineNameDropDown()
        {
            MedicineManager medicineManager = new MedicineManager();
            ddlMedicine.DataSource = medicineManager.GetAll();
            ddlMedicine.DataBind();
            ddlMedicine.Items.Insert(0, new ListItem("--Select--"));
        }
       
        private void BindMedicineQuantityGrid()
        {
            grvMedicineQuantity.DataSource = medicineQuantityManager.GetAll();
            grvMedicineQuantity.DataBind();
        }


        //[WebMethod]
        //public static string IsMedicineNameExists(string medicineName)
        //{
        //    if (medicineName == "Test")
        //        return "1";
        //    return "0";
        //    //else
        //    //    return "0";
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
                Core.Entity.MedicineQuantity medicineQuantity = new Core.Entity.MedicineQuantity();
               
            medicineQuantity.DateOfPurchase = Convert.ToDateTime(txtDateOfPurchase.Text);
            medicineQuantity.ExpiryDate = Convert.ToDateTime(txtExpiryDate.Text);
            medicineQuantity.ManfactureDate = Convert.ToDateTime(txtManfactureDate.Text);
            medicineQuantity.Price = Convert.ToDecimal(txtPrice.Text);
            medicineQuantity.MedQuantity = Convert.ToInt32(txtMedQuantity.Text);
            medicineQuantity.MedicineId = Convert.ToInt32(ddlMedicine.SelectedValue);
                

                medicineQuantityManager.Add(medicineQuantity);
                BindMedicineQuantityGrid();
                ResetControls();
           
        }

        private void ResetControls()
        {
            txtDateOfPurchase.Text = String.Empty;
            txtExpiryDate.Text = String.Empty;
            txtManfactureDate.Text = String.Empty;
            txtPrice.Text = String.Empty;
            txtMedQuantity.Text = String.Empty;
            ddlMedicine.SelectedIndex = -1;
            
        }

        protected void grvMedicineQuantity_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvMedicineQuantity.EditIndex = -1;
            BindMedicineQuantityGrid();
        }

        protected void grvMedicineQuantity_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int quantityId = Convert.ToInt32(grvMedicineQuantity.DataKeys[e.RowIndex].Value.ToString());
            medicineQuantityManager.Delete(quantityId);
            BindMedicineQuantityGrid();
        }

        protected void grvMedicineQuantity_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvMedicineQuantity.EditIndex = e.NewEditIndex;
            BindMedicineQuantityGrid();
        }

        protected void grvMedicineQuantity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMedicineQuantity.PageIndex = e.NewPageIndex;
            BindMedicineQuantityGrid();
        }

        protected void grvMedicineQuantity_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int quantityId = Convert.ToInt32(grvMedicineQuantity.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvMedicineQuantity.Rows[e.RowIndex];


            TextBox textDateOfPurchase = (TextBox)row.Cells[1].Controls[0];
            TextBox textExpiryDate = (TextBox)row.Cells[2].Controls[0];
            TextBox textManfactureDate = (TextBox)row.Cells[3].Controls[0];
            TextBox textPrice = (TextBox)row.Cells[4].Controls[0];
            TextBox textQuantity = (TextBox)row.Cells[5].Controls[0];
            DropDownList ddlGridMedicineName = (DropDownList)row.Cells[6].Controls[1].FindControl("ddlGridMedicineName");

            Core.Entity.MedicineQuantity medicineQuantity = new Core.Entity.MedicineQuantity();

            medicineQuantity.DateOfPurchase = DateTime.Parse(textDateOfPurchase.Text);
            medicineQuantity.ExpiryDate = DateTime.Parse(textExpiryDate.Text);
            medicineQuantity.ManfactureDate = DateTime.Parse(textManfactureDate.Text);
            medicineQuantity.Price = Int32.Parse(textPrice.Text);
            medicineQuantity.MedQuantity = Int32.Parse(textQuantity.Text);
            medicineQuantity.MedicineId = Int32.Parse(ddlGridMedicineName.SelectedValue);
            medicineQuantity.QuantityId = Convert.ToInt32(grvMedicineQuantity.DataKeys[e.RowIndex].Value);


            //ddlCompany.DataTextField = "CompanyId";
            // ddlCompany.Items.Insert(0, New ListItem("Please select"))

            //ddlCompany.Items.Insert(0, NewListItem("", ""));
            medicineQuantityManager.Update(medicineQuantity);

            grvMedicineQuantity.EditIndex = -1;
            BindMedicineQuantityGrid();



        }

        protected void grvMedicineQuantity_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grvMedicineQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvMedicineQuantity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (grvMedicineQuantity.EditIndex == e.Row.RowIndex)
                {
                    DropDownList ddlMedicineName = (DropDownList)e.Row.FindControl("ddlGridMedicineName");

                    MedicineManager medicineManager = new MedicineManager();
                    ddlMedicineName.DataSource = medicineManager.GetAll();
                    ddlMedicineName.DataBind();

                    var medicineName = (e.Row.FindControl("lblMedicineName") as Label).Text;
                    var selectedItem = ddlMedicineName.Items.FindByValue(medicineName);
                    selectedItem.Selected = true;

                    
                }
            }
        }
    }
}