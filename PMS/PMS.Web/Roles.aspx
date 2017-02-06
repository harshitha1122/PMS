<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="PMS.Web.Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default panel-form">
        <div class="panel-heading">
            <h2 class="panel-title">Roles</h2>
        </div>
        <div class="panel-body form-horizontal">
            <asp:ValidationSummary runat="server" ID="valSummary"
                DisplayMode="BulletList"
                ShowMessageBox="false"
                ShowSummary="true"
                CssClass="alert alert-danger" ValidationGroup="saveRoleName" />
            <div class="row panel-rowmargin">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblRoleName" CssClass="control-label" runat="server" Text="Role Name"></asp:Label>
                        <asp:TextBox ID="txtRoleName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvRoles" ValidationGroup="saveRoleName"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtRoleName"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter Role Name."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                    </div>
                </div>

            </div>
            <div class="row panel-rowmargin">
                <div class="col-md-12 pull-right">
                    <div class="form-group">
                        <asp:Button ID="btnSaveRoles" OnClick="btnSave_Click" CssClass="btn btn-primary" ValidationGroup="saveRoleName" runat="server" Text="Save" />
                    </div>
                </div>
            </div>


            <div class="container">
                <asp:GridView CssClass="table table-hover" ID="grvRoles" runat="server"
                    AutoGenerateColumns="False" DataKeyNames="RoleId"
                    AllowPaging="True" AllowSorting="True"
                    OnRowCancelingEdit="grvRoles_RowCancelingEdit"
                    OnRowDeleting="grvRoles_RowDeleting"
                    OnRowEditing="grvRoles_RowEditing"
                    OnPageIndexChanging="grvRoles_PageIndexChanging"
                    OnSelectedIndexChanging="grvRoles_SelectedIndexChanging"
                    OnRowUpdating="grvRoles_RowUpdating" PageSize="5">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:BoundField DataField="RoleName" HeaderText="Roles" SortExpression="RoleName" />
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
