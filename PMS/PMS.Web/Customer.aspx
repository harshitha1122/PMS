<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="PMS.Web.Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary panel-form">
        <div class="panel-heading">
            <h2 class="panel-title">Customer</h2>
        </div>
        <div class="panel-body form-horizontal">

            <asp:ValidationSummary runat="server" ID="valSummary"
                DisplayMode="BulletList"
                ShowMessageBox="false"
                ShowSummary="true"
                CssClass="alert alert-danger" ValidationGroup="saveValidationGroup" />

            <div class="row panel-rowmargin">

                    <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblFirstName" CssClass="control-label" runat="server" Text="FirstName"></asp:Label>
                        <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvFirstName" ValidationGroup="saveValidationGroup"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtFirstName"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter FirstName."></asp:RequiredFieldValidator>
                    </div>
                </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label ID="lblLastName" CssClass="control-label" runat="server" Text="Last Name"></asp:Label>
                            <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label ID="lblMobileNumber" CssClass="control-label" runat="server" Text="MobileNumber"></asp:Label>
                            <asp:TextBox ID="txtMobileNumber" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
               
             <div class="row panel-rowmargin">
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label ID="lblEmailId" CssClass="control-label" runat="server" Text="EmailId"></asp:Label>
                           <asp:TextBox ID="txtEmailId" CssClass="form-control" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="rfvEmailId" ValidationGroup="saveValidationGroup"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtEmailId"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter EmailId."></asp:RequiredFieldValidator>

                        </div>

                    </div>

                    
                </div>

            <div class="row panel-rowmargin">
                <div class="col-md-12 pull-right">
                    <div class="form-group">
                        <asp:Button ID="btnSaveCustomer"  OnClick="btnSave_Click" CssClass="btn btn-primary" ValidationGroup="saveValidationGroup" runat="server" Text="Save" />
                    </div>
                </div>
            </div>


            <div class="container">
                <asp:GridView CssClass="table table-hover" ID="grvCustomer" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerId"
                    AllowPaging="True" AllowSorting="True"
                    OnRowCancelingEdit="grvCustomer_RowCancelingEdit"
                    OnRowDeleting="grvCustomer_RowDeleting"
                    OnRowEditing="grvCustomer_RowEditing"
                    OnPageIndexChanging="grvCustomer_PageIndexChanging"
                    OnSelectedIndexChanging="grvCustomer_SelectedIndexChanging"
                    OnRowUpdating="grvCustomer_RowUpdating" PageSize="5">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" SortExpression="MobileNumber" />
                        <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />
                       


                        <asp:CommandField ShowEditButton="true" />
                        <asp:CommandField ShowDeleteButton="true" />
                    </Columns>
                    <EmptyDataTemplate>
                        There is no record to display.
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
