<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ms_kecamatan.aspx.vb" Inherits="ms_kecamatan" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Kecamatan</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="grid_Kecamatan" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dskecamatan" KeyFieldName="ID" EnableTheming="True" Theme="MetropolisBlue">
                <Settings ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" Width="20%" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="10">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="idKota" Caption="Kota / Kabupaten" Width="100px">
                        <PropertiesComboBox DataSourceID="dsKotaload" TextField="Kota" ValueField="idKota"
                            ValueType="System.String" IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="ID Kecamatan" ReadOnly="true" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" Width="100px" FieldName="idKecamatan" Settings-AutoFilterCondition="Contains">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kecamatan" Width="100px" FieldName="Kecamatan" Settings-AutoFilterCondition="Contains">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dskecamatan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsKotaload" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msKota]"></asp:SqlDataSource>
            <%--<asp:SqlDataSource ID="dskota" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT msProvinsi.Provinsi, msKota.idKota, msKota.Kota FROM msProvinsi INNER JOIN msKota ON msProvinsi.IdProvinsi = msKota.idProvinsi"></asp:SqlDataSource>--%>
            <asp:SqlDataSource ID="dskota" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * from mskota"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

