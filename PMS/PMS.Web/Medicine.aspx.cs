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
    public partial class Medicine : System.Web.UI.Page
    {
        MedicineManager medicineManager = new MedicineManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMedicineGrid();
                BindMedicineTypeDropDown(ddlMedicineType);
                BindCompanyDropDown(ddlCompany);
              
                BindUnitTypeDropDown(ddlUnitType);
            }
        }

        private void BindMedicineTypeDropDown(DropDownList ddl)
        {
            LkpMedicineTypeManager lkpMedicineTypeManager = new LkpMedicineTypeManager();
            ddl.DataSource = lkpMedicineTypeManager.GetAll();
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--"));
        }

        private void BindCompanyDropDown(DropDownList ddl)
        {
            CompanyManager companyManager = new CompanyManager();
            ddl.DataSource = companyManager.GetAll();
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--"));
        }

        private void BindUnitTypeDropDown(DropDownList ddl)
        {
            LkpUnitTypeManager lkpUnitTypeManager = new LkpUnitTypeManager();
            ddl.DataSource = lkpUnitTypeManager.GetAll();
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--"));
        }

       
     
        private void BindMedicineGrid()
        {
            grvMedicine.DataSource = medicineManager.GetAll();
            grvMedicine.DataBind();
        }


       
        protected void btnSave_Click(object sender, EventArgs e)
        {
           
                Core.Entity.Medicine medicine = new Core.Entity.Medicine();
                medicine.MedicineName = textMedicineName.Text;
                medicine.MedicineTypeId = Convert.ToInt32(ddlMedicineType.SelectedValue);
                medicine.CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                medicine.Weight = Convert.ToInt32(textWeight.Text);
                medicine.UnitTypeId = Convert.ToInt32(ddlUnitType.SelectedValue);
                medicineManager.Add(medicine);
                BindMedicineGrid();
                ResetControls();
        }

        private void ResetControls()
        {
            textMedicineName.Text = String.Empty;
            ddlMedicineType.SelectedIndex = -1;
            ddlCompany.SelectedIndex = -1;
            textWeight.Text = String.Empty;
            ddlUnitType.SelectedIndex = -1;
        }

        protected void grvMedicine_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvMedicine.EditIndex = -1;
            BindMedicineGrid();
        }

        protected void grvMedicine_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int medicineId = Convert.ToInt32(grvMedicine.DataKeys[e.RowIndex].Value.ToString());
            medicineManager.Delete(medicineId);
            BindMedicineGrid();
        }

        protected void grvMedicine_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvMedicine.EditIndex = e.NewEditIndex;
            BindMedicineGrid();
        }

        protected void grvMedicine_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMedicine.PageIndex = e.NewPageIndex;
            BindMedicineGrid();
        }
        
        protected void grvMedicine_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int medicineId = Convert.ToInt32(grvMedicine.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvMedicine.Rows[e.RowIndex];


            TextBox textMedicineName = (TextBox)row.Cells[1].Controls[0];
            DropDownList ddlGridMedicineType = (DropDownList)row.Cells[2].Controls[1].FindControl("ddlGridMedicineType");
            DropDownList ddlGridCompany = (DropDownList)row.Cells[3].Controls[1].FindControl("ddlGridCompany");
            TextBox textWeight = (TextBox)row.Cells[4].Controls[0];
            DropDownList ddlGridUnitType = (DropDownList)row.Cells[5].Controls[1].FindControl("ddlGridUnitType");
            Core.Entity.Medicine medicine = new Core.Entity.Medicine();

            medicine.MedicineName = textMedicineName.Text;
            medicine.MedicineTypeId = Int32.Parse(ddlGridMedicineType.SelectedValue);
            medicine.CompanyId = Int32.Parse(ddlGridCompany.SelectedValue);
            medicine.Weight = Int32.Parse(textWeight.Text);
            medicine.UnitTypeId = Int32.Parse(ddlGridUnitType.SelectedValue);

            medicine.MedicineId = Convert.ToInt32(grvMedicine.DataKeys[e.RowIndex].Value);   
            medicineManager.Update(medicine);

            grvMedicine.EditIndex = -1;
            BindMedicineGrid();         
        }

        protected void grvMedicine_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grvMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvMedicine_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                if(grvMedicine.EditIndex == e.Row.RowIndex)
                {
                    DropDownList ddlGridMedicineType = (DropDownList)e.Row.FindControl("ddlGridMedicineType");
                    DropDownList ddlGridCompany = (DropDownList)e.Row.FindControl("ddlGridCompany");
                    DropDownList ddlGridUnitType = (DropDownList)e.Row.FindControl("ddlGridUnitType");


                    //LkpMedicineTypeManager lkpMedicineTypeManager = new LkpMedicineTypeManager();
                    //ddlMedicineType.DataSource = lkpMedicineTypeManager.GetAll();
                    //ddlMedicineType.DataBind();

                    //CompanyManager companyManager = new CompanyManager();
                    //ddlCompany.DataSource = companyManager.GetAll();
                    //ddlCompany.DataBind();

                    //LkpUnitTypeManager lkpUnitTypeManager = new LkpUnitTypeManager();
                    //ddlUnitType.DataSource = lkpUnitTypeManager.GetAll();
                    //ddlUnitType.DataBind();


                    BindMedicineTypeDropDown(ddlGridMedicineType);
                    BindCompanyDropDown(ddlGridCompany);
                    BindUnitTypeDropDown(ddlGridUnitType);


                    var medicineType = (e.Row.FindControl("lblMedicineType") as Label).Text;
                    var selectedItemMedicine = ddlGridMedicineType.Items.FindByValue(medicineType);
                    ddlGridMedicineType.ClearSelection();
                    selectedItemMedicine.Selected = true;

                    var companyName = (e.Row.FindControl("lblCompanyName") as Label).Text;
                    var selectedItemCompany = ddlGridCompany.Items.FindByValue(companyName);
                    ddlGridCompany.ClearSelection();
                    selectedItemCompany.Selected = true;

                    var unitType = (e.Row.FindControl("lblUnitType") as Label).Text;
                    var selectedItemUnitType = ddlGridUnitType.Items.FindByValue(unitType);
                    ddlGridUnitType.ClearSelection();
                    selectedItemUnitType.Selected = true;

                    //ddlUnitTypes.Items.FindByText((e.Row.FindControl("lblUnitType") as Label).Text).Selected = true;
                }
            }
        }
    }
}