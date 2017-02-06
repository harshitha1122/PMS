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
    public partial class UserDetails : System.Web.UI.Page
    {
        UserDetailsManager userDetailsManager = new UserDetailsManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserDetailsGrid();
                BindUsersDropDown();
            }
        }
        private void BindUsersDropDown()
        {
            UsersManager usersManager = new UsersManager();
            ddlUsers.DataSource = usersManager.GetAll();
            ddlUsers.DataBind();
            ddlUsers.Items.Insert(0, new ListItem("--Select--"));
        }


        private void BindUserDetailsGrid()
        {
            grvUserDetails.DataSource = userDetailsManager.GetAll();
            grvUserDetails.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Core.Entity.UserDetails userDetails = new Core.Entity.UserDetails();
            userDetails.FirstName = txtFirstName.Text;
            userDetails.LastName = txtLastName.Text;
            userDetails.DateOfJoining = Convert.ToDateTime(txtDateOfJoining.Text);
            userDetails.MobileNumber = txtMobileNumber.Text;
            userDetails.UserName = txtEmailId.Text;
            userDetails.UserId = Convert.ToInt32(ddlUsers.SelectedValue);
            userDetailsManager.Add(userDetails);
            BindUserDetailsGrid();
            ResetControls();
        }

        private void ResetControls()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtDateOfJoining.Text = String.Empty;
            txtMobileNumber.Text = String.Empty;
            txtEmailId.Text = String.Empty;
            ddlUsers.SelectedIndex = -1;

        }

        protected void grvUserDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvUserDetails.EditIndex = -1;
            BindUserDetailsGrid();
        }

        protected void grvUserDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int UserDetailId = Convert.ToInt32(grvUserDetails.DataKeys[e.RowIndex].Value.ToString());
            userDetailsManager.Delete(UserDetailId);
            BindUserDetailsGrid();
        }

        protected void grvUserDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvUserDetails.EditIndex = e.NewEditIndex;
            BindUserDetailsGrid();
        }

        protected void grvUserDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvUserDetails.PageIndex = e.NewPageIndex;
            BindUserDetailsGrid();
        }

        protected void grvUserDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userDetailId = Convert.ToInt32(grvUserDetails.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvUserDetails.Rows[e.RowIndex];

            TextBox textFirstName = (TextBox)row.Cells[0].Controls[0];
            TextBox textLastName = (TextBox)row.Cells[1].Controls[0];
            TextBox textDateOfJoining = (TextBox)row.Cells[2].Controls[0];
            TextBox textMobileNumber = (TextBox)row.Cells[3].Controls[0];
            TextBox textEmailId = (TextBox)row.Cells[4].Controls[0];
            DropDownList ddlGridUserName = (DropDownList)row.Cells[5].Controls[1].FindControl("ddlGridUserName");

            Core.Entity.UserDetails userDetails = new Core.Entity.UserDetails();
            userDetails.UserDetailId = userDetailId;
            userDetails.FirstName = textFirstName.Text;
            userDetails.LastName = textLastName.Text;
            userDetails.DateOfJoining = DateTime.Parse(textDateOfJoining.Text);
            userDetails.MobileNumber = textMobileNumber.Text;
            userDetails.EmailId = textEmailId.Text;
            userDetails.UserId = Int32.Parse(ddlGridUserName.SelectedValue);
           

            userDetailsManager.Update(userDetails);
            grvUserDetails.EditIndex = -1;
            BindUserDetailsGrid();
        }

        protected void grvUserDetails_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
        protected void grvUserDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvUserDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (grvUserDetails.EditIndex == e.Row.RowIndex)
                {
                    DropDownList ddlUsers = (DropDownList)e.Row.FindControl("ddlGridUserName");

                    UsersManager usersManager = new UsersManager();
                    ddlUsers.DataSource = usersManager.GetAll();
                    ddlUsers.DataBind();

                    var userName = (e.Row.FindControl("lblUserName") as Label).Text;
                    var selectedItem = ddlUsers.Items.FindByValue(userName);
                    selectedItem.Selected = true;

                    //ddlUnitTypes.Items.FindByText((e.Row.FindControl("lblUnitType") as Label).Text).Selected = true;
                }
            }
        }
    }
}