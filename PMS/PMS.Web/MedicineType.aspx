<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicineType.aspx.cs" Inherits="PMS.Web.MedicineType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-primary panel-form">
        <div class="panel-heading">
            <h2 class="panel-title">Medicine Type</h2>
        </div>

           <asp:ValidationSummary runat="server" ID="valSummary"
                DisplayMode="BulletList"
                ShowMessageBox="false"
                ShowSummary="true"
                CssClass="alert alert-danger" ValidationGroup="saveMedicineType" />
        <div class="panel-body form-horizontal">
            <div class="row panel-rowmargin">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblMedicineType" CssClass="control-label" runat="server" Text="Medicine Type"></asp:Label>
                        <asp:TextBox ID="txtMedicineType" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMedicineType" ValidationGroup="saveMedicineType"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="txtMedicineType"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter MedicineType."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblMedicineTypeDesc" CssClass="control-label" runat="server" Text="Medicine Type Descrption"></asp:Label>
                        <asp:TextBox ID="txtMedicineTypeDesc" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row panel-rowmargin">
                <div class="col-md-12 pull-right">
                    <div class="form-group">
                        <asp:Button ID="btnSaveMedicineType" OnClick="btnSave_Click" CssClass="btn btn-primary" ValidationGroup="saveMedicineType" runat="server" Text="Save" />
                    </div>
                </div>
            </div>


            <div class="container">
                <asp:GridView CssClass="table table-hover" ID="grvMedicineType" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                    AllowPaging="True" AllowSorting="True"
                    OnRowCancelingEdit="grvMedicineType_RowCancelingEdit"
                    OnRowDeleting="grvMedicineType_RowDeleting"
                    OnRowEditing="grvMedicineType_RowEditing"
                    OnPageIndexChanging="grvMedicineType_PageIndexChanging"
                    OnSelectedIndexChanging="grvMedicineType_SelectedIndexChanging"
                    OnRowUpdating="grvMedicineType_RowUpdating" PageSize="5">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:BoundField DataField="MedicineType" HeaderText="MedicineType" SortExpression="MedicineType" />
                        <asp:BoundField DataField="MedicineTypeDesc" HeaderText="MedicineTypeDesc" SortExpression="MedicineTypeDesc" />
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
