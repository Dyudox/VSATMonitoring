<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="masterpagu.aspx.vb" Inherits="masterpagu" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Pagu</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="gridpagu" KeyFieldName="ID" ClientInstanceName="gridpagu" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dspagu" EnableTheming="True" Theme="MetropolisBlue">
                <SettingsSearchPanel Visible="True" />
                <Settings ShowFooter="false" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="10">
                        <CellStyle BackColor="#d6f1ff">
                        </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="ID" ReadOnly="true" HeaderStyle-HorizontalAlign="Center" FieldName="ID" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Pagu" HeaderStyle-HorizontalAlign="Center" FieldName="Deskripsi" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                   <%-- <dx:GridViewDataComboBoxColumn Caption="Nama Pagu" HeaderStyle-HorizontalAlign="Center" FieldName="Deskripsi" VisibleIndex="2">
                    <PropertiesComboBox DataSourceID="dsjenisbiaya" TextField="JenisBiaya"
                            ValueField="JenisBiaya" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                           
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>--%>
                    <dx:GridViewDataTextColumn Caption="Jumlah pagu" HeaderStyle-HorizontalAlign="Center" FieldName="Pagu" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Provider" HeaderStyle-HorizontalAlign="Center" FieldName="Provider" VisibleIndex="4">
                        <PropertiesComboBox DataSourceID="dsprovider" TextField="Nama_Provider"
                            ValueField="Nama_Provider" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                            <%--<ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>--%>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Type Karyawan" HeaderStyle-HorizontalAlign="Center" FieldName="TypeKaryawan" VisibleIndex="5">
                        <PropertiesComboBox DataSourceID="dstypekaryawan" TextField="IdStatusPegawai"
                            ValueField="IdStatusPegawai" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                            <%--<ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>--%>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dspagu" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsprovider" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msprovider"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dstypekaryawan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select DISTINCT(IdStatusPegawai) as IdStatusPegawai from msEmployee"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsjenisbiaya" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select JenisBiaya from msJenisBiaya"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

