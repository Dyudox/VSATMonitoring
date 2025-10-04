<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ms_barang.aspx.vb" Inherits="ms_barang" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Barang</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="gridbarang" KeyFieldName="ID" ClientInstanceName="gridbarang" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dsbarang" EnableTheming="True" Theme="MetropolisBlue">
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
                     <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="6">
                    <CellStyle BackColor="#d6f1ff">
                    </CellStyle>
                    </dx:GridViewCommandColumn>
                     <dx:GridViewDataTextColumn Caption="ID Barang" HeaderStyle-HorizontalAlign="Center" FieldName="IdBarang" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn Caption="Nama Barang" HeaderStyle-HorizontalAlign="Center" FieldName="Barang" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dsbarang" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * from msBarang"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

