<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ms_kota.aspx.vb" Inherits="ms_kota" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Kota/Kabupaten</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView runat="server" ID="grid_kokab" Width="100%" AutoGenerateColumns="False" DataSourceID="dskokab" KeyFieldName="ID" EnableTheming="True" Theme="MetropolisBlue">
                <Settings ShowGroupPanel="True"  />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" Width="20%" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="7">
                    <CellStyle BackColor="#d6f1ff">
                    </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdProvinsi" Caption="Provinsi" Width="100px">
                        <PropertiesComboBox DataSourceID="dsprovinsi" TextField="Provinsi" ValueField="IdProvinsi"
                            ValueType="System.String" IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="ID Kota" Width="100px" ReadOnly="true" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" FieldName="IdKota" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kota/Kabupaten" Width="100px" FieldName="Kota" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dskokab" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsprovinsi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msProvinsi]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

