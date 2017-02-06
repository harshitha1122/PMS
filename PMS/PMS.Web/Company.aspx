<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="PMS.Web.Company" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel panel-primary panel-form">
        <div class="panel-heading">
            <h2 class="panel-title">Company</h2>
        </div>
        <div class="panel-body form-horizontal">
            <div class="row panel-rowmargin">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblCompanyName" CssClass="control-label" runat="server" Text="Company Name"></asp:Label>
                        <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCompanyName" ValidationGroup="saveCompany"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtCompanyName"
                            Display="Dynamic"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter company name."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblPhoneNumber" CssClass="control-label" runat="server" Text="Phone Number"></asp:Label>
                        <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblAddress" CssClass="control-label" runat="server" Text="Address"></asp:Label>
                        <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row panel-rowmargin">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblWebsite" CssClass="control-label" runat="server" Text="Website"></asp:Label>
                        <asp:TextBox ID="txtWebsite" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvWebsite" ValidationGroup="saveWebsite"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtWebsite"
                            Display="Dynamic"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter website."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblCompanyReg" CssClass="control-label" runat="server" Text="Company Registration"></asp:Label>
                        <asp:TextBox ID="txtCompanyReg" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row panel-rowmargin">
                <div class="col-md-12 pull-right">
                    <div class="form-group">
                        <asp:Button ID="btnSaveCompany" OnClick="btnSave_Click" CssClass="btn btn-primary" ValidationGroup="saveCompany" runat="server" Text="Save" />
                    </div>
                </div>
            </div>


            <div class="container">
                <asp:GridView CssClass="table table-hover" ID="grvCompany" runat="server" AutoGenerateColumns="False" DataKeyNames="CompanyId"
                    AllowPaging="True" AllowSorting="True"
                    OnRowCancelingEdit="grvCompany_RowCancelingEdit"
                    OnRowDeleting="grvCompany_RowDeleting"
                    OnRowEditing="grvCompany_RowEditing"
                    OnPageIndexChanging="grvCompany_PageIndexChanging"
                    OnSelectedIndexChanging="grvCompany_SelectedIndexChanging"
                    OnRowUpdating="grvCompany_RowUpdating" PageSize="5">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName" />
                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                        <asp:BoundField DataField="Website" HeaderText="Website" SortExpression="Website" />
                        <asp:BoundField DataField="CompanyReg" HeaderText="Company Registration" SortExpression="CompanyReg" />
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
