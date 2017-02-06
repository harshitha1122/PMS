using PMS.BAL.Manager;
using PMS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class Roles : System.Web.UI.Page
    {
        RolesManager rolesManager = new RolesManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindRolesGrid();
        }

        private void BindRolesGrid()
        {
            grvRoles.DataSource = rolesManager.GetAll();
            grvRoles.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Core.Entity.Roles roles = new Core.Entity.Roles();
            roles.RoleName = txtRoleName.Text;
            rolesManager.Add(roles);
            BindRolesGrid();
            ResetControls();
        }

        private void ResetControls()
        {
            txtRoleName.Text = String.Empty;
        }

        protected void grvRoles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvRoles.EditIndex = -1;
            BindRolesGrid();
        }

        protected void grvRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int RoleId = Convert.ToInt32(grvRoles.DataKeys[e.RowIndex].Value.ToString());
            rolesManager.Delete(RoleId);
            BindRolesGrid();
        }

        protected void grvRoles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvRoles.EditIndex = e.NewEditIndex;
            BindRolesGrid();
        }

        protected void grvRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvRoles.PageIndex = e.NewPageIndex;
            BindRolesGrid();
        }

        protected void grvRoles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int RoleId = Convert.ToInt32(grvRoles.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvRoles.Rows[e.RowIndex];
            TextBox textRoleName = (TextBox)row.Cells[1].Controls[0];
            Core.Entity.Roles roles = new Core.Entity.Roles();
            roles.RoleId = RoleId;
            roles.RoleName = textRoleName.Text;
            rolesManager.Update(roles);

            grvRoles.EditIndex = -1;
            BindRolesGrid();
        }

        protected void grvRoles_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}