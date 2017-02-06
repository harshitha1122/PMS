<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="PMS.Web.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     

    <div class="panel panel-primary panel-form">
        <div class="panel-heading">
            <h2 class="panel-title">UserDetails</h2>
        </div>
        <div class="panel-body form-horizontal">

            <asp:ValidationSummary runat="server" ID="valSummary"
                DisplayMode="BulletList"
                ShowMessageBox="false"
                ShowSummary="true"
                CssClass="alert alert-danger" ValidationGroup="saveFirstName" />


            <div class="row panel-rowmargin">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblFirstName" CssClass="control-label" runat="server" Text="FirstName"></asp:Label>
                        <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvUserDetails" ValidationGroup="saveFirstName"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtFirstName"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter First Name."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="Lastname" CssClass="control-label" runat="server" Text="LastName"></asp:Label>
                        <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="DateOfJoining" CssClass="control-label" runat="server" Text="DateOfJoining"></asp:Label>
                        <asp:TextBox ID="txtDateOfJoining" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvDateOfJoining" ValidationGroup="saveFirstName"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtDateOfJoining"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter DateOfJoining."></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="row panel-rowmargin">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="MobileNumber" CssClass="control-label" runat="server" Text="MobileNumber"></asp:Label>
                        <asp:TextBox ID="txtMobileNumber" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvMobileNumber" ValidationGroup="saveFirstName"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtMobileNumber"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter Mobile Number."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="EmailId" CssClass="control-label" runat="server" Text="EmailId"></asp:Label>
                        <asp:TextBox ID="txtEmailId" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblUserId" CssClass="control-label" runat="server" Text="User Name"></asp:Label>
                        <asp:DropDownList ID="ddlUsers" DataTextField="UserName" DataValueField="UserId" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvUserId" ValidationGroup="saveFirstName"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="ddlUsers"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please select User Name."></asp:RequiredFieldValidator>
                    </div>
                </div>

            </div>
            <div class="row panel-rowmargin">
                <div class="col-md-12 pull-right">
                    <div class="form-group">
                        <asp:Button ID="btnSaveUserDetails" OnClick="btnSave_Click" CssClass="btn btn-primary" ValidationGroup="saveFirstName" runat="server" Text="Save" />
                    </div>
                </div>
            </div>


            <div class="container">
                <asp:GridView CssClass="table table-hover" ID="grvUserDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="UserDetailId"
                    AllowPaging="True" AllowSorting="True"
                    OnRowDataBound="grvUserDetails_RowDataBound"
                    OnRowCancelingEdit="grvUserDetails_RowCancelingEdit"
                    OnRowDeleting="grvUserDetails_RowDeleting"
                    OnRowEditing="grvUserDetails_RowEditing"
                    OnPageIndexChanging="grvUserDetails_PageIndexChanging"
                    OnSelectedIndexChanging="grvUserDetails_SelectedIndexChanging"
                    OnRowUpdating="grvUserDetails_RowUpdating" PageSize="5"
                    OnSelectedIndexChanged="grvUserDetails_SelectedIndexChanged" 
                    style="margin-right: 0px" Width="1074px">
                    <Columns>
                       
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                        <asp:BoundField DataField="DateOfJoining" HeaderText="DateOfJoining" SortExpression="LastName" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" SortExpression="MobileNumber" />
                        <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />


                       <asp:TemplateField HeaderText="UserName">
                            <ItemTemplate>
                                <asp:Label ID="lblUserNameReadOnly" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblUserName" runat="server" Visible="false" Text='<%# Eval("UserId") %>'></asp:Label>
                                <asp:DropDownList runat="server" DataTextField="UserName" DataValueField="UserId" ID="ddlGridUserName"></asp:DropDownList>
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
