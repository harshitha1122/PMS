<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="PMS.Web.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-primary panel-form">
        <div class="panel-heading">
            <h2 class="panel-title">Users</h2>
        </div>
        <div class="panel-body form-horizontal">
            <asp:ValidationSummary runat="server" ID="valSummary"
                DisplayMode="BulletList"
                ShowMessageBox="false"
                ShowSummary="true"
                CssClass="alert alert-danger" ValidationGroup="saveUserName" />
            <div class="row panel-rowmargin">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblUserName" CssClass="control-label" runat="server" Text="UserName"></asp:Label>
                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsers" ValidationGroup="saveUserName"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtUserName"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter User Name."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblPassword" CssClass="control-label" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" ValidationGroup="saveUserName"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtPassword"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter Password."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblIsActive" CssClass="control-label" runat="server" Text="IsActive"></asp:Label>
                        <asp:CheckBox ID="chkIsActive" CssClass="form-control" runat="server" />
                       
                    </div>
                </div>


            </div>
            <div class="row panel-rowmargin">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblRoleId" CssClass="control-label" runat="server" Text="Role Name"></asp:Label>
                        <asp:DropDownList ID="ddlRole" DataTextField="RoleName" DataValueField="RoleId" CssClass="form-control" runat="server"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="rfvRoleId" ValidationGroup="saveRoleName"
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
                        <asp:Button ID="btnSaveUsers" OnClick="btnSave_Click" CssClass="btn btn-primary" ValidationGroup="saveUserName" runat="server" Text="Save" />
                    </div>
                </div>
            </div>


            <div class="container">
                <asp:GridView CssClass="table table-hover" ID="grvUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="UserId"
                    AllowPaging="True" AllowSorting="True"
                    OnRowDataBound="grvUsers_RowDataBound"
                    OnRowCancelingEdit="grvUsers_RowCancelingEdit"
                    OnRowDeleting="grvUsers_RowDeleting"
                    OnRowEditing="grvUsers_RowEditing"
                    OnPageIndexChanging="grvUsers_PageIndexChanging"
                    OnSelectedIndexChanging="grvUsers_SelectedIndexChanging"
                    OnRowUpdating="grvUsers_RowUpdating" PageSize="5" OnSelectedIndexChanged="grvUsers_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />

                        <asp:TemplateField HeaderText="IsActive">
                            <ItemTemplate>
                                <asp:Label ID="lblIsActiveReadOnly" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                            </ItemTemplate>

                            <EditItemTemplate>
                                <asp:Label ID="lblIsActive" runat="server" Visible="false" Text='<%# Eval("IsActive") %>'></asp:Label>
                                <asp:CheckBox Checked='<%# Eval("IsActive") %>' runat="server" ID="chkGridIsActive"></asp:CheckBox>
                                
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="RoleName">
                            <ItemTemplate>
                                <asp:Label ID="lblRoleNameReadOnly" runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>

                            </ItemTemplate>

                            <EditItemTemplate>
                                <asp:Label ID="lblRoleName" runat="server" Visible="false" Text='<%# Eval("RoleId") %>'></asp:Label>
                                <asp:DropDownList runat="server" DataTextField="RoleName" DataValueField="RoleId" ID="ddlGridRoleName"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>


                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <EmptyDataTemplate>
                        There is no record to display.
                        
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
