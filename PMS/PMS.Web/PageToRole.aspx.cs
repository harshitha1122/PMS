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
    public partial class PageToRole : System.Web.UI.Page
    {
        PageToRoleManager pageToRoleManager = new PageToRoleManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPageToRoleGrid();
                BindPageDropDown(ddlPage);
                BindRoleDropDown(ddlRole);
            }
        }

        private void BindRoleDropDown(DropDownList ddl)
        {
            RolesManager rolesManager = new RolesManager();
            ddl.DataSource = rolesManager.GetAll();
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--"));
        }

        private void BindPageDropDown(DropDownList ddl)
        {
            PageManager pageManager = new PageManager();
            ddl.DataSource = pageManager.GetAll();
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--"));
        }

        private void BindPageToRoleGrid()
        {
            grvPageToRole.DataSource = pageToRoleManager.GetAll();
            grvPageToRole.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
                Core.Entity.PageToRole pageToRole = new Core.Entity.PageToRole();
                pageToRole.PageId = Convert.ToInt32(ddlPage.SelectedValue);
                pageToRole.RoleId = Convert.ToInt32(ddlRole.SelectedValue);
                pageToRoleManager.Add(pageToRole);
                BindPageToRoleGrid();
                ResetControls();
            
        }
        private void ResetControls()
        {
            ddlPage.SelectedIndex = -1;
            ddlRole.SelectedIndex = -1;

        }
        protected void grvPageToRole_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvPageToRole.EditIndex = -1;
            BindPageToRoleGrid();
        }

        protected void grvPageToRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int PageToRoleId = Convert.ToInt32(grvPageToRole.DataKeys[e.RowIndex].Value.ToString());
            pageToRoleManager.Delete(PageToRoleId);
            BindPageToRoleGrid();
        }

        protected void grvPageToRole_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvPageToRole.EditIndex = e.NewEditIndex;
            BindPageToRoleGrid();
        }

        protected void grvPageToRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPageToRole.PageIndex = e.NewPageIndex;
            BindPageToRoleGrid();
        }

        protected void grvPageToRole_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int pageToRoleId = Convert.ToInt32(grvPageToRole.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvPageToRole.Rows[e.RowIndex];

            DropDownList ddlPageGrid = (DropDownList)row.Cells[0].Controls[1].FindControl("ddlGridPage");
            DropDownList ddlGridRole = (DropDownList)row.Cells[1].Controls[1].FindControl("ddlGridRole");

            Core.Entity.PageToRole pageToRole = new Core.Entity.PageToRole();
            pageToRole.PageId = Int32.Parse(ddlPageGrid.SelectedValue);
            pageToRole.RoleId = Int32.Parse(ddlGridRole.SelectedValue);

            pageToRole.PageToRoleId = Convert.ToInt32(grvPageToRole.DataKeys[e.RowIndex].Value);
            pageToRoleManager.Update(pageToRole);

            grvPageToRole.EditIndex = -1;

            BindPageToRoleGrid();
        }

        protected void grvPageToRole_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grvPageToRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void grvPageToRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (grvPageToRole.EditIndex == e.Row.RowIndex)
                {
                    DropDownList ddlGridPage = (DropDownList)e.Row.FindControl("ddlGridPage");
                    DropDownList ddlGridRole = (DropDownList)e.Row.FindControl("ddlGridRole");

                    //PageManager pageManager = new PageManager();
                    //ddlPage.DataSource = pageManager.GetAll();
                    //ddlPage.DataBind();

                    BindPageDropDown(ddlGridPage);
                    BindRoleDropDown(ddlGridRole);


                    var roleName = (e.Row.FindControl("lblRoleName") as Label).Text;
                    var selectedItemRole = ddlGridRole.Items.FindByValue(roleName);
                    ddlGridRole.ClearSelection();
                    selectedItemRole.Selected = true;

                    var pageName = (e.Row.FindControl("lblPageName") as Label).Text;
                    var selectedItem = ddlGridPage.Items.FindByValue(pageName);
                    ddlGridPage.ClearSelection();
                    selectedItem.Selected = true;

                }
            }
        }

    }
}