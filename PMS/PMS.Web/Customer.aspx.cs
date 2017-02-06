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
    public partial class Customer : System.Web.UI.Page
    {
        CustomerManager customerManager = new CustomerManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindCustomerGrid();
        }

        private void  BindCustomerGrid()
        {
            grvCustomer.DataSource = customerManager.GetAll();
            grvCustomer.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Core.Entity.Customer customer = new Core.Entity.Customer();
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.MobileNumber = txtMobileNumber.Text;
            customer.EmailId = txtEmailId.Text;
            customerManager.Add(customer);
            BindCustomerGrid();
            ResetControls();
        }
        private void ResetControls()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtMobileNumber.Text = String.Empty;
            txtEmailId.Text = String.Empty;
        }

        protected void grvCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvCustomer.EditIndex = -1;
            BindCustomerGrid();
        }

        protected void grvCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int CustomerId = Convert.ToInt32(grvCustomer.DataKeys[e.RowIndex].Value.ToString());
            customerManager.Delete(CustomerId);
            BindCustomerGrid();
        }

        protected void grvCustomer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvCustomer.EditIndex = e.NewEditIndex;
            BindCustomerGrid();
        }

        protected void grvCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCustomer.PageIndex = e.NewPageIndex;
            BindCustomerGrid();
        }

        protected void grvCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int CustomerId = Convert.ToInt32(grvCustomer.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvCustomer.Rows[e.RowIndex];

            TextBox textFirstName = (TextBox)row.Cells[1].Controls[0];
            TextBox textLastName = (TextBox)row.Cells[2].Controls[0];
            TextBox textMobileNumber = (TextBox)row.Cells[3].Controls[0];
            TextBox textEmailId = (TextBox)row.Cells[4].Controls[0];


            Core.Entity.Customer customer = new Core.Entity.Customer();
            customer.CustomerId = CustomerId;
            customer.FirstName = textFirstName.Text;
            customer.LastName = textLastName.Text;
            customer.MobileNumber = textMobileNumber.Text;
            customer.EmailId = textEmailId.Text;


            customerManager.Update(customer);

            grvCustomer.EditIndex = -1;
            BindCustomerGrid();
        }

        protected void grvCustomer_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}