using PMS.BAL.Manager;
using PMS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class MedicineType : System.Web.UI.Page
    {
        LkpMedicineTypeManager lkpMedicineTypeManager = new LkpMedicineTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindLkpMedicineTypeGrid();
        }

        private void BindLkpMedicineTypeGrid()
        {
            grvMedicineType.DataSource = lkpMedicineTypeManager.GetAll();
            grvMedicineType.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            LkpMedicineType lkpMedicineType = new LkpMedicineType();
            lkpMedicineType.MedicineType = txtMedicineType.Text;
            lkpMedicineType.MedicineTypeDesc = txtMedicineTypeDesc.Text;
            lkpMedicineTypeManager.Add(lkpMedicineType);
            BindLkpMedicineTypeGrid();
            ResetControls();
        }
        private void ResetControls()
        { 
         txtMedicineType.Text= String.Empty;
         txtMedicineTypeDesc.Text = String.Empty;
        }

        protected void grvMedicineType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvMedicineType.EditIndex = -1;
            BindLkpMedicineTypeGrid();
        }

        protected void grvMedicineType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int medicineTypeId = Convert.ToInt32(grvMedicineType.DataKeys[e.RowIndex].Value.ToString());
            lkpMedicineTypeManager.Delete(medicineTypeId);
            BindLkpMedicineTypeGrid();
        }

        protected void grvMedicineType_RowEditing(object sender, GridViewEditEventArgs e)
        {
             grvMedicineType.EditIndex = e.NewEditIndex;
             BindLkpMedicineTypeGrid();
        }

        protected void grvMedicineType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMedicineType.PageIndex = e.NewPageIndex;
            BindLkpMedicineTypeGrid();
        }

        protected void grvMedicineType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int medicineTypeId = Convert.ToInt32(grvMedicineType.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvMedicineType.Rows[e.RowIndex];

            TextBox textMedicineType = (TextBox)row.Cells[1].Controls[0];
            TextBox textMedicineTypeDesc = (TextBox)row.Cells[2].Controls[0];

            LkpMedicineType lkpMedicineType = new LkpMedicineType();
            lkpMedicineType.Id = medicineTypeId;
            lkpMedicineType.MedicineType = textMedicineType.Text;
            lkpMedicineType.MedicineTypeDesc = textMedicineTypeDesc.Text;

            lkpMedicineTypeManager.Update(lkpMedicineType);

            grvMedicineType.EditIndex = -1;
            BindLkpMedicineTypeGrid();
        }

        protected void grvMedicineType_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}