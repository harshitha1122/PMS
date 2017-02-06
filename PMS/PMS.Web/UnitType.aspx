<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnitType.aspx.cs" Inherits="PMS.Web.UnitType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="panel panel-primary panel-form">
        <div class="panel-heading">
            <h2 class="panel-title">Medicine Type</h2>
        </div>

          <asp:ValidationSummary runat="server" ID="valSummary"
                DisplayMode="BulletList"
                ShowMessageBox="false"
                ShowSummary="true"
                CssClass="alert alert-danger" ValidationGroup="saveUnitType" />
        <div class="panel-body form-horizontal">
            <div class="row panel-rowmargin">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblUnitType" CssClass="control-label" runat="server" Text="Unit Type"></asp:Label>
                        <asp:TextBox ID="txtUnitType" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUnitType" ValidationGroup="saveUnitType"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtUnitType"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter UnitType."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblUnitTypeDesc" CssClass="control-label" runat="server" Text="Unit Type Descrption"></asp:Label>
                        <asp:TextBox ID="txtUnitTypeDesc" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row panel-rowmargin">
                <div class="col-md-12 pull-right">
                    <div class="form-group">
                        <asp:Button ID="btnSaveUnitType" OnClick="btnSave_Click" CssClass="btn btn-primary" ValidationGroup="saveUnitType" runat="server" Text="Save" />
                    </div>
                </div>
            </div>


            <div class="container">
                <asp:GridView CssClass="table table-hover" ID="grvUnitType" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                    AllowPaging="True" AllowSorting="True"
                    OnRowCancelingEdit="grvUnitType_RowCancelingEdit"
                    OnRowDeleting="grvUnitType_RowDeleting"
                    OnRowEditing="grvUnitType_RowEditing"
                    OnPageIndexChanging="grvUnitType_PageIndexChanging"
                    OnSelectedIndexChanging="grvUnitType_SelectedIndexChanging"
                    OnRowUpdating="grvUnitType_RowUpdating" PageSize="5">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:BoundField DataField="UnitType" HeaderText="UnitType" SortExpression="UnitType" />
                        <asp:BoundField DataField="UnitTypeDesc" HeaderText="UnitTypeDesc" SortExpression="UnitTypeDesc" />
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
