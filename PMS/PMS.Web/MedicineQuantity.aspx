<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicineQuantity.aspx.cs" Inherits="PMS.Web.MedicineQuantity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-primary panel-form">
        <div class="panel-heading">
            <h2 class="panel-title">MedicineQuantity</h2>
        </div>
        <div class="panel-body form-horizontal">

            <asp:ValidationSummary runat="server" ID="valSummary"
                DisplayMode="BulletList"
                ShowMessageBox="false"
                ShowSummary="true"
                CssClass="alert alert-danger" ValidationGroup="saveDateOfPurchase" />

            <div class="row panel-rowmargin">

                    <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="DateOfPurchase" CssClass="control-label" runat="server" Text=" DateOfPurchase"></asp:Label>
                        <asp:TextBox ID="txtDateOfPurchase" CssClass="form-control" runat="server"></asp:TextBox>
                        
                        <asp:requiredfieldvalidator id="rfvDateOfPurchase" validationgroup="saveDateOfPurchase"
                            runat="server"
                            cssclass="alert-text"
                            controltovalidate="txtDateOfPurchase"
                            display="none"
                            setfocusonerror="true"
                            errormessage="please enter DateOfPurchase."></asp:requiredfieldvalidator>
                    </div>
                </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label ID="ExpiryDate" CssClass="control-label" runat="server" Text="ExpiryDate"></asp:Label>
                            <asp:TextBox ID="txtExpiryDate" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label ID="ManfactureDate" CssClass="control-label" runat="server" Text="ManfactureDate"></asp:Label>
                            <asp:TextBox ID="txtManfactureDate" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
               
             <div class="row panel-rowmargin">
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label ID="lblPrice" CssClass="control-label" runat="server" Text="Price"></asp:Label>
                            <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label ID="MedQuantity" CssClass="control-label" runat="server" Text="MedQuantity"></asp:Label>
                            <asp:TextBox ID="txtMedQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                 <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label ID="lblMedicineId" CssClass="control-label" runat="server" Text="MedicineName"></asp:Label>
                            <asp:DropDownList ID="ddlMedicine" DataTextField="MedicineName" DataValueField="MedicineId" CssClass="form-control" runat="server" />
                        </div>
                    </div>


                </div>

            <div class="row panel-rowmargin">
                <div class="col-md-12 pull-right">
                    <div class="form-group">
                        <asp:Button ID="btnSaveMedicineQuantity" OnClick="btnSave_Click" validationgroup="saveDateOfPurchase" CssClass="btn btn-primary" runat="server" Text="Save" />
                    </div>
                </div>
            </div>


            <div class="container">
                <asp:GridView CssClass="table table-hover" ID="grvMedicineQuantity" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="QuantityId"
                    AllowPaging="True" AllowSorting="True"
                    OnRowDataBound="grvMedicineQuantity_RowDataBound"
                    OnRowCancelingEdit="grvMedicineQuantity_RowCancelingEdit"
                    OnRowDeleting="grvMedicineQuantity_RowDeleting"
                    OnRowEditing="grvMedicineQuantity_RowEditing"
                    OnPageIndexChanging="grvMedicineQuantity_PageIndexChanging"
                    OnSelectedIndexChanging="grvMedicineQuantity_SelectedIndexChanging"
                    OnRowUpdating="grvMedicineQuantity_RowUpdating" PageSize="5" 
                    OnSelectedIndexChanged="grvMedicineQuantity_SelectedIndexChanged" 
                    style="margin-right: 0px" Width="1074px">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:BoundField DataField="DateOfPurchase" HeaderText=" DateOfPurchase" SortExpression="DateOfPurchase" />
                        <asp:BoundField DataField="ExpiryDate" HeaderText="ExpiryDate" SortExpression="ExpiryDate" />
                        <asp:BoundField DataField="ManfactureDate" HeaderText="ManfactureDate" SortExpression="ManfactureDate" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:BoundField DataField="MedQuantity" HeaderText="MedQuantity" SortExpression="MedQuantity" />

                        <asp:TemplateField HeaderText="MedicineName">
                            <ItemTemplate>
                                <asp:Label ID="lblMedicineNameReadOnly" runat="server" Text='<%# Eval("MedicineName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblMedicineName" runat="server" Visible="false" Text='<%# Eval("MedicineId") %>'></asp:Label>
                                <asp:DropDownList runat="server" DataTextField="MedicineName" DataValueField="MedicineId" ID="ddlGridMedicineName"></asp:DropDownList>
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
