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
    public partial class UnitType : System.Web.UI.Page
    {
        LkpUnitTypeManager lkpUnitTypeManager = new LkpUnitTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindLkpUnitTypeGrid();
        }

        private void BindLkpUnitTypeGrid()
        {
            grvUnitType.DataSource = lkpUnitTypeManager.GetAll();
            grvUnitType.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            LkpUnitType lkpUnitType = new LkpUnitType();
            lkpUnitType.UnitType = txtUnitType.Text;
            lkpUnitType.UnitTypeDesc = txtUnitTypeDesc.Text;
            lkpUnitTypeManager.Add(lkpUnitType);
            BindLkpUnitTypeGrid();
            ResetControls();
        }

        private void ResetControls()
        {
            txtUnitType.Text = String.Empty;
            txtUnitTypeDesc.Text = String.Empty;
        }

        protected void grvUnitType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvUnitType.EditIndex = -1;
            BindLkpUnitTypeGrid();
        }

        protected void grvUnitType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int UnitTypeId = Convert.ToInt32(grvUnitType.DataKeys[e.RowIndex].Value.ToString());
            lkpUnitTypeManager.Delete(UnitTypeId);
            BindLkpUnitTypeGrid();
        }

        protected void grvUnitType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvUnitType.EditIndex = e.NewEditIndex;
            BindLkpUnitTypeGrid();
        }

        protected void grvUnitType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvUnitType.PageIndex = e.NewPageIndex;
            BindLkpUnitTypeGrid();
        }

        protected void grvUnitType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int UnitTypeId = Convert.ToInt32(grvUnitType.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvUnitType.Rows[e.RowIndex];

            TextBox textUnitType = (TextBox)row.Cells[1].Controls[0];
            TextBox textUnitTypeDesc = (TextBox)row.Cells[2].Controls[0];

            LkpUnitType lkpUnitType = new LkpUnitType();
            lkpUnitType.Id = UnitTypeId;
            lkpUnitType.UnitType = textUnitType.Text;
            lkpUnitType.UnitTypeDesc = textUnitTypeDesc.Text;

            lkpUnitTypeManager.Update(lkpUnitType);

            grvUnitType.EditIndex = -1;
            BindLkpUnitTypeGrid();
        }

        protected void grvUnitType_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}