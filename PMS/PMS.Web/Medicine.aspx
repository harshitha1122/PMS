<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicine.aspx.cs" Inherits="PMS.Web.Medicine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="panel panel-primary panel-form">
        <div class="panel-heading">
            <h2 class="panel-title">Medicine</h2>
        </div>
        <div class="panel-body form-horizontal">

            <asp:ValidationSummary runat="server" ID="valSummary"
                DisplayMode="BulletList"
                ShowMessageBox="false"
                ShowSummary="true"
                CssClass="alert alert-danger" ValidationGroup="saveMedicineName" />

            <div class="row panel-rowmargin">

                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblMedicineName" CssClass="control-label" runat="server" Text="MedicineName"></asp:Label>
                        <asp:TextBox ID="textMedicineName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Label ID="lblError" CssClass="alert-text" runat="server"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfvMedicineName" ValidationGroup="saveMedicineName"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="textMedicineName"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter MedicineName."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblMedicineTypeId" CssClass="control-label" runat="server" Text="Medicine Type"></asp:Label>
                        <asp:DropDownList ID="ddlMedicineType" DataTextField="MedicineType" DataValueField="Id" CssClass="form-control" runat="server" />
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblCompanyId" CssClass="control-label" runat="server" Text="Company Name"></asp:Label>
                        <asp:DropDownList ID="ddlCompany" DataTextField="CompanyName" DataValueField="CompanyId" CssClass="form-control" runat="server" />
                    </div>
                </div>
            </div>

            <div class="row panel-rowmargin">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="Weight" CssClass="control-label" runat="server" Text="Weight"></asp:Label>
                        <asp:TextBox ID="textWeight" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvWeight" ValidationGroup="saveMedicineName"
                            runat="server"
                            CssClass="alert-text"
                            ControlToValidate="textWeight"
                            Display="None"
                            SetFocusOnError="true"
                            ErrorMessage="Please enter Weight."></asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblUnitTypeId" CssClass="control-label" runat="server" Text="Unit Type"></asp:Label>
                        <asp:DropDownList ID="ddlUnitType" DataTextField="UnitType" DataValueField="Id" CssClass="form-control" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row panel-rowmargin">
                <div class="col-md-12 pull-right">
                    <div class="form-group">
                        <asp:Button ID="btnSaveMedicine" OnClick="btnSave_Click" ValidationGroup="saveMedicineName" CssClass="btn btn-primary" runat="server" Text="Save" />
                    </div>
                </div>
            </div>


            <div class="container">
                <asp:GridView CssClass="table table-hover" ID="grvMedicine" runat="server"
                    AutoGenerateColumns="False" DataKeyNames="MedicineId"
                    AllowPaging="True" AllowSorting="True"
                    OnRowDataBound="grvMedicine_RowDataBound"
                    OnRowCancelingEdit="grvMedicine_RowCancelingEdit"
                    OnRowDeleting="grvMedicine_RowDeleting"
                    OnRowEditing="grvMedicine_RowEditing"
                    OnPageIndexChanging="grvMedicine_PageIndexChanging"
                    OnSelectedIndexChanging="grvMedicine_SelectedIndexChanging"
                    OnRowUpdating="grvMedicine_RowUpdating" PageSize="5"
                    OnSelectedIndexChanged="grvMedicine_SelectedIndexChanged"
                    Style="margin-right: 0px" Width="1074px">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:BoundField DataField="MedicineName" HeaderText="MedicineName" SortExpression="MedicineName" />
                        <asp:TemplateField HeaderText="Medicine Type">
                            <ItemTemplate>
                                <asp:Label ID="lblMedicineTypeReadOnly" runat="server" Text='<%# Eval("MedicineType") %>'></asp:Label>

                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblMedicineType" runat="server" Visible="false" Text='<%# Eval("MedicineTypeId") %>'></asp:Label>
                                <asp:DropDownList runat="server" DataTextField="MedicineType" DataValueField="Id" ID="ddlGridMedicineType"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Company">
                            <ItemTemplate>
                                <asp:Label ID="lblCompanyNameReadOnly" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>

                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblCompanyName" runat="server" Visible="false" Text='<%# Eval("CompanyId") %>'></asp:Label>
                                <asp:DropDownList runat="server" DataTextField="CompanyName" DataValueField="CompanyId" ID="ddlGridCompany"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="Weight" />

                        <asp:TemplateField HeaderText="Unit Type">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitTypeReadOnly" runat="server" Text='<%# Eval("UnitType") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblUnitType" runat="server" Visible="false" Text='<%# Eval("UnitTypeId") %>'></asp:Label>
                                <asp:DropDownList runat="server" DataTextField="UnitType" DataValueField="Id" ID="ddlGridUnitType"></asp:DropDownList>
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
