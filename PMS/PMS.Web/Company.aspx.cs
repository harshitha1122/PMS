using PMS.BAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class Company : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindCompanyGrid();
        }

        private void BindCompanyGrid()
        {
            grvCompany.DataSource = companyManager.GetAll();
            grvCompany.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Core.Entity.Company Company = new Core.Entity.Company();
            Company.Address = txtAddress.Text;
            Company.CompanyName = txtCompanyName.Text;
            Company.CompanyReg = txtCompanyReg.Text;
            companyManager.Add(Company);
            BindCompanyGrid();
        }

        protected void grvCompany_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvCompany.EditIndex = -1;
            BindCompanyGrid();
        }

        protected void grvCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int UnitTypeId = Convert.ToInt32(grvCompany.DataKeys[e.RowIndex].Value.ToString());
            //companyManager.Delete(UnitTypeId);
            BindCompanyGrid();
        }

        protected void grvCompany_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvCompany.EditIndex = e.NewEditIndex;
            BindCompanyGrid();
        }

        protected void grvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCompany.PageIndex = e.NewPageIndex;
            BindCompanyGrid();
        }

        protected void grvCompany_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int UnitTypeId = Convert.ToInt32(grvCompany.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvCompany.Rows[e.RowIndex];

            TextBox txtCompanyName = (TextBox)row.Cells[1].Controls[0];
            TextBox txtAddress = (TextBox)row.Cells[2].Controls[0];

            Core.Entity.Company Company = new Core.Entity.Company();
            //Company.Id = UnitTypeId;
            //Company.UnitType = textUnitType.Text;
            //Company.UnitTypeDesc = textUnitTypeDesc.Text;

            //companyManager.Update(Company);

            grvCompany.EditIndex = -1;
            BindCompanyGrid();
        }

        protected void grvCompany_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}