<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ms_customer.aspx.vb" Inherits="ms_customer" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Customer / Client</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="gv_customer" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dscustomer" KeyFieldName="IdCustomer" ClientInstanceName="gv_customer" EnableTheming="True" Theme="MetropolisBlue">
                <Settings ShowFooter="false" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDetail ShowDetailRow="true" />
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" Width="50px" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="8">
                        <CellStyle BackColor="#d6f1ff">
                        </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="Kode Customer" Width="50px" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="IdCustomer" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Customer" FieldName="Customer" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Alamat" Width="100px" FieldName="Alamat" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="NPWP" Width="100px" FieldName="NPWP" Settings-AutoFilterCondition="Contains" VisibleIndex="4">
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="PIC" Width="100px" FieldName="PIC" Settings-AutoFilterCondition="Contains" VisibleIndex="5">
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Telp PIC" Width="100px" FieldName="Telp_PIC" Settings-AutoFilterCondition="Contains" VisibleIndex="6">
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Email PIC" Width="100px" FieldName="email_PIC" Settings-AutoFilterCondition="Contains" VisibleIndex="7">
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="gv_detilcustomer" runat="server" EnableTheming="True" Theme="MetropolisBlue" Width="100%" OnBeforePerformDataSelect="gv_detilcustomer_DataSelect" AutoGenerateColumns="False" DataSourceID="dscustomersub" KeyFieldName="IdCustomer_Sub">
                            <Settings ShowFooter="false" ShowGroupPanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <Columns>
                                <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" ShowDeleteButton="True" Width="100px" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="8">
                                    <CellStyle BackColor="#d6f1ff">
                                    </CellStyle>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Kode Sub Customer" Width="100px" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="IdCustomer_Sub" Settings-AutoFilterCondition="Contains">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Nama Sub Customer" FieldName="Customer_Sub" Settings-AutoFilterCondition="Contains">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Alamat" Width="100px" FieldName="Alamat" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>                               
                                <dx:GridViewDataTextColumn Caption="PIC" Width="100px" FieldName="PIC" Settings-AutoFilterCondition="Contains" VisibleIndex="5">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Telp PIC" Width="100px" FieldName="Telp_PIC" Settings-AutoFilterCondition="Contains" VisibleIndex="6">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Email PIC" Width="100px" FieldName="email_PIC" Settings-AutoFilterCondition="Contains" VisibleIndex="7">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>

            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dscustomersub" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dscustomer" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

