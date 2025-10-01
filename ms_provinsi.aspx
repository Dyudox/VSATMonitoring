<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ms_provinsi.aspx.vb" Inherits="ms_provinsi" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Provinsi</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="grid_provinsi" runat="server" Width="500px" AutoGenerateColumns="False" DataSourceID="dsprovinsi" KeyFieldName="ID" EnableTheming="True" Theme="MetropolisBlue">
                <Settings ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                 <SettingsPager>
                       <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                  </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                 <SettingsSearchPanel Visible="True" />
                 <SettingsEditing Mode="EditFormAndDisplayRow"  />
                <Columns>
                     <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ShowDeleteButton="True" Width="20%" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="3">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="Kode Provinsi" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" Width="50px" FieldName="IdProvinsi" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Provinsi" HeaderStyle-HorizontalAlign="Center" FieldName="Provinsi" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
               <asp:SqlDataSource ID="dsprovinsi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

