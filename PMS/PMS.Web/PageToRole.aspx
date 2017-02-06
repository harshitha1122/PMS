<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageToRole.aspx.cs" Inherits="PMS.Web.PageToRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





    <div class="panel panel-primary panel-form">
        <div class="panel-heading">
            <h2 class="panel-title">Page To Role</h2>
        </div>
        <div class="panel-body form-horizontal">

            <asp:ValidationSummary runat="server" ID="valSummary"
                DisplayMode="BulletList"
                ShowMessageBox="false"
                ShowSummary="true"
                CssClass="alert alert-danger" ValidationGroup="savePageName" />

            <div class="row panel-rowmargin">
                <div class="col-md-6">
                    <div class="form-group">

                        <asp:Label ID="lblPageId" CssClass="control-label" runat="server" Text="Page Name"></asp:Label>
                        <asp:DropDownList ID="ddlPage" DataTextField="PageName" DataValueField="PageId" CssClass="form-control" runat="server"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="rfvPageId" ValidationGroup="savePageName"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="ddlPage"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please select page."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblRoleId" CssClass="control-label" runat="server" Text="Role Name"></asp:Label>
                        <asp:DropDownList ID="ddlRole" DataTextField="RoleName" DataValueField="RoleId" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvRoleId" ValidationGroup="savePageName"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="ddlRole"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please select role."></asp:RequiredFieldValidator>
                    </div>
                </div>


            </div>
            <div class="row panel-rowmargin">
                <div class="col-md-12 pull-right">
                    <div class="form-group">
                        <asp:Button ID="btnSavePageToRole" OnClick="btnSave_Click" CssClass="btn btn-primary" ValidationGroup="savePageName" runat="server" Text="Save" />
                    </div>
                </div>
            </div>


            <div class="container">
                <asp:GridView CssClass="table table-hover" ID="grvPageToRole" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="PageToRoleId"
                    AllowPaging="True" AllowSorting="True"
                    OnRowDataBound="grvPageToRole_RowDataBound"
                    OnRowCancelingEdit="grvPageToRole_RowCancelingEdit"
                    OnRowDeleting="grvPageToRole_RowDeleting"
                    OnRowEditing="grvPageToRole_RowEditing"
                    OnPageIndexChanging="grvPageToRole_PageIndexChanging"
                    OnSelectedIndexChanging="grvPageToRole_SelectedIndexChanging"
                    OnRowUpdating="grvPageToRole_RowUpdating" PageSize="5" OnSelectedIndexChanged="grvPageToRole_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="Page Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPageNameReadOnly" runat="server" Text='<%# Eval("PageName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblPageName" runat="server" Visible="false" Text='<%# Eval("PageId") %>'></asp:Label>
                                <asp:DropDownList runat="server" DataTextField="PageName" DataValueField="PageId" ID="ddlGridPage"></asp:DropDownList>
                            </EditItemTemplate>

                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Role Name">
                            <ItemTemplate>
                                <asp:Label ID="lblRoleNameReadOnly" runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblRoleName" runat="server" Visible="false" Text='<%# Eval("RoleId") %>'></asp:Label>
                                <asp:DropDownList runat="server" DataTextField="RoleName" DataValueField="RoleId" ID="ddlGridRole"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                       
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
