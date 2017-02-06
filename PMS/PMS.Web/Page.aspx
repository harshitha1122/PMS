<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Page.aspx.cs" Inherits="PMS.Web.Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-primary panel-form">
        <div class="panel-heading">
            <h2 class="panel-title">Pages</h2>
        </div>

         <asp:ValidationSummary runat="server" ID="valSummary"
                DisplayMode="BulletList"
                ShowMessageBox="false"
                ShowSummary="true"
                CssClass="alert alert-danger" ValidationGroup="savePage" />
        <div class="panel-body form-horizontal">
            <div class="row panel-rowmargin">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblPageName" CssClass="control-label" runat="server" Text="Page Name"></asp:Label>
                        <asp:TextBox ID="txtPageName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPage" ValidationGroup="savePage"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtPageName"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter page name."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblPageDesc" CssClass="control-label" runat="server" Text="Page Descrption"></asp:Label>
                        <asp:TextBox ID="txtPageDesc" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row panel-rowmargin">
                <div class="col-md-12 pull-right">
                    <div class="form-group">
                        <asp:Button ID="btnSavePage" OnClick="btnSave_Click" CssClass="btn btn-primary" ValidationGroup="savePage" runat="server" Text="Save" />
                    </div>
                </div>
            </div>


            <div class="container">
                <asp:GridView CssClass="table table-hover" ID="grvPage" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="PageId"
                    AllowPaging="True" AllowSorting="True"
                    OnRowCancelingEdit="grvPage_RowCancelingEdit"
                    OnRowDeleting="grvPage_RowDeleting"
                    OnRowEditing="grvPage_RowEditing"
                    OnPageIndexChanging="grvPage_PageIndexChanging"
                    OnSelectedIndexChanging="grvPage_SelectedIndexChanging"
                    OnRowUpdating="grvPage_RowUpdating" PageSize="5">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:BoundField DataField="PageName" HeaderText="Page" SortExpression="PageName" />
                        <asp:BoundField DataField="PageDescription" HeaderText="Page Description" SortExpression="PageDescription" />
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

