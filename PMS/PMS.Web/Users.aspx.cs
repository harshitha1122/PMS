using PMS.BAL.Manager;
using PMS.Core.Entity;
using PMS.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class Users : System.Web.UI.Page
    {
        UsersManager usersManager = new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUsersGrid();
                BindRoleDropDown(ddlRole);
                //BindIsActiveCheckBox(chkIsActive);

            }
        }

        private void BindIsActiveCheckBox(CheckBox chk)
        {
            UsersManager usersManager = new UsersManager();
            
            chkIsActive.DataBind();
           

        }


        private void BindRoleDropDown(DropDownList ddl)
        {
            RolesManager rolesManager = new RolesManager();
            ddl.DataSource = rolesManager.GetAll();
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--"));
        }
        private void BindUsersGrid()
        {
            grvUsers.DataSource = usersManager.GetAll();
            grvUsers.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Core.Entity.Users users = new Core.Entity.Users();
            users.UserName = txtUserName.Text;
            users.Password = txtPassword.Text;
            users.IsActive = chkIsActive.Checked;
            users.RoleId = Convert.ToInt32(ddlRole.SelectedValue);

            usersManager.Add(users);
            BindUsersGrid();
            ResetControls();
        }
    
        private void ResetControls()
        {
             txtUserName.Text= String.Empty;
             txtPassword.Text= String.Empty;
            chkIsActive.Checked=false;
            ddlRole.SelectedIndex = -1;
        }

        protected void grvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvUsers.EditIndex = -1;
            BindUsersGrid();
        }

        protected void grvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int UsersId = Convert.ToInt32(grvUsers.DataKeys[e.RowIndex].Value.ToString());
            usersManager.Delete(UsersId);
            BindUsersGrid();
        }

        protected void grvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvUsers.EditIndex = e.NewEditIndex;
            BindUsersGrid();
        }

        protected void grvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvUsers.PageIndex = e.NewPageIndex;
            BindUsersGrid();
        }

        protected void grvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int UsersId = Convert.ToInt32(grvUsers.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvUsers.Rows[e.RowIndex];

            TextBox txtUserName = (TextBox)row.Cells[0].Controls[0];
            TextBox txtPassword = (TextBox)row.Cells[1].Controls[0];
            CheckBox chkGridIsActive = (CheckBox)row.Cells[2].Controls[1].FindControl("chkGridIsActive");
            DropDownList ddlGridRoleName = (DropDownList)row.Cells[3].Controls[1].FindControl("ddlGridRoleName");

            Core.Entity.Users users = new Core.Entity.Users();
            users.UserId = UsersId;
            users.UserName = txtUserName.Text;
            users.Password = txtPassword.Text;
            users.IsActive = chkGridIsActive.Checked;
            users.RoleId = Int32.Parse(ddlGridRoleName.SelectedValue);         
            usersManager.Update(users);

            grvUsers.EditIndex = -1;
            BindUsersGrid();
        }

        protected void grvUsers_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (grvUsers.EditIndex == e.Row.RowIndex)
                {
                    DropDownList ddlRoleName = (DropDownList)e.Row.FindControl("ddlGridRoleName");


                    RolesManager rolesManager = new RolesManager();
                    ddlRoleName.DataSource = rolesManager.GetAll();
                    ddlRoleName.DataBind();

                    var roleName = (e.Row.FindControl("lblRoleName") as Label).Text;
                    var selectedItem = ddlRoleName.Items.FindByValue(roleName);
                    selectedItem.Selected = true;

                    //ddlUnitTypes.Items.FindByText((e.Row.FindControl("lblUnitType") as Label).Text).Selected = true;
                }
            }
        }


    }
}