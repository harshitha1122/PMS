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
    public partial class Page : System.Web.UI.Page
    {
        PageManager pageManager = new PageManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindPageGrid();
        }

        private void BindPageGrid()
        {
            grvPage.DataSource = pageManager.GetAll();
            grvPage.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Core.Entity.Page page = new Core.Entity.Page();
            page.PageName = txtPageName.Text;
            page.PageDescription = txtPageDesc.Text;
            pageManager.Add(page);
            BindPageGrid();
            ResetControls();
        }
      
        private void ResetControls()
        {
            txtPageName.Text = String.Empty;
            txtPageDesc.Text = String.Empty;
        }

        protected void grvPage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvPage.EditIndex = -1;
            BindPageGrid();
        }

        protected void grvPage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int PageId = Convert.ToInt32(grvPage.DataKeys[e.RowIndex].Value.ToString());
            pageManager.Delete(pageId);
            BindPageGrid();
        }

        protected void grvPage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvPage.EditIndex = e.NewEditIndex;
            BindPageGrid();
        }

        protected void grvPage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPage.PageIndex = e.NewPageIndex;
            BindPageGrid();
        }

        protected void grvPage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int pageId = Convert.ToInt32(grvPage.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvPage.Rows[e.RowIndex];

            TextBox txtPageName = (TextBox)row.Cells[1].Controls[0];
            TextBox txtPageDesc = (TextBox)row.Cells[2].Controls[0];

            Core.Entity.Page Page = new Core.Entity.Page();
            Page.PageId = pageId;
            Page.PageName = txtPageName.Text;
            Page.PageDescription = txtPageDesc.Text;

            pageManager.Update(Page);

            grvPage.EditIndex = -1;
            BindPageGrid();
        }

        protected void grvPage_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        public int pageId { get; set; }
    }
}